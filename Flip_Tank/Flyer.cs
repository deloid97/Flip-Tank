using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    class Flyer : Enemy
    {
        //The default values for the bullet position of this enemy
        int defaultBulletX;
        int defaultBulletY;

        public Flyer() : base()
        {
            //Set up starting values for a flyer
            Speed = 3;
            orient = orientation.normal;
            Position = new Rectangle(0, 0, 200, 34);
            BulletPosition = new Rectangle(139, 22, 20, 20); //Most likely will change depending on how bullet looks

            defaultBulletX = BulletPosition.X;
            defaultBulletY = BulletPosition.Y;

            BulletSpeed = 4;

            IsActive = true;
        }

        public new void Move()
        {
            //Move the enemy generically first
            base.Move();

            //Then update the bullet position according to the flyer's orientation
            if(orient == orientation.normal)
            {
                BulletPosition = new Rectangle(
                    Position.X + defaultBulletX, 
                    Position.Y + defaultBulletY, 
                    BulletPosition.Width, 
                    BulletPosition.Height
                    );
            }
            else
            {
                BulletPosition = new Rectangle(
                    Position.X + (Position.Width - defaultBulletX), //When flipped the bullet position is the difference of the width/height and the default bullet position X/Y
                    Position.Y + (Position.Height - defaultBulletY),
                    BulletPosition.Width,
                    BulletPosition.Height
                    );
            }

        }
    }
}
