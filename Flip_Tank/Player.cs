﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Flip_Tank
{
    class Player
    {
        //attributes and properties
        public Rectangle position;  //where player is on the screen
        public Texture2D playerTexture;
        public Texture2D bulletTexture;
        public Texture2D healthSegment; //A segment of the player's health

        public bool spawnBullet = false;
        public Rectangle bulletPosition = new Rectangle(0, 0, 10, 10);

        int speed; //Speed player can move left and right
        int jumpHeight; //Height player jumps
        int maxHealth; //The player's max health
        int health; //The player's current health

        const int HEALTH_START_X = 25; //Offset for first health segment
        Rectangle healthRec = new Rectangle(HEALTH_START_X, 420, 25, 30); //Starting location of the first health segment

        int groundHeight; //Height when player is sitting on ground
        const double gravAcceleration = 0.1; //Acceleration due to virtual gravity
        int fallSpeed; //Current falling speed to be increased by gravity
        int framesFalling; //Number of frames player has been falling

        enum state {jump, shoot };   //players current action
        enum height { ground, air };
        height hgt = height.ground; //player starts at ground level
        state move;

        public Rectangle Position
        {
            get { return position; }
            set { }
        }
        public Texture2D Texture
        {
            get { return playerTexture; }
            set { }
        }
        public bool SpawnBullet
        {
            get { return spawnBullet; }
            set { }
        }

        public Texture2D HealthSegment
        {
            get
            {
                return healthSegment;
            }

            set { }
        }

        //parameterized constructors
        public Player(int x, int y, int width, int height)
        {
            position.X = x;
            position.Y = y;
            position.Width = width;
            position.Height = height;
            groundHeight = y;

            //Current default values
            speed = 2;
            jumpHeight = 50;
            maxHealth = 100;

            if (Game1.DEVMODE)
            {
                //Run method that reads text file to replace player values
                ReadFile();
            }

            health = maxHealth; //Set health to whatever the max is to start

        }

        //methods
        public void Movement()  //Determines player movement state to be used in Game1 Update()
        {
            KeyboardState input = Keyboard.GetState();

            

            if (hgt == height.ground)   //can't shoot unless jumping
            {
                spawnBullet = false;
            }
            else if(move == state.jump)
            {
                Jump();
            }
            else //If player is off ground and done jumping start falling
            {
                Fall();
            }


            if (input.IsKeyDown(Keys.A) == true)
            {
                position.X = position.X - speed;
            }
            if (input.IsKeyDown(Keys.D) == true)
            {
                position.X = position.X + speed;
            }
            if (input.IsKeyDown(Keys.Space) == true)    //will be changed to single key press
            {
                //Don't let the tank continue going up into the air
                if (hgt != height.air)
                {
                    position.Y = position.Y - jumpHeight;
                }

                hgt = height.air;
                //flipping method added here
                //if flip is completed without shooting, hgt = height.ground
            }
            
            
            //Pressing 'S' doesn't work with gravity will uncomment if game requires it
            /*if (input.IsKeyDown(Keys.S) == true && hgt == height.air)   //key may be changed to space
            {
                spawnBullet = true;
                position.Y = position.Y + 10; //will be removed after flip, for testing purposes only
                hgt = height.ground;
            }*/

        }

        public void Shoot() //sets bullet coordinates to above tank, will be changed when flipping
        {
            bulletPosition.X = position.X;
            bulletPosition.Y = bulletPosition.Y - 100;
        }

        //Deals damage to the player by a set amount
        public void TakeDamage(int damage)
        {
            health = health - damage;
        }

        //Heals the player by a set amount
        public void Heal(int healAmt)
        {
            health = health + healAmt;
        }

        //Brings tank back to the ground after a jump. Will most likely be heavily altered when flip is finished.
        private void Fall()
        {

            //If the distance between the player and the ground is less than the previous ground speed then just place player on ground.
            //Prevents clipping through ground
            if (position.Y + fallSpeed >= groundHeight)
            {
                position.Y = groundHeight;
                hgt = height.ground;
            }

            //If the player is in the air after a jump
            if (hgt == height.air)
            {
                framesFalling++; //This test is run every frame so if it comes into here another frame has passed
                fallSpeed = (int)(Math.Ceiling(gravAcceleration * framesFalling)); //Calculate current speed based on acceleration factor and time passed
                position.Y = position.Y + (fallSpeed);
            }
            else //Reset falling speed and falling frames if player is on the ground
            {
                fallSpeed = 0;
                framesFalling = 0;
            }
        }

        //Logic for moving the player up for a jump 
        private void Jump()
        {
            
        }


        //Draws the player health on the screen (code from Tom's health class)
        //Currently looks awful, going to have to change it
        public void DrawHealth(SpriteBatch spriteBatch)
        {
            //Don't draw if health is below or equal to zero
            if(health <= 0)
            {
                return;
            }

            int segmentValue = maxHealth / 5; //5 segments of health. This may be changed.

            //Avoids a divide by zero error. If there are zero health segments just return
            if (segmentValue == 0)
            {
                return;
            }

            int numSegments = health / segmentValue; //Number of segments to be drawn



            //Draw bars until the current health is reached by incrementing i by the segment amount
            for (int i = 0; i < numSegments; i++)
            {
                spriteBatch.Draw(healthSegment, new Rectangle((healthRec.X * i) + HEALTH_START_X, healthRec.Y, healthRec.Width, healthRec.Height), Color.White);
            }
        }
    


    //Reads file generated by Development tool to change player values 
    //May be updated to be more efficient
    private void ReadFile()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader("ToolValues.txt");
            bool onSection = false; //Tells whether or not file is on the player section yet
            int sectionLine = 0; //Line within the correct section

            while (true) //NOT AN INFINITE LOOP. Made so that the current line is reliable and no lines are skipped by calling ReadLine multiple times
            {
                string currString = sr.ReadLine();
                if(currString != null)
                {
                      if (onSection)
                      {
                          sectionLine++;
                       
                          switch (sectionLine)
                          {
                              case 1:
                                  maxHealth = int.Parse(currString);
                                  break;
                              case 2:
                                  speed = int.Parse(currString);
                                  break;
                              case 3:
                                  jumpHeight = int.Parse(currString);
                                  break;
                           }
                      }

                      if (currString == "Player Values")
                      {
                          onSection = true;
                      }
               }
              else
              {
                  break;
              }
          }
               sr.Close();
        }
        catch (FileNotFoundException fnfe)
        {
            return; //If there's a file not found exception the tool is running for the first time and therefore no values will be changed
        }
        catch (IOException ioe)
        {
            Console.WriteLine("IO error: " + ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured while reading file:" + e.Message);
        }

    }

    }
}