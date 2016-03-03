using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flip_Tank
{
    /// <summary>
    /// Bullet that the player fires. Has a different texture than normal bullets
    /// </summary>
    class PlayerBullet : Bullet
    {
        //Not sure if I should even put anything else in this class

        public PlayerBullet()
        {
            base.Speed = 0; //TBD
        }
    }
}
