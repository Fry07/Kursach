using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Player
    {
        public int player_x;
        public int hp_player = 100;

        public void MovePlayerLeft()
        {                           
                player_x --;
                hp_player = 100;
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
