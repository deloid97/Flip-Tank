using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    //CURRENTLY NOT IN USE WILL DECIDE LATER IF A SEPERATE CLASS IS NECESSARY
    class Health
    {
        private int hp;
        private int damage;
        private int heal;
        public Texture2D healthSegment;
        //needs to be added to game1
        //Basic drawing still needs to be added to game1

        //Due to lack of compiler I can't tell where the healthbar
        //should be placed on the screen

        //simple loop for drawing the segments written here 
        //Place in draw() method
        /*

        for(int i = 0; i < player.Health; i++)
        {
            spriteBatch.Draw(healthTexture[i], ((pos.X + i*25), pos.Y), Color.White)
        }

        */

        //Setting the beginning health value
        public Health(int startHP)
        {
            if (startHP > 0)
            {
                hp = startHP;
            }
            else
            {
                hp = 10;
            }
        }

        //default constructor
        public Health()
        {
            hp = 10;
        }

        //if any other class needs health value
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        //methods for taking away and giving health
        public void TakeDamage()
        {
            hp = hp - 1;
        }
        public void Heal()
        {
            hp = hp + 1;
        }




    }
}