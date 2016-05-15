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
        int waveNumber;
        Random rgen;
        double flyChance; // chance of spawning flyer enemy
        double grndChance; // chance of spawing ground enemy
        double totalChance; // stores the total chance to divide each by
        int enemyNum;
        List<Enemy> enemyList;

        StreamWriter writeWaveValues;
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

        // constructor
        public Wave()
        {
            enemyList = new List<Enemy>();
            waveNumber = 0;
            rgen = new Random();
            
            flyChance = 50;
            grndChance = 50;

            writeWaveValues = new StreamWriter("CustomWave.txt");
            writeWaveValues.WriteLine("3");
            writeWaveValues.WriteLine(flyChance);
            writeWaveValues.WriteLine(grndChance);
            writeWaveValues.Close();
        }

        public void NewWave(string waveFile) // this is a custom wave method
        {
            readWaveValues = new StreamReader("CustomWave.txt");
            enemyNum = int.Parse(readWaveValues.ReadLine());
            flyChance = int.Parse(readWaveValues.ReadLine());
            grndChance = int.Parse(readWaveValues.ReadLine());
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
                enemyList.Add(new Flyer());
            }
            if (type.ToLower() == "ground")
            {
                enemyList.Add(new Ground());
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
                enemyList.Add(new Flyer());
            }
            if(spawnType >= trueFC && spawnType < trueFC + trueGC)
            {
                enemyList.Add(new Ground());
            }
        }
    }
}
