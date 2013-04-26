using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
   
    public abstract class Save
    {
        public int _score;
        public bool _easy_enemy;
        protected Random rnd = new Random();
        protected Save successor;

        public void SetSuccessor(Save successor)
        {
            this.successor = successor;
        }

        public abstract int SaveScore(int score, bool easy_enemy);
    }

    public class EasySave : Save
    {
        public override int SaveScore(int score, bool easy_enemy)
        {
            if (easy_enemy)
            {
                if (rnd.Next(0, 6) >= 3)
                    _score = score;
                else
                    _score = 0;
            }
            else if (successor != null)
            {
                return successor.SaveScore(score, easy_enemy);
            }
            
            return _score;
        }
    }


    class HardSave : Save
    {
        public override int SaveScore(int score, bool easy_enemy)
        {
            if (rnd.Next(0, 6) >= 5)
                _score = score;
            else
                _score = 0;
            return _score;
        }
    }
}

