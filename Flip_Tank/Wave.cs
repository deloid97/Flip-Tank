using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flip_Tank
{
    class Wave
    {
        /// <summary>
        /// Designs and controls an enemy wave based on developer-set spawn chances, waves sizes, and 
        /// </summary>
        /// <param name="num">Number of enemies in the wave</param>
        /// <param name="ground">percentage chance of spawning a normal ground enemy</param>
        /// <param name="flyer">percentage chance of spawning a normal flyer enemy</param>
        /// <param name="grndShld">percentage chance of spawning a shielded ground enemy</param>
        /// <param name="flyShld">percentage chance of spawning a shielded flyer enemy</param>
        /// <param name="onScreen">Number of enemies allowed to be active at a given time</param>
        public Wave(int num, int ground, int flyer, int grndShld, int flyShld, int onScreen)
        {
            this.num = num;
            this.ground = ground;
            this.flyer = flyer;
            this.grndShld = grndShld;
            this.flyShld = flyShld;
            this.onScreen = onScreen;
            rng = new Random();
            waveRoster = new Enemy[this.num];

            //integers used in calculating spawn chance
            int chance1 = ground;
            int chance2 = chance1 + flyer;
            int chance3 = chance2 + grndShld;
            int chance4 = chance3 + flyShld;
            
            //loop builds the enemy wave
            for (int i = 0; i < WaveRoster.Length; i++)
            {
                int chance = rng.Next(chance4);

                if (chance < chance1 && chance >= 0)
                    WaveRoster[i] = new Ground();
                if (chance < chance2 && chance >= chance1)
                    WaveRoster[i] = new Flyer();
                if (chance < chance3 && chance >= chance2)
                    WaveRoster[i] = new GroundShield();
                if (chance < chance4 && chance >= chance3)
                    WaveRoster[i] = new FlyerShield();
            }
        }

        private int num;
        private int ground;
        private int flyer;
        private int grndShld;
        private int flyShld;
        private int onScreen;
        private Random rng;
        Enemy[] waveRoster; //stores all the enemies in the wave

        //Property for the WaveRoster so that methods for each enemy can be called in the Game
        public Enemy[] WaveRoster
        {
            get
            {
                return waveRoster;
            }
        }
    }
}
