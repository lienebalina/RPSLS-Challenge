namespace RPSLS
{
    public class Program
    {
        static void Main(string[] args)
        {
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

            var game = new PlayGame();

            var settings = new GameSettings(3, 3);

            game.SetGameSettings(settings);
            
            game.RunGame();
        }
    }
}