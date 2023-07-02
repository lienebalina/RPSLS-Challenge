using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class PlayGame
    {
        private GameSettings _settings;
        private Random _random = new Random();
        private int _computerPoints;
        private int _playerPoints;
        private Player _player;

        public PlayGame()
        {
            _settings = new GameSettings(computerCount: 0, roundCount: 0);
            _player = new Player();
        }

        public void SetGameSettings(GameSettings settings)
        {
            bool isSettingsValid = (settings.ComputerCount > 0 || settings.ComputerCount < 10) && (settings.RoundCount > 0 || settings.RoundCount < 6);

            if (isSettingsValid)
            {
                _settings.ComputerCount = settings.ComputerCount;
                _settings.RoundCount = settings.RoundCount;
            }
        }

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

                    Console.WriteLine($"Penny goes with {Turn(computerInput)} \n");

                    GetRoundWinner(computerInput, playerInput);

                }

                Console.WriteLine(GetGameWinner(_playerPoints, _computerPoints));
            }
        }
        
        private string Turn(int num)
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

        private void GetRoundWinner(int computerChoice, int playerChoice)
        {
            var gameRules = new Dictionary<string, List<string>>
            {
                { "Rock", new List<string> { "Scissors", "Lizard" } },
                { "Paper", new List<string> { "Rock", "Spock" } },
                { "Scissors", new List<string> { "Paper", "Lizard" } },
                { "Lizard", new List<string> { "Paper", "Spock" } },
                { "Spock", new List<string> { "Rock", "Scissors" } }
            };

            if (computerChoice == playerChoice)
            {
                _playerPoints++;
                _computerPoints++;
            }
            else if (gameRules[Turn(playerChoice)].Contains((Turn(computerChoice))))
            {
                _playerPoints++;
            }
            else
            {
                _computerPoints++;
            }
        }

        private string GetGameWinner(int playerPoints, int computerPoints)
        {
            if (playerPoints > computerPoints)
            {
                return "You win!";
            }
            else if (playerPoints < computerPoints)
            {
                return "Penny Wins!";
            }
            else
            {
                return "It's a tie!";
            }
        }
    }
}
