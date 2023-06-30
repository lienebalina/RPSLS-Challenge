namespace RPSLS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var computerNames = new List<string>()
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

            var winnerList = new List<string>();

            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock Level 2! \n");

            Console.WriteLine("The rules ar obvious: \n" +
                              "\t Scissors cuts Paper,\n" +
                              "\t Paper covers Rock,\n" +
                              "\t Rock crushes Lizard,\n" +
                              "\t Lizard poisons Spock,\n" +
                              "\t Spock smashes Scissors,\n" +
                              "\t Scissors decapitates Lizard,\n" +
                              "\t Lizard eats Paper,\n" +
                              "\t Paper disproves Spock,\n" +
                              "\t Spock vaporizes Rock,\n" +
                              "\t and as it always has, Rock crushes Scissors. \n");
           
            Console.WriteLine("Input any number between 1 and 5 \n" +
                              "1: Rock \n" +
                              "2: Paper\n" +
                              "3: Scissors\n" +
                              "4: Lizard\n" +
                              "5: Spock\n");

            Console.WriteLine("How many rounds (from 1 to 5) should players do with each other?");
            var roundCount = int.Parse(Console.ReadLine());

            Console.WriteLine("How many computer players (from 1 to 9)?");
            var playerCount = int.Parse(Console.ReadLine());
            var count = playerCount;
            
            for (int i = 0; i < playerCount; i++)
            {
                for (int j = 0; j < roundCount; j++) 
                {
                    Console.WriteLine("Your move!");
                    int playerInput = int.Parse(Console.ReadLine());

                    if (playerInput < 1 || playerInput > 5)
                    {
                        Console.WriteLine("Whats the name of your community college?");
                        Console.WriteLine("GAME OVER");
                        return;
                    }
                    
                    Console.WriteLine($"You go with {Turn(playerInput)}");

                    int computerInput = random.Next(1, 6);
                    
                    Console.WriteLine($"{computerNames[i]} goes with {Turn(computerInput)} \n");

                    var roundWinner = GetRoundWinner(computerInput, playerInput, computerNames[i], "player");

                    if (roundWinner == "tie")
                    {
                        winnerList.Add("player");
                        winnerList.Add($"{computerNames[i]}");
                    }
                    else
                    {
                        winnerList.Add(roundWinner);
                    }
                }
            }
            
            while (playerCount > 1)
            {
                for (int i = 0; i < playerCount-1; i++)
                {
                    for (int j = 0; j < roundCount; j++)
                    {
                        var computerMove = random.Next(1, 6);

                        //Console.WriteLine($"{computerNames[playerCount-1]} goes with {Turn(computerMove)}");

                        var otherComputerMove = random.Next(1, 6);

                        //Console.WriteLine($"{computerNames[i]} goes with {Turn(otherComputerMove)} \n");

                        var roundWinner = GetRoundWinner(computerMove, otherComputerMove, computerNames[playerCount-1],
                            computerNames[i]);

                        if (roundWinner == "tie")
                        {
                            winnerList.Add($"{computerNames[playerCount - 1]}");
                            winnerList.Add($"{computerNames[i]}");
                        }
                        else
                        {
                            winnerList.Add(roundWinner);
                        }

                        //Console.ReadLine();
                    }
                }
                playerCount--;
            }

            Console.WriteLine("The results are in!\n");

            int playerPoints = winnerList.FindAll(k => k == "player").Count;
            Console.WriteLine($"Player points: {playerPoints}");

            for (int i = 0; i < count; i++)
            {
                var name = computerNames[i];
                int computerPoints = winnerList.FindAll(k => k == name).Count;
                Console.WriteLine($"{name} points: {computerPoints}");
            }

            Console.ReadLine();
        }

        static string Turn(int num)
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

        static string GetRoundWinner(int player1, int player2, string player1Name, string player2Name)
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
                return "tie";
            }
            else if (gameRules[Turn(player2)].Contains((Turn(player1))))
            {
                return $"{player2Name}";
            }
            else
            {
                return $"{player1Name}";
            }
        }
    }
}