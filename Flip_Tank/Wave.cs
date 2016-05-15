using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Flip_Tank
{
    class Wave
    {
        //Constant ints for default values
        const int FLY_CHANCE_DEFAULT = 50;
        const int GROUND_CHANCE_DEFAULT = 50;
        const int MAX_ENEMIES_ON_SCREEN_DEFAULT = 5;
        const int ENEMY_NUM_DEFAULT = 3;

        // attributes
        int waveNumber;
        int maxEnemiesOnScreen;

        Random rgen;
        double flyChance; // chance of spawning flyer enemy
        double grndChance; // chance of spawing ground enemy
        double totalChance; // stores the total chance to divide each by
        int enemyNum; //Total number of enemies in this wave
        List<Enemy> enemyList;

        StreamReader sr;
        StreamReader readWaveValues;

        // properties
        public double FlyChance
        {
            get { return flyChance / totalChance; }

            set { flyChance = value; totalChance = flyChance + grndChance; }
        }

        public double GroundChance
        {
            get { return grndChance / totalChance; }

            set { grndChance = value; totalChance = flyChance + grndChance; }
        }

        public int WaveNumber
        {
            get { return waveNumber; }
        }

        public List<Enemy> EnemyList
        {
            get { return enemyList; }
        }

        public int MaxEnemiesOnScreen
        {
            get
            {
                return maxEnemiesOnScreen;
            }
        }

        // constructor
        public Wave()
        {
            //Read the custom wave file as the first wave if we are in Dev Mode
            if(Game1.DEVMODE)
            {
                try
                {
                    sr = new StreamReader("CustomWave.txt");

                    int.TryParse(sr.ReadLine(), out enemyNum);
                    int.TryParse(sr.ReadLine(), out maxEnemiesOnScreen);

                    //Have to parse int to avoid error so use temporary ints to store variables meant for doubles
                    int tempGrnd;
                    int tempFly;

                    int.TryParse(sr.ReadLine(), out tempGrnd);
                    int.TryParse(sr.ReadLine(), out tempFly);

                    //Convert temporary ints to doubles
                    grndChance = (double)tempGrnd;
                    flyChance = (double)tempFly;

                    totalChance = flyChance + grndChance;

                    sr.Close();
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine("Error occured locating file:" + fnfe.Message);
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
            else //If not in dev mode use current default values
            {
                enemyNum = ENEMY_NUM_DEFAULT;
                flyChance = FLY_CHANCE_DEFAULT;
                grndChance = GROUND_CHANCE_DEFAULT;
                totalChance = flyChance + grndChance;
            }

            //SPECIAL CASE: If the file was attempted to be read and something went wrong
            if(enemyNum == 0 || flyChance == 0 || grndChance == 0)
            {
                enemyNum = ENEMY_NUM_DEFAULT;
                flyChance = FLY_CHANCE_DEFAULT;
                grndChance = GROUND_CHANCE_DEFAULT;
                totalChance = flyChance + grndChance;
            }


            //Initalize other wave variables
            enemyList = new List<Enemy>();
            waveNumber = 1;
            rgen = new Random();

            //Add first waves enemies to the list
            for(int i = 0; i < enemyNum; i++)
            {
                AddEnemy();
            }
        }

        /* Not sure if this will be used
        public void NewWave(string waveFile) // this is a custom wave method
        {     
            // spawns in the specified number of enemies
            for(int i = 0; i < enemyNum; i++)
            {
                AddEnemy();
            }
        }
        */
        
        //Called by Game class to make a new wave when the last one is over
        public void NewWave() // this is the method for each wave
        {
           //Clear enemy list for new wave
            enemyList.Clear();

            // spawns 2 extra enemies each time a new wave is made
            enemyNum = enemyNum + 2;

            //Add a number of enemies equal to enemyNum
            for(int i = 0; i < enemyNum; i++) { AddEnemy(); }

            //Every 10 waves increment the number of enemies allowed on screen
            if((waveNumber + 1) % 10 == 0)
            {
                maxEnemiesOnScreen++;
            }

            //Increment the wave number
            waveNumber++;
        }

        // spawns a specific type of enemy
        public void AddEnemy(string type)
        {
            if(type.ToLower() == "flyer")
            {
                enemyList.Add(new Flyer());
            }
            if (type.ToLower() == "ground")
            {
                enemyList.Add(new Ground());
            }
        }

        // spawns a random enemy
        public void AddEnemy()
        {
            // get percentages out of 100
            int spawnType = rgen.Next(100);
            double trueFC = flyChance / totalChance * 100;
            double trueGC = grndChance / totalChance * 100;

            // spawn an enemy depending on the on the rgen result
            if(spawnType >= 0 && spawnType < trueFC)
            {
                enemyList.Add(new Flyer());
            }
            if(spawnType >= trueFC && spawnType < trueFC + trueGC)
            {
                enemyList.Add(new Ground());
            }
        }
    }
}
