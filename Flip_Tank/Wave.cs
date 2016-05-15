using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flip_Tank
{
    class Wave
    {
        // attributes
        List<Enemy> waveList;
        int wave;
        Random rgen;
        double flyChance; // chance of spawning flyer enemy
        double grndChance; // chance of spawing ground enemy
        double flyShldChance; // chance of spawning shielded flyer enemy
        double grndShldChance; // chance of spawing shielded ground enemy
        double totalChance; // stores the total chance to divide each by

        // properties
        public double FlyChance
        {
            get { return flyChance / totalChance; }

            set { flyChance = value; totalChance = flyChance + grndChance + flyShldChance + grndShldChance; }
        }

        public double GroundChance
        {
            get { return grndChance / totalChance; }

            set { grndChance = value; totalChance = flyChance + grndChance + flyShldChance + grndShldChance; }
        }

        public double FlyShieldChance
        {
            get { return flyShldChance / totalChance; }

            set { flyShldChance = value; totalChance = flyChance + grndChance + flyShldChance + grndShldChance; }
        }

        public double GroundShieldChance
        {
            get { return grndShldChance / totalChance; }

            set { grndShldChance = value; totalChance = flyChance + grndChance + flyShldChance + grndShldChance; }
        }

        public List<Enemy> WaveList
        {
            get { return waveList; }
        }

        public Wave()
        {
            wave = 0;
            rgen = new Random();
            waveList = new List<Enemy>();

            flyChance = 25;
            grndChance = 25;
            flyShldChance = 25;
            grndShldChance = 25;
        }

        public void NewWave(int waveNum, int enemyNum, double flyChn, double grndChn, double flyShldChn, double grndShldChn)
        {

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
            if (type.ToLower() == "shield")
            {
                waveList.Add(new FlyerShield());
            }
            if (type.ToLower() == "groundshield")
            {
                waveList.Add(new GroundShield());
            }
        }

        // spawns a random enemy
        public void SpawnEnemy()
        {
            int spawnType = rgen.Next(100);
            double trueFC = flyChance / totalChance * 100;
            double trueGC = grndChance / totalChance * 100;
            double trueFSC = flyShldChance / totalChance * 100;
            double trueGSC = grndShldChance / totalChance * 100;

            if(spawnType >= 0 && spawnType < trueFC)
            {
                waveList.Add(new Flyer());
            }
            if(spawnType >= trueFC && spawnType < trueFC + trueGC)
            {
                waveList.Add(new Ground());
            }
            if (spawnType >= trueFC + trueGC && spawnType < trueFC + trueGC + trueFSC)
            {
                waveList.Add(new FlyerShield());
            }
            if (spawnType >= trueFC + trueGC + trueFSC && spawnType < trueFC + trueGC + trueFSC + trueGSC)
            {
                waveList.Add(new GroundShield());
            }
        }
    }
}
