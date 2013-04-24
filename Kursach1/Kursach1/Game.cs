using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    class Game : Screen
    {
        public int[,] map;
        public int arrayLength = 15;
        public int player_y = 14;
        public int enemy_y = 0;
        public int bullet_x;
        public int bullet_y;
        public int hp_player = 100;
        public int hp_enemy = 99;
        public bool bullet;
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        List<Bullet> BulletList;
        public enum GameObject { EMPTY = 0, PLAYER = 1, ENEMY = 2, BULLET = 3 };

        Player _player;
        Enemy _enemy;
        int choose_direction;

        public Game()
        {
            map = new int[arrayLength, arrayLength];
            BulletList = new List<Bullet>();
            Init();
            ShowMap();
            ProcessInput();
        }
        public override void Init()
        {
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    map[i, j] = (int)GameObject.EMPTY;
                }
            }

            _player = new Player(6);
            _enemy = new Enemy(rnd1.Next(0, arrayLength), arrayLength);
            map[player_y, _player.player_x] = (int)GameObject.PLAYER;
            map[enemy_y, _enemy.enemy_x] = (int)GameObject.ENEMY;

        }
        public override void ShowMap()
        {
            Console.Clear();

            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    switch (map[i, j])
                    {
                        case (int)GameObject.PLAYER:
                            Console.Write("W");
                            break;
                        case (int)GameObject.ENEMY:
                            Console.Write("M");
                            break;
                        case (int)GameObject.BULLET:
                            Console.Write("`");
                            break;
                        default:
                            Console.Write("-");
                            break;
                    }
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("\nYour HP: {0}\t Enemy's HP:{1}", hp_player, hp_enemy);
            Console.WriteLine("\nPress \"q\" to exit.");


        }

        public override void ProcessInput()
        {
            ShowMap();
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

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
                    if (_player.player_x>0)
                    _player.MovePlayerLeft();
                    break;
                case ConsoleKey.RightArrow:
                    if (_player.player_x < arrayLength -1)
                    _player.MovePlayerRight();
                    break;
                case ConsoleKey.Spacebar:
                    Bullet bullet = new Bullet(_player.player_x, player_y, -1, arrayLength);
                    BulletList.Add(bullet);
                    break;
            }
            ClearMap();

            _enemy.MoveEnemy();

            map[player_y, _player.player_x] = (int)GameObject.PLAYER;
            map[enemy_y, _enemy.enemy_x] = (int)GameObject.ENEMY;

            foreach (Bullet bullet in BulletList)
            {
                bullet.MoveBullet();
                if (bullet._exists)
                {
                    map[bullet._y, bullet._x] = (int)GameObject.BULLET;
                }
                else
                {
                    BulletList.Remove(bullet);
                }
                
            }

            ProcessInput();
        }

        public void ClearMap()
        {
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    map[i, j] = (int)GameObject.EMPTY;
                }
            }
        }

    }

    //template method
    public abstract class Screen
    {
        public abstract void Init();
        public abstract void ProcessInput();
        public abstract void ShowMap();
    }


}
