using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    class PlayerBullet : Bullet
    {
        //Constructs a Player Bullet
        public PlayerBullet(Rectangle locRec):base(locRec)
        {

        }

        //Overrides the bullet draw to draw a white bullet
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Location, Color.White);
        }

    }
}
