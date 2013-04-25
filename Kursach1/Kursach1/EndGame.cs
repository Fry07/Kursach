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
        public List<int> ScoreList = new List<int>();
        public override void Show()
        {
            Console.Clear();
            if (_player_wins)
            {
                Console.WriteLine("GRATZ BRO");
            }
            else
            {
                HighScore s1 = HighScore.Instance;

                s1.AddScore(_score);
               
                Console.WriteLine("SUCKER");
            }

            Console.WriteLine("1 - new game;\n2 - main menu.");
        }
        public override void ProcessInput()
        {
            ConsoleKeyInfo key = UserInput();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    
                    Game game2 = new Game(_score);
                    game2.Init();
                    break;
                case ConsoleKey.D2:
                    HighScore hs = HighScore.Instance;
                    hs.AddScore(_score);
                    Menu menu2 = new Menu(new RussianImplementor(), ScoreList);

                    break;
                default:
                    ProcessInput();
                    break;
            }
        }

        public EndGame(bool win, int score)
        {
            _player_wins = win;
            _score = score;
        }

    }
}
