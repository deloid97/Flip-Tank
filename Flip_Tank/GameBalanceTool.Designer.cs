namespace Flip_Tank
{
    partial class GameBalanceTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WaveGroup = new System.Windows.Forms.GroupBox();
            this.OnScreenBox = new System.Windows.Forms.MaskedTextBox();
            this.LabelOnScreen = new System.Windows.Forms.Label();
            this.LabelNumEnemy = new System.Windows.Forms.Label();
            this.NumEnemiesBox = new System.Windows.Forms.MaskedTextBox();
            this.LabelFlyer = new System.Windows.Forms.Label();
            this.LabelGround = new System.Windows.Forms.Label();
            this.EnemySpawnGroup = new System.Windows.Forms.GroupBox();
            this.FlyerChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.GroundChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.RandSpawnButton = new System.Windows.Forms.Button();
            this.PlayerGroup = new System.Windows.Forms.GroupBox();
            this.JumpBox = new System.Windows.Forms.MaskedTextBox();
            this.SpeedBox = new System.Windows.Forms.MaskedTextBox();
            this.HealthBox = new System.Windows.Forms.MaskedTextBox();
            this.LabelJump = new System.Windows.Forms.Label();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.LabelHealth = new System.Windows.Forms.Label();
            this.PlayerSave = new System.Windows.Forms.Button();
            this.DefaultPlayer = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.WaveGroup.SuspendLayout();
            this.EnemySpawnGroup.SuspendLayout();
            this.PlayerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // WaveGroup
            // 
            this.WaveGroup.Controls.Add(this.OnScreenBox);
            this.WaveGroup.Controls.Add(this.LabelOnScreen);
            this.WaveGroup.Controls.Add(this.LabelNumEnemy);
            this.WaveGroup.Controls.Add(this.NumEnemiesBox);
            this.WaveGroup.Location = new System.Drawing.Point(12, 5);
            this.WaveGroup.Name = "WaveGroup";
            this.WaveGroup.Size = new System.Drawing.Size(150, 141);
            this.WaveGroup.TabIndex = 0;
            this.WaveGroup.TabStop = false;
            this.WaveGroup.Text = "Wave Values";
            // 
            // OnScreenBox
            // 
            this.OnScreenBox.Location = new System.Drawing.Point(11, 109);
            this.OnScreenBox.Mask = "00000";
            this.OnScreenBox.Name = "OnScreenBox";
            this.OnScreenBox.Size = new System.Drawing.Size(100, 20);
            this.OnScreenBox.TabIndex = 3;
            this.OnScreenBox.Text = "5";
            this.OnScreenBox.ValidatingType = typeof(int);
            // 
            // LabelOnScreen
            // 
            this.LabelOnScreen.AutoSize = true;
            this.LabelOnScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOnScreen.Location = new System.Drawing.Point(6, 90);
            this.LabelOnScreen.Name = "LabelOnScreen";
            this.LabelOnScreen.Size = new System.Drawing.Size(97, 16);
            this.LabelOnScreen.TabIndex = 2;
            this.LabelOnScreen.Text = "Max on Screen";
            // 
            // LabelNumEnemy
            // 
            this.LabelNumEnemy.AutoSize = true;
            this.LabelNumEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNumEnemy.Location = new System.Drawing.Point(6, 28);
            this.LabelNumEnemy.Name = "LabelNumEnemy";
            this.LabelNumEnemy.Size = new System.Drawing.Size(85, 16);
            this.LabelNumEnemy.TabIndex = 0;
            this.LabelNumEnemy.Text = "# of Enemies";
            // 
            // NumEnemiesBox
            // 
            this.NumEnemiesBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NumEnemiesBox.Location = new System.Drawing.Point(9, 47);
            this.NumEnemiesBox.Mask = "00000";
            this.NumEnemiesBox.Name = "NumEnemiesBox";
            this.NumEnemiesBox.Size = new System.Drawing.Size(100, 20);
            this.NumEnemiesBox.TabIndex = 1;
            this.NumEnemiesBox.Text = "3";
            this.NumEnemiesBox.ValidatingType = typeof(int);
            // 
            // LabelFlyer
            // 
            this.LabelFlyer.AutoSize = true;
            this.LabelFlyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFlyer.Location = new System.Drawing.Point(6, 90);
            this.LabelFlyer.Name = "LabelFlyer";
            this.LabelFlyer.Size = new System.Drawing.Size(87, 16);
            this.LabelFlyer.TabIndex = 2;
            this.LabelFlyer.Text = "Flyer Chance";
            // 
            // LabelGround
            // 
            this.LabelGround.AutoSize = true;
            this.LabelGround.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGround.Location = new System.Drawing.Point(3, 28);
            this.LabelGround.Name = "LabelGround";
            this.LabelGround.Size = new System.Drawing.Size(101, 16);
            this.LabelGround.TabIndex = 0;
            this.LabelGround.Text = "Ground Chance";
            // 
            // EnemySpawnGroup
            // 
            this.EnemySpawnGroup.Controls.Add(this.FlyerChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.GroundChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.LabelGround);
            this.EnemySpawnGroup.Controls.Add(this.LabelFlyer);
            this.EnemySpawnGroup.Location = new System.Drawing.Point(168, 5);
            this.EnemySpawnGroup.Name = "EnemySpawnGroup";
            this.EnemySpawnGroup.Size = new System.Drawing.Size(138, 141);
            this.EnemySpawnGroup.TabIndex = 1;
            this.EnemySpawnGroup.TabStop = false;
            this.EnemySpawnGroup.Text = "Enemy Spawn Chance";
            // 
            // FlyerChanceBox
            // 
            this.FlyerChanceBox.Location = new System.Drawing.Point(6, 109);
            this.FlyerChanceBox.Mask = "00000";
            this.FlyerChanceBox.Name = "FlyerChanceBox";
            this.FlyerChanceBox.Size = new System.Drawing.Size(100, 20);
            this.FlyerChanceBox.TabIndex = 3;
            this.FlyerChanceBox.Text = "50";
            this.FlyerChanceBox.ValidatingType = typeof(int);
            // 
            // GroundChanceBox
            // 
            this.GroundChanceBox.Location = new System.Drawing.Point(6, 47);
            this.GroundChanceBox.Mask = "00000";
            this.GroundChanceBox.Name = "GroundChanceBox";
            this.GroundChanceBox.Size = new System.Drawing.Size(100, 20);
            this.GroundChanceBox.TabIndex = 1;
            this.GroundChanceBox.Text = "50";
            this.GroundChanceBox.ValidatingType = typeof(int);
            // 
            // RandSpawnButton
            // 
            this.RandSpawnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandSpawnButton.Location = new System.Drawing.Point(355, 89);
            this.RandSpawnButton.Name = "RandSpawnButton";
            this.RandSpawnButton.Size = new System.Drawing.Size(119, 57);
            this.RandSpawnButton.TabIndex = 3;
            this.RandSpawnButton.Text = "Randomize Spawn Chances";
            this.RandSpawnButton.UseVisualStyleBackColor = true;
            this.RandSpawnButton.Click += new System.EventHandler(this.RandSpawnButton_Click);
            // 
            // PlayerGroup
            // 
            this.PlayerGroup.Controls.Add(this.JumpBox);
            this.PlayerGroup.Controls.Add(this.SpeedBox);
            this.PlayerGroup.Controls.Add(this.HealthBox);
            this.PlayerGroup.Controls.Add(this.LabelJump);
            this.PlayerGroup.Controls.Add(this.LabelSpeed);
            this.PlayerGroup.Controls.Add(this.LabelHealth);
            this.PlayerGroup.Location = new System.Drawing.Point(12, 158);
            this.PlayerGroup.Name = "PlayerGroup";
            this.PlayerGroup.Size = new System.Drawing.Size(307, 136);
            this.PlayerGroup.TabIndex = 2;
            this.PlayerGroup.TabStop = false;
            this.PlayerGroup.Text = "Player Values";
            // 
            // JumpBox
            // 
            this.JumpBox.Location = new System.Drawing.Point(207, 96);
            this.JumpBox.Mask = "00000";
            this.JumpBox.Name = "JumpBox";
            this.JumpBox.Size = new System.Drawing.Size(100, 20);
            this.JumpBox.TabIndex = 5;
            this.JumpBox.Text = "100";
            this.JumpBox.ValidatingType = typeof(int);
            // 
            // SpeedBox
            // 
            this.SpeedBox.Location = new System.Drawing.Point(92, 62);
            this.SpeedBox.Mask = "00000";
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(100, 20);
            this.SpeedBox.TabIndex = 3;
            this.SpeedBox.Text = "3";
            this.SpeedBox.ValidatingType = typeof(int);
            // 
            // HealthBox
            // 
            this.HealthBox.Location = new System.Drawing.Point(92, 30);
            this.HealthBox.Mask = "00000";
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(100, 20);
            this.HealthBox.TabIndex = 1;
            this.HealthBox.Text = "100";
            this.HealthBox.ValidatingType = typeof(int);
            // 
            // LabelJump
            // 
            this.LabelJump.AutoSize = true;
            this.LabelJump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelJump.Location = new System.Drawing.Point(0, 97);
            this.LabelJump.Name = "LabelJump";
            this.LabelJump.Size = new System.Drawing.Size(207, 15);
            this.LabelJump.TabIndex = 4;
            this.LabelJump.Text = "Distance from to Origin to Flip Height";
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.AutoSize = true;
            this.LabelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSpeed.Location = new System.Drawing.Point(6, 63);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(49, 16);
            this.LabelSpeed.TabIndex = 2;
            this.LabelSpeed.Text = "Speed";
            // 
            // LabelHealth
            // 
            this.LabelHealth.AutoSize = true;
            this.LabelHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHealth.Location = new System.Drawing.Point(6, 30);
            this.LabelHealth.Name = "LabelHealth";
            this.LabelHealth.Size = new System.Drawing.Size(47, 16);
            this.LabelHealth.TabIndex = 0;
            this.LabelHealth.Text = "Health";
            // 
            // PlayerSave
            // 
            this.PlayerSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerSave.Location = new System.Drawing.Point(355, 174);
            this.PlayerSave.Name = "PlayerSave";
            this.PlayerSave.Size = new System.Drawing.Size(119, 46);
            this.PlayerSave.TabIndex = 6;
            this.PlayerSave.Text = "Save New Player Values";
            this.PlayerSave.UseVisualStyleBackColor = true;
            this.PlayerSave.Click += new System.EventHandler(this.PlayerSave_Click);
            // 
            // DefaultPlayer
            // 
            this.DefaultPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultPlayer.Location = new System.Drawing.Point(355, 244);
            this.DefaultPlayer.Name = "DefaultPlayer";
            this.DefaultPlayer.Size = new System.Drawing.Size(119, 50);
            this.DefaultPlayer.TabIndex = 7;
            this.DefaultPlayer.Text = "Default Player Values";
            this.DefaultPlayer.UseVisualStyleBackColor = true;
            this.DefaultPlayer.Click += new System.EventHandler(this.DefaultPlayer_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(355, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(119, 54);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save New Wave";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(219, 326);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(113, 50);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Restart Game";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // GameBalanceTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 388);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DefaultPlayer);
            this.Controls.Add(this.PlayerSave);
            this.Controls.Add(this.PlayerGroup);
            this.Controls.Add(this.RandSpawnButton);
            this.Controls.Add(this.EnemySpawnGroup);
            this.Controls.Add(this.WaveGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameBalanceTool";
            this.Text = "Game Balance Tool";
            this.Load += new System.EventHandler(this.GameBalanceTool_Load);
            this.WaveGroup.ResumeLayout(false);
            this.WaveGroup.PerformLayout();
            this.EnemySpawnGroup.ResumeLayout(false);
            this.EnemySpawnGroup.PerformLayout();
            this.PlayerGroup.ResumeLayout(false);
            this.PlayerGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox WaveGroup;
        private System.Windows.Forms.Label LabelFlyer;
        private System.Windows.Forms.Label LabelGround;
        private System.Windows.Forms.Label LabelOnScreen;
        private System.Windows.Forms.Label LabelNumEnemy;
        private System.Windows.Forms.GroupBox EnemySpawnGroup;
        private System.Windows.Forms.Button RandSpawnButton;
        private System.Windows.Forms.GroupBox PlayerGroup;
        private System.Windows.Forms.MaskedTextBox FlyerChanceBox;
        private System.Windows.Forms.MaskedTextBox GroundChanceBox;
        private System.Windows.Forms.MaskedTextBox OnScreenBox;
        private System.Windows.Forms.MaskedTextBox NumEnemiesBox;
        private System.Windows.Forms.MaskedTextBox JumpBox;
        private System.Windows.Forms.MaskedTextBox SpeedBox;
        private System.Windows.Forms.MaskedTextBox HealthBox;
        private System.Windows.Forms.Label LabelJump;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.Label LabelHealth;
        private System.Windows.Forms.Button PlayerSave;
        private System.Windows.Forms.Button DefaultPlayer;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ResetButton;
    }
}