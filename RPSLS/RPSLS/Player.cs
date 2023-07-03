using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Player : IPlayer
    {
        private int _playerInput;

        public int TakePlayerInput()
        {
            Console.WriteLine("Your move!");
            _playerInput = int.Parse(Console.ReadLine());

            return _playerInput;
        }
    }
}
