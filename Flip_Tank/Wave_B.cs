using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Flip_Tank
{
    class Wave_B
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
        public Wave_B(Stream waveFile)
        {
            StreamReader streamReader = new StreamReader(waveFile);

            /*
            TEXT FILE FORMAT:
            
            Number of Enemies
            Number of Enemies on screen

            Ground Chance
            Flyer Chance
            Shielded Ground Chance
            Shielded Flyer Chance*/

            num = int.Parse(streamReader.ReadLine());
            onScreen = int.Parse(streamReader.ReadLine());
            ground = int.Parse(streamReader.ReadLine());
            flyer = int.Parse(streamReader.ReadLine());
            grndShld = int.Parse(streamReader.ReadLine());
            flyShld = int.Parse(streamReader.ReadLine());

            rng = new Random();
            activate = false;
           
            waveRoster = new Enemy[this.num];
            enemyType = new EType[this.num];

            //integers used in calculating spawn chance
            int chance1 = ground;
            int chance2 = chance1 + flyer;
            int chance3 = chance2 + grndShld;
            int chance4 = chance3 + flyShld;
            
            //loop builds the enemy wave
            for (int i = 0; i < waveRoster.Length; i++)
            {
                int chance = rng.Next(chance4);

                if (chance < chance1 && chance >= 0)
                {
                    waveRoster[i] = new Ground();
                    enemyType[i] = EType.Ground;
                }
                if (chance < chance2 && chance >= chance1)
                {
                    waveRoster[i] = new Flyer();
                    enemyType[i] = EType.Flyer;
                }
                if (chance < chance3 && chance >= chance2)
                {
                    waveRoster[i] = new GroundShield();
                    enemyType[i] = EType.GroundShield;
                }
                if (chance < chance4 && chance >= chance3)
                {
                    waveRoster[i] = new FlyerShield();
                    enemyType[i] = EType.FlyerShield;
                }
            }
        }

        enum EType { Ground, Flyer, GroundShield, FlyerShield }; //enum for enemy types used in casting enemies from the waveRoster array

        private int num;
        private int ground;
        private int flyer;
        private int grndShld;
        private int flyShld;
        private int onScreen;

        private Random rng;
        private Enemy[] waveRoster; //stores all the enemies in the wave
        private EType[] enemyType; //store the type of enemy in waveRoster for use of casting

        private bool activate; //controls whether the wave is allowed to spawn in enemies
        public bool Activate
        {
            get { return activate; }
        }

        public void BeginWave() //initiates Wave and allows enemies to spawn
        {
            activate = true;
        }

        public void EndWave() //ends the wave and deactivates all of wave's enemies
        {
            activate = false;
            for(int i = 0; i < waveRoster.Length; i++)
            {
              //  waveRoster[i].Deactivate();
            }
        }

        public void Spawn() //spawns enemies if wave is active and there is are fewer enemies than the allowed amount
        {
           // if(Activate && /*condition to check if enemies active is fewer than int OnScreen*/)
        }
    }
}
