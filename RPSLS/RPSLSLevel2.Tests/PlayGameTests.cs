using FluentAssertions;
using Moq;
using Moq.AutoMock;
using RPSLS;

namespace RPSLSLevel2.Tests
{
    public class PlayGameTests
    {
        private IPlayGame _game;
        private Random _random;
        private AutoMocker _mocker;
        public List<string> ComputerNames =  new List<string>()
        {
            "SoftKittyWarmKitty",
            "RajTheSilent",
            "Shelbot9000"
        };

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _game = new PlayGame(_mocker.GetMock<IPlayer>().Object, _mocker.GetMock<Random>().Object);
        }

        [Test]
        public void SetGameSettings_Set_SetsCorrectSettings()
        {
            var settings = new GameSettings(1, 3);

            _game.SetGameSettings(settings);

            _game.Settings.ComputerCount.Should().Be(1);
            _game.Settings.RoundCount.Should().Be(3);
        }

        [Test]
        public void RunGame_RunWithValidGameSettings_GameRunSuccessfully()
        {
            var settings = new GameSettings(3, 1);

            _game.SetGameSettings(settings);
            
            var playerMock = _mocker.GetMock<IPlayer>();
            playerMock.Setup(p => p.TakePlayerInput())
                .Returns(1);

            var randomMock = _mocker.GetMock<Random>();
            randomMock.Setup(r => r.Next(1, 6))
                .Returns(1);

            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader("1");
            Console.SetIn(textReader);

            _game.RunGame();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("You go with Rock", lines[1]);
            Assert.AreEqual($"{ComputerNames[0]} goes with Rock", lines[2]);
            Assert.AreEqual("It's a tie!", lines[3]);
        }

        [Test]
        public void RunGame_RunWithInvalidPlayerInput_GameOver()
        {
            var settings = new GameSettings(1, 1);

            _game.SetGameSettings(settings);

            var playerMock = _mocker.GetMock<IPlayer>();
            playerMock.Setup(p => p.TakePlayerInput())
                .Returns(7);

            var randomMock = _mocker.GetMock<Random>();
            randomMock.Setup(r => r.Next(1, 6))
                .Returns(1);

            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader("7");
            Console.SetIn(textReader);

            _game.RunGame();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Whats the name of your community college?", lines[1]);
            Assert.AreEqual("GAME OVER", lines[2]);
        }

        [Test]
        public void RunGame_RunWithValidInputs_PlayerWinsGame()
        {
            var settings = new GameSettings(1, 1);

            _game.SetGameSettings(settings);

            var playerMock = _mocker.GetMock<IPlayer>();
            playerMock.Setup(p => p.TakePlayerInput())
                .Returns(4);

            var randomMock = _mocker.GetMock<Random>();
            randomMock.Setup(r => r.Next(1, 6))
                .Returns(5);

            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader("4");
            Console.SetIn(textReader);

            _game.RunGame();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("You go with Lizard", lines[1]);
            Assert.AreEqual($"{ComputerNames[0]} goes with Spock", lines[2]);
            Assert.AreEqual("You win!", lines[3]);
        }

        [Test]
        public void RunGame_RunWithValidInputs_ComputerWinsGame()
        {
            var settings = new GameSettings(1, 1);

            _game.SetGameSettings(settings);

            var playerMock = _mocker.GetMock<IPlayer>();
            playerMock.Setup(p => p.TakePlayerInput())
                .Returns(2);

            var randomMock = _mocker.GetMock<Random>();
            randomMock.Setup(r => r.Next(1, 6))
                .Returns(3);

            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader("2");
            Console.SetIn(textReader);

            _game.RunGame();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("You go with Paper", lines[1]);
            Assert.AreEqual($"{ComputerNames[0]} goes with Scissors", lines[2]);
            Assert.AreEqual($"{ComputerNames[0]} Wins!", lines[3]);
        }

    }
}