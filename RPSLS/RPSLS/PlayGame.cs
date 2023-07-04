using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class PlayGame : IPlayGame
    {
        private GameSettings _settings;
        private Random _random = new Random();
        public List<string> ComputerNames;
        private IPlayer _player;
        private List<string> _winnerList;
        private int _computerCount;

        public PlayGame(IPlayer player, Random random)
        {
            _random = random;
            _player = player;
            _settings = new GameSettings(computerCount: 0, roundCount: 0);
            ComputerNames = new List<string>()
            {
                "SoftKittyWarmKitty",
                "RajTheSilent",
                "Shelbot9000",
                "StuartTheComicBookGuy",
                "MoonPie",
                "SheldorTheConqueror",
                "ThatsMySpot",
                "EinsteinVonBrainstorm",
                "IWentToSpaceOnce"
            };
            _player = new Player();
            _winnerList = new List<string>();
        }

        public PlayGame()
        {
            _settings = new GameSettings(computerCount: 0, roundCount: 0);
            ComputerNames = new List<string>()
            {
                "SoftKittyWarmKitty",
                "RajTheSilent",
                "Shelbot9000",
                "StuartTheComicBookGuy",
                "MoonPie",
                "SheldorTheConqueror",
                "ThatsMySpot",
                "EinsteinVonBrainstorm",
                "IWentToSpaceOnce"
            };
            _player = new Player();
            _winnerList = new List<string>();
        }

        public void SetGameSettings(GameSettings settings)
        {
            bool isSettingsValid = (settings.ComputerCount > 0 || settings.ComputerCount < 10) &&
                                   (settings.RoundCount > 0 || settings.RoundCount < 6);

            if (isSettingsValid)
            {
                _settings.ComputerCount = settings.ComputerCount;
                _settings.RoundCount = settings.RoundCount;
                _computerCount = settings.ComputerCount;
            }
        }

        public GameSettings Settings => _settings;

        public void RunGame()
        {
            for (int c = 0; c < _settings.ComputerCount; c++)
            {
                for (int i = 0; i < _settings.RoundCount; i++)
                {
                    int playerInput = _player.TakePlayerInput();

                    if (playerInput < 1 || playerInput > 5)
                    {
                        Console.WriteLine("Whats the name of your community college?");
                        Console.WriteLine("GAME OVER");
                        break;
                    }

                    Console.WriteLine($"You go with {Turn(playerInput)}");

                    int computerInput = _random.Next(1, 6);

                    Console.WriteLine($"{ComputerNames[c]} goes with {Turn(computerInput)} \n");

                    Console.WriteLine(GetRoundWinner(computerInput, playerInput, ComputerNames[c], "player"));

                }
            }
            
            ComputerVsComputer();

            GetGameResults();

            Console.ReadLine();
        }

        public void ComputerVsComputer()
        {
            while (_settings.ComputerCount > 1)
            {
                for (int i = 0; i < _settings.ComputerCount - 1; i++)
                {
                    for (int j = 0; j < _settings.RoundCount; j++)
                    {
                        var computerMove = _random.Next(1, 6);

                        Console.WriteLine($"{ComputerNames[_settings.ComputerCount - 1]} goes with {Turn(computerMove)}");

                        var otherComputerMove = _random.Next(1, 6);

                        Console.WriteLine($"{ComputerNames[i]} goes with {Turn(otherComputerMove)}");

                        var roundWinner = GetRoundWinner(computerMove, otherComputerMove, ComputerNames[_settings.ComputerCount - 1],
                            ComputerNames[i]);
                    }
                }
                _settings.ComputerCount--;
            }
        }

        public void SetRandom(Random random)
        {
            _random = random;
        }

        public string Turn(int num)
        {
            var turn = "";

            switch (num)
            {
                case 1:
                    turn = "Rock";
                    break;
                case 2:
                    turn = "Paper";
                    break;
                case 3:
                    turn = "Scissors";
                    break;
                case 4:
                    turn = "Lizard";
                    break;
                case 5:
                    turn = "Spock";
                    break;
            }

            return turn;
        }

        public string GetRoundWinner(int player1, int player2, string player1Name, string player2Name)
        {
            var gameRules = new Dictionary<string, List<string>>
            {
                { "Rock", new List<string> { "Scissors", "Lizard" } },
                { "Paper", new List<string> { "Rock", "Spock" } },
                { "Scissors", new List<string> { "Paper", "Lizard" } },
                { "Lizard", new List<string> { "Paper", "Spock" } },
                { "Spock", new List<string> { "Rock", "Scissors" } }
            };

            if (player1 == player2)
            {
                _winnerList.Add(player1Name);
                _winnerList.Add(player2Name);

                return "It's a tie! \n";
            }
            else if (gameRules[Turn(player2)].Contains((Turn(player1))))
            {
                _winnerList.Add(player2Name);

                return $"{player2Name} wins this round! \n";
            }
            else
            {
                _winnerList.Add(player1Name);

                return $"{player1Name} wins this round! \n";
            }
        }

        public void GetGameResults()
        {
            Console.WriteLine("The results are in!\n");

            int playerPoints = _winnerList.FindAll(k => k == "player").Count;
            Console.WriteLine($"Player points: {playerPoints}");

            for (int i = 0; i < _computerCount; i++)
            {
                var name = ComputerNames[i];
                int computerPoints = _winnerList.FindAll(k => k == name).Count;
                Console.WriteLine($"{name} points: {computerPoints}");
            }
        }
    }
}
