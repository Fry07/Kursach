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
        public int _score;
        public string _enemy_type;
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        List<Bullet> BulletList;
        public enum GameObject { EMPTY, PLAYER, ENEMY, BULLET_P, BULLET_E, EXPLOSION };

        Player _player;
        Enemy _enemy;

        public Game(int score, string enemy_type)
        {
            _enemy_type = enemy_type;
            _score = score;
            map = new int[arrayLength, arrayLength];
            BulletList = new List<Bullet>();
            
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    map[i, j] = (int)GameObject.EMPTY;
                }
            }

            _player = new Player(6);

            Create create = new Create();
            create.x = rnd1.Next(0, arrayLength);
            create.length = arrayLength;
            EnemyProcessor createProcessor = null;
            AbstractEnemy factory = null;

            if (enemy_type == "hard")
            {
                factory = new HardEnemyFactory();
            }
            else if (enemy_type == "easy")
            {
                factory = new EasyEnemyFactory();
            }
            createProcessor = new EnemyProcessor(factory);
            _enemy = createProcessor.processOrder(create);

            map[player_y, _player.player_x] = (int)GameObject.PLAYER;
            map[enemy_y, _enemy._x] = (int)GameObject.ENEMY;
        }
        public override void Show()
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
                        case (int)GameObject.BULLET_P:
                            Console.Write("^");
                            break;
                        case (int)GameObject.BULLET_E:
                            Console.Write("|");
                            break;
                        case (int)GameObject.EXPLOSION:
                            Console.Write('@');
                            break;
                        default:
                            Console.Write("-");
                            break;
                    }
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("\nYour HP: {0}\t Enemy's HP:{1}", _player._hp, _enemy._hp);
            Console.WriteLine("Score: {0}", _score);
            Console.WriteLine("\nPress \"q\" to exit.");


        }

        public override void ProcessInput()
        {
            Show();
            ConsoleKeyInfo keyInfo = UserInput();

            
            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:
                    return;
                case ConsoleKey.LeftArrow:
                    Proxy proxy1 = new Proxy(_player, arrayLength);
                    proxy1.MovePlayerLeft();
                    break;
                case ConsoleKey.RightArrow:
                    Proxy proxy2 = new Proxy(_player, arrayLength);
                    proxy2.MovePlayerRight();
                    break;
                case ConsoleKey.Spacebar:
                    Bullet bullet = new Bullet(_player.player_x, player_y, -1, arrayLength);
                    BulletList.Add(bullet);
                    break;
            }
            ClearMap();

            _enemy.MoveEnemy();

            if (_enemy._moves % 3 == 0)
            {
                Bullet bullet = new Bullet(_enemy._x, enemy_y, 1, arrayLength);
                BulletList.Add(bullet);
            }

            map[player_y, _player.player_x] = (int)GameObject.PLAYER;
            map[enemy_y, _enemy._x] = (int)GameObject.ENEMY;

            List<Bullet> tmpBullet = new List<Bullet>();

            foreach (Bullet bullet in BulletList)
            {
                bullet.MoveBullet();

                if (bullet._exists)
                {
                    if (bullet.Collision(enemy_y, _enemy._x))
                    {
                        _enemy._hp -= 10;
                        map[bullet._y, bullet._x] = (int)GameObject.EXPLOSION;
                    }
                    else if (bullet.Collision(player_y, _player.player_x))
                    {
                        _player._hp -= 10;
                        map[bullet._y, bullet._x] = (int)GameObject.EXPLOSION;
                    }
                    else
                    {
                        if(bullet._direction > 0)
                            map[bullet._y, bullet._x] = (int)GameObject.BULLET_E;
                        else
                            map[bullet._y, bullet._x] = (int)GameObject.BULLET_P;

                    }
                }
                else
                {
                    tmpBullet.Add(bullet);
                }
            }

            foreach (Bullet bullet in tmpBullet)
            {
                BulletList.Remove(bullet);
            }
            if (_player._hp <= 0)
            {
                EndGame end = new EndGame(false, _score);
                end.Init();
                
            }
            else if (_enemy._hp <= 0)
            {
                if (_enemy_type == "easy")
                {
                    _score += 10;
                }
                else if (_enemy_type == "hard")
                {
                    _score += 20;
                }
                    EndGame end = new EndGame(true, _score);
                end.Init();
            }
            else
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
        public void Init()
        {
            Show();
            ProcessInput();
        }
        public abstract void ProcessInput();
        public abstract void Show();

        public ConsoleKeyInfo UserInput() 
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    keyInfo = Console.ReadKey(true);
                    break;
                }
            }
            return keyInfo;
        }
    }


}
