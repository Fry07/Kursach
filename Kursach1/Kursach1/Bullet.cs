using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Bullet
    {
        public int _x;
        public int _y;
        public int _direction;
        public int _border;
        public bool _exists;

        public Bullet(int x, int y, int direction, int border)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _exists = true;
            _border = border;
        }
        public void MoveBullet()
        {
            if (_direction > 0)
            {
                if (_y + _direction > _border - 1)
                    _exists = false;
            }
            else
            {
                if (_y + _direction < 0)
                    _exists = false;
            }

            _y += _direction;
        }
        public bool Collision(int y, int x)
        {
            if (y == _y && x == _x)
            {
                return true;
            }
            return false;
        }
    }
}
