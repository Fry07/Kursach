using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
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
