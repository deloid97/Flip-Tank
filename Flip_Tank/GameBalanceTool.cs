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


        }


        /// <summary>
        /// Takes the input values from the user, writes them to the ToolValues file and then restarts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, EventArgs e)
        {

            //Send player to main menu to restart

            /*
            TEXT FILE FORMAT:

            "Wave Values"
            Number of Enemies
            Number of Enemies on screen
            "Spawn Chances"
            Ground Chance
            Flyer Chance
            Shielded Ground Chance
            Shielded Flyer Chance
            "Player Values"
            Health
            Speed
            Jump Height
            */

            //Wipe all the data from the last time the game ran
            System.IO.File.WriteAllText("ToolValues.txt", string.Empty);

            //Get ready to write to file
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("ToolValues.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error instantiating stream: " + ex.Message);
                return;
            }

            //Write wave values
            sw.WriteLine("Wave Values"); //Header of section
            sw.WriteLine(NumEnemiesBox.Text);
            sw.WriteLine(OnScreenBox.Text);

            //Write spawn chance values
            sw.WriteLine("Spawn Chances"); //Header of section
            sw.WriteLine(GroundChanceBox.Text);
            sw.WriteLine(FlyerChanceBox.Text);
            sw.WriteLine(SGroundChanceBox.Text);
            sw.WriteLine(SFlyerChanceBox.Text);

            //Write player values
            sw.WriteLine("Player Values"); //Header of section
            sw.WriteLine(HealthBox.Text);
            sw.WriteLine(SpeedBox.Text);
            sw.WriteLine(JumpBox.Text);

            sw.Close(); //Close file

            Application.Restart(); //Restarts the application (BUT DOES NOT CLOSE THE OLDER MONOGAME WINDOW)

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
        }
    }
}
