using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Enemy_my
    {
        public int _x;
        public int _hp;
        public int _moves;
        int _size;
        Random rnd2 = new Random();
        int choose_direction;

        public Enemy_my(int x, int length)
        {
            _x = x;
            _size = length;
            _hp = 100;
            _moves = 0;
        }

        public void MoveEnemy()
        {
            choose_direction = rnd2.Next(0, 2);
            if (choose_direction == 0)
            {
                if (_x > 0)
                    _x--;
                else
                    _x++;
            }
            else if (choose_direction == 1)
            {
                if (_x < _size - 1)
                    _x++;
                else
                    _x--;
            }

            _moves++;
        }
    }
}
