using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    class Enemy
    {
        Rectangle position;

        //Property for enemy's position
        public Rectangle Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }
    }
}
