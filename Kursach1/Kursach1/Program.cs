using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    class Program
    {
        static void Main(string[] args)
        {
            //github
            Menu menu = new Menu(new RussianImplementor());
            Console.ReadKey();
        }
    }
}
