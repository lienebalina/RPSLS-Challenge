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
        string Turn(int num);
        void GetRoundWinner(int computerChoice, int playerChoice);
        string GetGameWinner(int playerPoints, int computerPoints);
    }
}
