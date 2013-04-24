using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Player
    {
        public int player_x;
        public int _hp = 100;

        public void MovePlayerLeft()
        {                           
                player_x --;
        }

        public void MovePlayerRight()
        {
                player_x ++;
        }

        public Player(int x)
        {
            player_x = x;
        }
    }
}
