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
                "Shelbot9000"
            };

            int computerPoints = 0;
            int playerPoints = 0;


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

            var roundCount = 3;
            var playerCount = 3;
            
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

                    var roundWinner = GetRoundWinner(computerInput, playerInput);

                    if (roundWinner == "player")
                    {
                        playerPoints++;
                    }
                    else if (roundWinner == "computer")
                    {
                        computerPoints++;
                    }
                    else
                    {
                        playerPoints++;
                        computerPoints++;
                    }
                }

                if (playerPoints > computerPoints)
                {
                    Console.WriteLine("You win\n");
                }
                else if (playerPoints < computerPoints)
                {
                    Console.WriteLine($"{computerNames[i]} wins");
                    return;
                }
                else
                {
                    Console.WriteLine("It's a tie!"); 
                    return;
                }
            }

            Console.WriteLine("You won, wow");
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

        static string GetRoundWinner(int computerChoice, int playerChoice)
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
                return "tie";
            }
            else if (gameRules[Turn(playerChoice)].Contains((Turn(computerChoice))))
            {
                return "player";
            }
            else
            {
                return "computer";
            }
        }
    }
}