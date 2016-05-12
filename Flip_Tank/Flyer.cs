using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    class Flyer : Enemy
    {
        //The default values for the bullet position of this enemy
        int defaultBulletX;
        int defaultBulletY;

        int scaleFactor; //Scales the size of the Flyer down by this amount

        public Flyer() : base()
        {
            //Set up starting values for a flyer
            Speed = 2;
            ShotCoolDown = 60;

            orient = orientation.normal;


            scaleFactor = 6;
            Position = new Rectangle(0, 0, 600/scaleFactor, 268/scaleFactor);
            BulletPosition = new Rectangle(448/6, 185/6, 10, 10);

            defaultBulletX = BulletPosition.X;
            defaultBulletY = BulletPosition.Y;

            BulletSpeed = 4;

            IsActive = true;
        }


        //Overriden Move to work with the flyer's bullets
        public override void Move()
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
