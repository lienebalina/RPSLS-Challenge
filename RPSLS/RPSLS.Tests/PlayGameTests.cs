using FluentAssertions;
using Moq.AutoMock;
using System;
using Moq;

namespace RPSLS.Tests
{
    public class PlayGameTests
    {
        private IPlayGame _game;
        private Random _random;
        private AutoMocker _mocker;

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
            var settings = new GameSettings(1, 1);

            _game.SetGameSettings(settings);
            
            var playerMock = _mocker.GetMock<IPlayer>();
            playerMock.Setup(p => p.TakePlayerInput())
                .Returns(1);
            
            var randomMock = _mocker.GetMock<Random>();
            randomMock.Setup(r => r.Next(1, 6))
                .Returns(1);

            _game.RunGame();
            
            playerMock.Verify(p => Console.WriteLine($"You go with Rock"), Times.Once);
        }
    }
}