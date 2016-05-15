using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Flip_Tank
{
    class Wave
    {
        // attributes
        List<Enemy> waveList;
        int waveNumber;
        Random rgen;
        double flyChance; // chance of spawning flyer enemy
        double grndChance; // chance of spawing ground enemy
        double totalChance; // stores the total chance to divide each by

        StreamWriter waveValues;

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

        public List<Enemy> WaveList
        {
            get { return waveList; }
        }

        public int WaveNumber
        {
            get { return waveNumber; }
        }

        // constructor
        public Wave()
        {
            waveNumber = 0;
            rgen = new Random();
            waveList = new List<Enemy>();

            
            flyChance = 50;
            grndChance = 50;

            waveValues = new StreamWriter("CustomWave.txt");
            waveValues.WriteLine("3");
            waveValues.WriteLine(flyChance);
            waveValues.WriteLine(grndChance);
        }

        public void NewWave(int enemyNum, double flyChn, double grndChn) // this is a custom wave method
        {
            waveList.Clear();
            flyChance = flyChn;
            grndChance = grndChn;
            totalChance = flyChance + grndChance;
            
            // spawns in the specified number of enemies
            for(int i = 0; i < enemyNum; i++)
            {
                SpawnEnemy();
            }
        }
        
        public void NewWave(int waveNum) // this is the method for each wave
        {
            // set algorithym to spawn enemies
            WaveList.Clear();
            waveNumber = waveNum;

            // spawns 2 extra enemies per wave with the first one starting with 3 enemies
            SpawnEnemy(); SpawnEnemy(); SpawnEnemy();
            for(int i = 1; i < waveNumber; i++) { SpawnEnemy(); SpawnEnemy(); }
        }

        // spawns a specific type of enemy
        public void SpawnEnemy(string type)
        {
            if(type.ToLower() == "flyer")
            {
                waveList.Add(new Flyer());
            }
            if (type.ToLower() == "ground")
            {
                waveList.Add(new Ground());
            }
        }

        // spawns a random enemy
        public void SpawnEnemy()
        {
            // get percentages out of 100
            int spawnType = rgen.Next(100);
            double trueFC = flyChance / totalChance * 100;
            double trueGC = grndChance / totalChance * 100;

            // spawn an enemy depending on the on the rgen result
            if(spawnType >= 0 && spawnType < trueFC)
            {
                waveList.Add(new Flyer());
            }
            if(spawnType >= trueFC && spawnType < trueFC + trueGC)
            {
                waveList.Add(new Ground());
            }
        }
    }
}
