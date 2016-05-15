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

            //sets the player value boxes to previous values if a player file exists
            if (File.Exists("PlayerValues.txt"))
            {
                StreamReader sr = null;

                try
                {
                    sr = new StreamReader("PlayerValues.txt");
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
        }

        private void PlayerSave_Click(object sender, EventArgs e)
        {
            /*
            TEXT FILE FORMAT:

            Health
            Speed
            Jump
            */

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("PlayerValues.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error saving player values: " + ex.Message);
                return;
            }

            //Write player values
            sw.WriteLine(HealthBox.Text);
            sw.WriteLine(SpeedBox.Text);
            sw.WriteLine(JumpBox.Text);

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

            /*
            TEXT FILE FORMAT:
            
            Number of Enemies
            Number of Enemies on screen

            Ground Chance
            Flyer Chance
            */

            //Get ready to write to file
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("CustomWave.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error instantiating wave: " + ex.Message);
                return;
            }

            //Write general wave values
            sw.WriteLine(NumEnemiesBox.Text);
            sw.WriteLine(OnScreenBox.Text);

            //Write spawn chance values
            sw.WriteLine(GroundChanceBox.Text);
            sw.WriteLine(FlyerChanceBox.Text);

            sw.Close();
        }


        //Restarts the game
        private void RestartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
