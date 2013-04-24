using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{

    class GameAbstraction
    {
        protected InfoImplementor implementor;

        public InfoImplementor Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        public virtual void ShowInfo()
        {
            implementor.ShowInfo();
        }
    }

    abstract class InfoImplementor
    {
        public abstract void ShowInfo();
    }

    class GameRef : GameAbstraction
    {
        public override void ShowInfo()
        {
            implementor.ShowInfo();
        }
    }

    class RussianImplementor : InfoImplementor
    {
        public override void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine("1- старт");
            Console.WriteLine("2- выбор языка");
            Console.WriteLine("3- рекорды");
            Console.WriteLine("4- инфо");
            Console.WriteLine("5- выход");
        }
    }

    class EnglishImplementor : InfoImplementor
    {
        public override void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine("1- start");
            Console.WriteLine("2- choose language");
            Console.WriteLine("3- high scores");
            Console.WriteLine("4- info");
            Console.WriteLine("5- exit");
        }
    }

    class Menu
    {
        GameAbstraction game;

        public Menu()
        {
            game = new GameRef();
            game.Implementor = new RussianImplementor();

            GetInput();
        }

        public void GetInput()
        {
            Info();

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
                case ConsoleKey.D1:
                    Game game = new Game();
                    break;
                case ConsoleKey.D2:
                    ChooseLanguage();
                    break;
                case ConsoleKey.D3:
                    // Records();
                    break;
                case ConsoleKey.D4:
                    Client cl = new Client();
                    cl.ShowInfo();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine("press any key to exit");
                    return;
                default:
                    break;
            }

            GetInput();
        }

        public void ChooseLanguage()
        {
            Console.Clear();
            Console.WriteLine("1- русский");
            Console.WriteLine("2- english");

            ConsoleKeyInfo languageInfo = new ConsoleKeyInfo();
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    languageInfo = Console.ReadKey(true);
                    break;
                }
            }
            switch (languageInfo.Key)
            {
                case ConsoleKey.D1:
                    game.Implementor = new RussianImplementor();
                    break;
                case ConsoleKey.D2:
                    game.Implementor = new EnglishImplementor();
                    break;
                default:
                    ChooseLanguage();
                    break;
            }
        }

        public void Info()
        {
            game.ShowInfo();

        }

    }

    public interface IComponent
    {
        string Operation();
    }

    public class Component : IComponent
    {
        public string Operation()
        {
            return "\nversions: ";
        }
    }

    public class DecoratorA : IComponent
    {
        IComponent component;

        public DecoratorA(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "\nver 1.0: game;";
            return s;
        }
    }

    public class DecoratorB : IComponent
    {
        IComponent component;
        public string addedState = "ver 1.2: two languages. ";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "\nver 1.1: added records; ";
            return s;
        }

        public string AddedBehavior()
        {
            return "\n\nyou have to shoot an enemy. use arrows to navigate and space to shoot. \n\npress any key to continue.";
        }
    }

    public class Client
    {

        public void Display(string s, IComponent c)
        {
            Console.WriteLine(s + c.Operation());
        }

        public void ShowInfo()
        {
            Console.Clear();
            IComponent component = new Component();
            Display("", new DecoratorA(component));
            Display("", new DecoratorB(component));
            Display("", component);
            DecoratorB b = new DecoratorB(new Component());

            Console.WriteLine("" + b.addedState + b.AddedBehavior());
            Console.ReadKey();
        }
    }
}



