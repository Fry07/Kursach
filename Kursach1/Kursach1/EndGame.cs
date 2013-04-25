using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class EndGame : Screen
    {
        bool _player_wins;
        public override void Show()
        {
            Console.Clear();
            if (_player_wins)
            {
                Console.WriteLine("GRATZ BRO");
            }
            else
            {
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
                    Game game2 = new Game();
                    game2.Init();
                    break;
                case ConsoleKey.D2:
                    break;
                default:
                    ProcessInput();
                    break;
            }
        }

        public EndGame(bool win)
        {
            _player_wins = win;
        }

    }
}
