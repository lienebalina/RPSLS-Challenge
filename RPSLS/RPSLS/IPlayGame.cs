using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public interface IPlayGame
    {
        void SetGameSettings(GameSettings settings);
        GameSettings Settings { get; }
        void RunGame();
        void ComputerVsComputer();
        void SetRandom(Random random);
        string Turn(int num);
        string GetRoundWinner(int player1, int player2, string player1Name, string player2Name);
        void GetGameResults();
    }
}
