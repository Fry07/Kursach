using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public abstract class Abst_Player
    {
        public int player_x;
        public int _hp = 100;

        public abstract void MovePlayerLeft();

        public abstract void MovePlayerRight();
    }

    public class Player : Abst_Player
    {
        

        public override void MovePlayerLeft()
        {                           
                player_x --;
        }

        public override void MovePlayerRight()
        {
                player_x ++;
        }

        public Player(int x)
        {
            player_x = x;
        }
    }
}
