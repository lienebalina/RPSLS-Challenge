using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class GameSettings
    {
        public int ComputerCount;
        public int RoundCount;
        public GameSettings(int computerCount, int roundCount)
        {
            ComputerCount = computerCount;
            RoundCount = roundCount;
        }
    }
}
