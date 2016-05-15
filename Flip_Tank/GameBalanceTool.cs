using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Flip_Tank
{
    /// <summary>
    /// GameBalanceTool
    /// The Developer Tool for Flip Tank. Changes core game values and saves them to a file to be read by the game.
    /// William Montgomery
    /// </summary>
    public partial class GameBalanceTool : Form
    {
        Random rand; //Random to be used for randomizing spawn chances
        int waveNum; //integer to increment with each wave creation.  For use with creating file names

        public GameBalanceTool()
        {
            InitializeComponent();
        }

        private void GameBalanceTool_Load(object sender, EventArgs e)
        {
            rand = new Random();

            //Set TabStop's to allow controls to be tabbed to in the Form. NOT WORKING AS OF NOW.
            WaveGroup.TabStop = true;
            EnemySpawnGroup.TabStop = true;
            PlayerGroup.TabStop = true;
            waveNum = 0;

            //creates a directory for the waves files if none exists
            if (!Directory.Exists("bin/Debug/WaveCache"))
                Directory.CreateDirectory("bin/Debug/WaveCache");

            //sets the player value boxes to previous values if a player file exists
            if (File.Exists("bin/Debug/PlayerValues.dat"))
            {
                StreamReader sr = null;

                try
                {
                    sr = new StreamReader("bin/Debug/PlayerValues.dat");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error reading player file: " + ex.Message);
                    return;
                }

                HealthBox.Text = sr.ReadLine();
                SpeedBox.Text = sr.ReadLine();
                JumpBox.Text = sr.ReadLine();

                sr.Close();
            }
        }

        /// <summary>
        /// Generates random values for the enemy spawn chances
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandSpawnButton_Click(object sender, EventArgs e)
        {
            //Max and min values for calling random numbers. Can be changed easily from here
            const int MAX = 101;
            const int MIN = 0;

            //Set new values
            GroundChanceBox.Text = rand.Next(MIN, MAX).ToString();
            FlyerChanceBox.Text = rand.Next(MIN, MAX).ToString();
            SGroundChanceBox.Text = rand.Next(MIN, MAX).ToString();
            SFlyerChanceBox.Text = rand.Next(MIN, MAX).ToString();

            // set the new values into the wave
            //***code goes here***
        }

        /// <summary>
        /// Deletes the directory and clears out all wave files, then creates a new directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Directory.Delete("bin/Debug/WaveCache", true);

            if (!Directory.Exists("bin/Debug/WaveCache"))
                Directory.CreateDirectory("bin/Debug/WaveCache");
        }

        private void PlayerSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("bin/Debug/PlayerValues.dat");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error instantiating wave: " + ex.Message);
                return;
            }

            //Set player values
            sw.WriteLine(int.Parse(HealthBox.Text));
            sw.WriteLine(int.Parse(SpeedBox.Text));
            sw.WriteLine(int.Parse(JumpBox.Text));

            sw.Close();
        }

        /// <summary>
        /// Returns the Player Value Boxes to default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultPlayer_Click(object sender, EventArgs e)
        {
            HealthBox.Text = "100";
            SpeedBox.Text = "3";
            JumpBox.Text = "100";
        }

        /// <summary>
        /// Takes the input values from the user, writes them to the ToolValues file and then restarts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Send player to main menu to restart

            /*
            TEXT FILE FORMAT:
            
            Number of Enemies
            Number of Enemies on screen

            Ground Chance
            Flyer Chance
            Shielded Ground Chance
            Shielded Flyer Chance
            
            Health
            Speed
            Jump Height
            */



            //Get ready to write to file
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("bin/Debug/WaveCache/Wave" + waveNum + ".dat");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error instantiating wave: " + ex.Message);
                return;
            }

            //Write wave values
            sw.WriteLine(int.Parse(NumEnemiesBox.Text));
            sw.WriteLine(int.Parse(OnScreenBox.Text));

            //Write spawn chance values
            sw.WriteLine(int.Parse(GroundChanceBox.Text));
            sw.WriteLine(int.Parse(FlyerChanceBox.Text));
            sw.WriteLine(int.Parse(SGroundChanceBox.Text));
            sw.WriteLine(int.Parse(SFlyerChanceBox.Text));

            sw.Close();

            waveNum++;
        }
    }
}
