using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    //   static void Main()
    //  {
    //    // Constructor is protected -- cannot use new
    //    Singleton s1 = Singleton.Instance();
    //    Singleton s2 = Singleton.Instance();

    //    // Test for same instance
    //    if (s1 == s2)
    //    {
    //      Console.WriteLine("Objects are the same instance");
    //    }
    //    Console.ReadKey();
    //  }
    //}

    // The 'Singleton' class
    public sealed class HighScore
    {
        private List<int> _scores;

        HighScore() 
        {
            _scores = new List<int>();
        }
        static readonly HighScore instance = new HighScore();

        public static HighScore Instance
        {
            get { return instance; }
        }
        public void AddScore(int score)
        {
            instance._scores.Add(score);
        }

        public List<int> GetScores()
        {
            return this._scores;
        }
    }

}
