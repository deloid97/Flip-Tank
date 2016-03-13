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
            this.RestartButton = new System.Windows.Forms.Button();
            this.WaveGroup = new System.Windows.Forms.GroupBox();
            this.OnScreenBox = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumEnemiesBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnemySpawnGroup = new System.Windows.Forms.GroupBox();
            this.SFlyerChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.FlyerChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.GroundChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.SGroundChanceBox = new System.Windows.Forms.MaskedTextBox();
            this.RandSpawnButton = new System.Windows.Forms.Button();
            this.PlayerGroup = new System.Windows.Forms.GroupBox();
            this.JumpBox = new System.Windows.Forms.MaskedTextBox();
            this.SpeedBox = new System.Windows.Forms.MaskedTextBox();
            this.HealthBox = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.WaveGroup.SuspendLayout();
            this.EnemySpawnGroup.SuspendLayout();
            this.PlayerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartButton.Location = new System.Drawing.Point(210, 322);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(119, 54);
            this.RestartButton.TabIndex = 10;
            this.RestartButton.Text = "Restart Game";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // WaveGroup
            // 
            this.WaveGroup.Controls.Add(this.OnScreenBox);
            this.WaveGroup.Controls.Add(this.label6);
            this.WaveGroup.Controls.Add(this.label5);
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
            this.OnScreenBox.TabIndex = 0;
            this.OnScreenBox.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 786;
            this.label6.Text = "Max on Screen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 757;
            this.label5.Text = "# of Enemies";
            // 
            // NumEnemiesBox
            // 
            this.NumEnemiesBox.Location = new System.Drawing.Point(9, 47);
            this.NumEnemiesBox.Mask = "00000";
            this.NumEnemiesBox.Name = "NumEnemiesBox";
            this.NumEnemiesBox.Size = new System.Drawing.Size(100, 20);
            this.NumEnemiesBox.TabIndex = 0;
            this.NumEnemiesBox.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 16);
            this.label4.TabIndex = 369;
            this.label4.Text = "Shielded Flyer Chance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Shielded Ground Chance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 178;
            this.label2.Text = "Flyer Chance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Ground Chance";
            // 
            // EnemySpawnGroup
            // 
            this.EnemySpawnGroup.Controls.Add(this.SFlyerChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.FlyerChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.GroundChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.SGroundChanceBox);
            this.EnemySpawnGroup.Controls.Add(this.label1);
            this.EnemySpawnGroup.Controls.Add(this.label4);
            this.EnemySpawnGroup.Controls.Add(this.label3);
            this.EnemySpawnGroup.Controls.Add(this.label2);
            this.EnemySpawnGroup.Location = new System.Drawing.Point(168, 5);
            this.EnemySpawnGroup.Name = "EnemySpawnGroup";
            this.EnemySpawnGroup.Size = new System.Drawing.Size(346, 141);
            this.EnemySpawnGroup.TabIndex = 3;
            this.EnemySpawnGroup.TabStop = false;
            this.EnemySpawnGroup.Text = "Enemy Spawn Chance";
            // 
            // SFlyerChanceBox
            // 
            this.SFlyerChanceBox.Location = new System.Drawing.Point(192, 109);
            this.SFlyerChanceBox.Mask = "00000";
            this.SFlyerChanceBox.Name = "SFlyerChanceBox";
            this.SFlyerChanceBox.Size = new System.Drawing.Size(100, 20);
            this.SFlyerChanceBox.TabIndex = 6;
            this.SFlyerChanceBox.ValidatingType = typeof(int);
            // 
            // FlyerChanceBox
            // 
            this.FlyerChanceBox.Location = new System.Drawing.Point(192, 47);
            this.FlyerChanceBox.Mask = "00000";
            this.FlyerChanceBox.Name = "FlyerChanceBox";
            this.FlyerChanceBox.Size = new System.Drawing.Size(100, 20);
            this.FlyerChanceBox.TabIndex = 5;
            this.FlyerChanceBox.ValidatingType = typeof(int);
            // 
            // GroundChanceBox
            // 
            this.GroundChanceBox.Location = new System.Drawing.Point(6, 47);
            this.GroundChanceBox.Mask = "00000";
            this.GroundChanceBox.Name = "GroundChanceBox";
            this.GroundChanceBox.Size = new System.Drawing.Size(100, 20);
            this.GroundChanceBox.TabIndex = 3;
            this.GroundChanceBox.ValidatingType = typeof(int);
            // 
            // SGroundChanceBox
            // 
            this.SGroundChanceBox.Location = new System.Drawing.Point(6, 109);
            this.SGroundChanceBox.Mask = "00000";
            this.SGroundChanceBox.Name = "SGroundChanceBox";
            this.SGroundChanceBox.Size = new System.Drawing.Size(100, 20);
            this.SGroundChanceBox.TabIndex = 4;
            this.SGroundChanceBox.ValidatingType = typeof(int);
            // 
            // RandSpawnButton
            // 
            this.RandSpawnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandSpawnButton.Location = new System.Drawing.Point(360, 164);
            this.RandSpawnButton.Name = "RandSpawnButton";
            this.RandSpawnButton.Size = new System.Drawing.Size(114, 50);
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
            this.PlayerGroup.Controls.Add(this.label9);
            this.PlayerGroup.Controls.Add(this.label8);
            this.PlayerGroup.Controls.Add(this.label7);
            this.PlayerGroup.Location = new System.Drawing.Point(14, 151);
            this.PlayerGroup.Name = "PlayerGroup";
            this.PlayerGroup.Size = new System.Drawing.Size(307, 136);
            this.PlayerGroup.TabIndex = 89;
            this.PlayerGroup.TabStop = false;
            this.PlayerGroup.Text = "Player Values";
            // 
            // JumpBox
            // 
            this.JumpBox.Location = new System.Drawing.Point(92, 93);
            this.JumpBox.Mask = "00000";
            this.JumpBox.Name = "JumpBox";
            this.JumpBox.Size = new System.Drawing.Size(100, 20);
            this.JumpBox.TabIndex = 9;
            this.JumpBox.ValidatingType = typeof(int);
            // 
            // SpeedBox
            // 
            this.SpeedBox.Location = new System.Drawing.Point(92, 62);
            this.SpeedBox.Mask = "00000";
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(100, 20);
            this.SpeedBox.TabIndex = 8;
            this.SpeedBox.ValidatingType = typeof(int);
            // 
            // HealthBox
            // 
            this.HealthBox.Location = new System.Drawing.Point(92, 30);
            this.HealthBox.Mask = "00000";
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(100, 20);
            this.HealthBox.TabIndex = 7;
            this.HealthBox.ValidatingType = typeof(int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 89;
            this.label9.Text = "Jump Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 7575;
            this.label8.Text = "Speed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 420;
            this.label7.Text = "Health";
            // 
            // GameBalanceTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 388);
            this.Controls.Add(this.PlayerGroup);
            this.Controls.Add(this.RandSpawnButton);
            this.Controls.Add(this.EnemySpawnGroup);
            this.Controls.Add(this.WaveGroup);
            this.Controls.Add(this.RestartButton);
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

        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.GroupBox WaveGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox EnemySpawnGroup;
        private System.Windows.Forms.Button RandSpawnButton;
        private System.Windows.Forms.GroupBox PlayerGroup;
        private System.Windows.Forms.MaskedTextBox SGroundChanceBox;
        private System.Windows.Forms.MaskedTextBox SFlyerChanceBox;
        private System.Windows.Forms.MaskedTextBox FlyerChanceBox;
        private System.Windows.Forms.MaskedTextBox GroundChanceBox;
        private System.Windows.Forms.MaskedTextBox OnScreenBox;
        private System.Windows.Forms.MaskedTextBox NumEnemiesBox;
        private System.Windows.Forms.MaskedTextBox JumpBox;
        private System.Windows.Forms.MaskedTextBox SpeedBox;
        private System.Windows.Forms.MaskedTextBox HealthBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}