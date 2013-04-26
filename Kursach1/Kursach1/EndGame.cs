using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class EndGame : Screen
    {
        bool _player_wins;
        int _score;
        HighScore _hs;
        string _enemy_type;

        public override void Show()
        {
            Console.Clear();
            if (_player_wins)
            {
                Console.WriteLine("Congratulations!");
            }
            else
            {
                HighScore s1 = HighScore.Instance;

                s1.AddScore(_score);

                Console.WriteLine("You lost. =(");
            }
            if (!_player_wins)
                Console.WriteLine("1 - try again (you have a chance to save your score and continue);\n2 - main menu.");
            else if (_player_wins)
                Console.WriteLine("1-easy enemy;\n2-hard enemy;\n3-to the main menu;");
        }
        public override void ProcessInput()
        {
            ConsoleKeyInfo key = UserInput();
            if (!_player_wins)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        bool a = false;
                        if (_enemy_type == "easy") { a = true; }
                        Save easyFightFlee = new EasySave();
                        Save hardFightFlee = new HardSave();
                        easyFightFlee.SetSuccessor(hardFightFlee);
                        _score = easyFightFlee.SaveScore(_score, a);
                        Game game2 = new Game(_score, "easy");
                        game2.Init();
                        break;
                    case ConsoleKey.D2:
                        _hs.AddScore(_score);
                        return;
                    default:
                        ProcessInput();
                        break;
                }
            }
            else if (_player_wins)
            {

                AbstractEnemy factory = null;
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        factory = new EasyEnemyFactory();
                        Game game3 = new Game(_score, "easy");
                        game3.Init();
                        break;
                    case ConsoleKey.D2:
                        factory = new HardEnemyFactory();
                        Game game4 = new Game(_score, "hard");
                        game4.Init();
                        break;
                    case ConsoleKey.D3:
                        _hs.AddScore(_score);
                        return;
                    default:
                        ProcessInput();
                        break;
                }
            }
        }

        public EndGame(bool win, int score, string enemy_type)
        {
            _player_wins = win;
            _score = score;
            _enemy_type = enemy_type;
            _hs = HighScore.Instance;
        }

    }
}
