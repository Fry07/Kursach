using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursach1
{
    public class Proxy : Abst_Player
    {
        Abst_Player _player;

        int _length;

        public Proxy(Abst_Player player, int length)
        {
            _player = player;
            _length = length;
        }
        public override void MovePlayerLeft()
        {
            if (_player.player_x > 0)
            {
                _player.MovePlayerLeft();
            }
        }
        public override void MovePlayerRight()
        {
            if (_player.player_x < _length - 1)
            {
                _player.MovePlayerRight();
            }
        }
    }
}