using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Enemy
    {
        public int enemy_x;
        int array_length;
        Random rnd2 = new Random();
        int choose_direction;

        public Enemy(int x, int length)
        {
            enemy_x = x;
            array_length = length;
        }

        public void MoveEnemy()
        {
            choose_direction = rnd2.Next(0, 2);
            if (choose_direction == 0)
            {
                if (enemy_x > 0)
                    enemy_x--;
                else
                    enemy_x++;
            }
            else if (choose_direction == 1)
            {
                if (enemy_x < array_length - 1)
                    enemy_x++;
                else
                    enemy_x--;
            }
        }
    }
}
