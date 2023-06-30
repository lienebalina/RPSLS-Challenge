using System;
using System.Security.Cryptography;

namespace RPSLS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int computerPoints = 0;
            int playerPoints = 0;
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock! \n");
            Console.WriteLine("The rules ar obvious: \n");
            Console.WriteLine("\t Scissors cuts Paper,\n" +
                              "\t Paper covers Rock,\n" +
                              "\t Rock crushes Lizard,\n" +
                              "\t Lizard poisons Spock,\n" +
                              "\t Spock smashes Scissors,\n" +
                              "\t Scissors decapitates Lizard,\n" +
                              "\t Lizard eats Paper,\n" +
                              "\t Paper disproves Spock,\n" +
                              "\t Spock vaporizes Rock,\n" +
                              "\t and as it always has, Rock crushes Scissors. \n");
            Console.WriteLine(
                "It's easy! and before you say something, no, I'm not crazy, mother had me tested. \n");
            Console.WriteLine("Input any number between 1 and 5 \n");
            Console.WriteLine("1: Rock \n" +
                              "2: Paper\n" +
                              "3: Scissors\n" +
                              "4: Lizard\n" +
                              "5: Spock\n");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Your move!");
                int playerInput = int.Parse(Console.ReadLine());

                if (playerInput < 1 || playerInput > 5)
                {
                    Console.WriteLine("Whats the name of your community college?");
                    Console.WriteLine("GAME OVER");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine($"you go with {Turn(playerInput)}");

                int computerInput = random.Next(1, 6);

                Console.WriteLine($"computer goes with {Turn(computerInput)}");

                var getWinner = GetWinner(computerInput, playerInput);

                if (getWinner == "player")
                {
                    playerPoints++;
                }
                else if (getWinner == "computer")
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
                Console.WriteLine("Player wins");
            }
            else if (playerPoints < computerPoints)
            {
                Console.WriteLine("Computer Wins");
            }
            else
            {
                Console.WriteLine("TIE");
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

        static string GetWinner(int computerChoice, int playerChoice)
        {
            int computerPoints = 0;
            int playerPoints = 0;

            if (computerChoice == playerChoice)
            {
                computerPoints++;
                playerPoints++;
            }
            else
            {
                switch (computerChoice)
                {
                    case 1:
                        switch (playerChoice)
                        {
                            case 2:
                                playerPoints++;
                                break;
                            case 3:
                                computerPoints++;
                                break;
                            case 4:
                                computerPoints++;
                                break;
                            case 5:
                                playerPoints++;
                                break;
                        }
                        break;
                    case 2:
                        switch (playerChoice)
                        {
                            case 1:
                                computerPoints++;
                                break;
                            case 3:
                                playerPoints++;
                                break;
                            case 4:
                                playerPoints++;
                                break;
                            case 5:
                                computerPoints++;
                                break;
                        }
                        break;
                    case 3:
                        switch (playerChoice)
                        {
                            case 1:
                                playerPoints++;
                                break;
                            case 2:
                                computerPoints++;
                                break;
                            case 4:
                                computerPoints++;
                                break;
                            case 5:
                                playerPoints++;
                                break;
                        }
                        break;
                    case 4:
                        switch (playerChoice)
                        {
                            case 1:
                                playerPoints++;
                                break;
                            case 2:
                                computerPoints++;
                                break;
                            case 3:
                                playerPoints++;
                                break;
                            case 5:
                                playerPoints++;
                                break;
                        }
                        break;
                    case 5:
                        switch (playerChoice)
                        {
                            case 1:
                                computerPoints++;
                                break;
                            case 2:
                                playerPoints++;
                                break;
                            case 3:
                                computerPoints++;
                                break;
                            case 4:
                                playerPoints++;
                                break;
                        }
                        break;
                }
            }

            if (playerPoints > computerPoints)
            {
                return "player";
            }
            else if (playerPoints < computerPoints)
            {
                return "computer";
            }
            else
            {
                return "tie";
            }
        }
    }
}