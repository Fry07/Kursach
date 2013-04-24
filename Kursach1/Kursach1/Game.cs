using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach
{
    class Game : Screen
    {
        string[,] map;
        int arrayLength = 15;
        public int player_x = 7;
        public int player_y = 14;
        public int enemy_x = 0;
        public int enemy_y;
        public int bullet_x;
        public int bullet_y;
        public int hp_player = 100;
        public int hp_enemy = 99;
        public bool bullet;
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        int choose_direction;

        public Game()
        {
            map = new string[arrayLength, arrayLength];
            Show();
            ShowMap();
            ProcessInput();
        }
        public override void Show()
        {
            Console.Clear();

            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    map[i, j] = "-";
                }
            }
            map[player_y, player_x] = "W";
            enemy_y = rnd1.Next(0, arrayLength);
            map[enemy_x, enemy_y] = "M";

        }
        public override void ShowMap()
        {
            Console.Clear();

            if (bullet && --bullet_y > 0)
            {
                map[bullet_y, bullet_x] = "`";
                map[bullet_y + 1, bullet_x] = "-";
                //if (enemy_x == bullet_x && enemy_y == bullet_y)
                //    enemy.TakeDamage();

            }
            else if (bullet_y == 1)
            {
                map[bullet_y, bullet_x] = "-";
                bullet = false;
            }
            else
            {
                bullet = false;
                // map[bullet_x, bullet_y - 1] = "-";
            }

            choose_direction = rnd2.Next(0, 2);
            if (choose_direction == 0 && enemy_y > 0)
            {
                map[enemy_x, enemy_y - 1] = "M";
                map[enemy_x, enemy_y] = "-";
                enemy_y--;
            }
            else if (choose_direction == 1 && enemy_y < arrayLength - 1)
            {
                map[enemy_x, enemy_y + 1] = "M";
                map[enemy_x, enemy_y] = "-";
                enemy_y++;
            }

            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.Write("\n");
            }


            Console.WriteLine("\nYour HP: {0}\t Enemy's HP:{1}", hp_player, hp_enemy);
            Console.WriteLine("\nPress \"q\" to exit.");
            //ProcessInput();

        }

        public override void ProcessInput()
        {

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            // Console.ReadKey();
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    keyInfo = Console.ReadKey(true);
                    break;
                }
            }
            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:
                    return;
                case ConsoleKey.LeftArrow:
                    if (player_x > 0)
                    {
                        map[player_y, player_x] = "-";
                        map[player_y, player_x - 1] = "W";
                        player_x -= 1;
                    }
                    ShowMap();
                    break;
                case ConsoleKey.RightArrow:
                    if (player_x < arrayLength - 1)
                    {
                        map[player_y, player_x] = "-";
                        map[player_y, player_x + 1] = "W";
                        player_x += 1;
                    }
                    ShowMap();
                    break;
                case ConsoleKey.Spacebar:
                    if (bullet == false)
                    {
                        PlayerShoot();
                        ShowMap();
                    }
                    else { ShowMap(); }
                    //BulletCheck Shoot = new BulletCheck();
                    //if (bullet == false)
                    //{
                    //    Bullet b1 = new Bullet() { bullet_exists = true };
                    //    Shoot.Make_Shoot(b1);
                    //}
                    //else { }
                    break;
            }

            ProcessInput();
        }

        public void PlayerShoot()
        {
            bullet = true;
            bullet_x = player_x;
            bullet_y = player_y;
        }

        class Bullet
        {
            public bool bullet_exists;
        }

        abstract class Abst_Shoot
        {
            public abstract void Make_Shoot(Bullet p);
        }

        class Shoot : Abst_Shoot
        {
            public override void Make_Shoot(Bullet p)
            {
                //  Bullet.bullet_exists = true;
                //  Screen.ShowMap();


            }
        }

        class BulletCheck : Abst_Shoot
        {
            Shoot call = new Shoot();

            public override void Make_Shoot(Bullet p)
            {
                if (p.bullet_exists)
                    call.Make_Shoot(p);
            }
        }

    }

    //template method
    public abstract class Screen
    {
        public abstract void Show();
        public abstract void ProcessInput();
        public abstract void ShowMap();
    }


}
