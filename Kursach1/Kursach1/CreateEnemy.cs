using System;
using System.Collections.Generic;
using System.Text;

namespace Kursach1
{
    public class Create {
        public int x;
        public int length;
    }

    public abstract class AbstractEnemy
    {
        public abstract Enemy createDifficulty();
    }

    public class EasyEnemyFactory : AbstractEnemy
    {
        public override Enemy createDifficulty()
        {
            return new EasyEnemy();
        }
    }

    public class HardEnemyFactory : AbstractEnemy
    {
        public override Enemy createDifficulty()
        {
            return new HardEnemy();
        }
    }

    public abstract class Enemy
    {
        public int _x;
        public int _hp;
        public int _moves;
        protected int _size;
        Random rnd2 = new Random();
        int choose_direction;

        public abstract void calculateDifficulty(Create create);

        public void MoveEnemy()
        {
            choose_direction = rnd2.Next(0, 2);
            if (choose_direction == 0)
            {
                if (_x > 0)
                    _x--;
                else
                    _x++;
            }
            else if (choose_direction == 1)
            {
                if (_x < _size - 1)
                    _x++;
                else
                    _x--;
            }

            _moves++;
        }
    }
 
    public class HardEnemy : Enemy
    {
        public override void calculateDifficulty(Create create)
        {
            _x = create.x;
            _size = create.length;
            _hp = 200;
            _moves = 0;
        }
    }
    public class EasyEnemy : Enemy
    {
        public override void calculateDifficulty(Create create)
        {
            _x = create.x;
            _size = create.length;
            _hp = 100;
            _moves = 0;
        }
    }

    public class EnemyProcessor
    {
        private Enemy taxProcessor;

        public EnemyProcessor(AbstractEnemy factory)
        {
            taxProcessor = factory.createDifficulty();
        }
        public Enemy processOrder(Create create)
        {
            taxProcessor.calculateDifficulty(create);

            return taxProcessor;
        }
    }
}

