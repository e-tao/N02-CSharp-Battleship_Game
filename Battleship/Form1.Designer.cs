
namespace Battleship
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnStart = new System.Windows.Forms.Button();
            this.GrdPlayer = new Battleship.model.GameGrid();
            this.GrdFire = new Battleship.model.GameGrid();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.LblResultPlayer = new System.Windows.Forms.Label();
            this.LblResultAi = new System.Windows.Forms.Label();
            this.LblStepsAi = new System.Windows.Forms.Label();
            this.LblStepsPlayer = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LblShipSunk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblPlayerShipLeft = new System.Windows.Forms.Label();
            this.LblAiShipLeft = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnStart.Location = new System.Drawing.Point(12, 702);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(500, 30);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "START";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // GrdPlayer
            // 
            this.GrdPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrdPlayer.Location = new System.Drawing.Point(541, 211);
            this.GrdPlayer.Name = "GrdPlayer";
            this.GrdPlayer.Size = new System.Drawing.Size(500, 480);
            this.GrdPlayer.TabIndex = 2;
            this.GrdPlayer.GridClick += new Battleship.model.GameGrid.GridPosition(this.GrdPlayer_GridClick);
            // 
            // GrdFire
            // 
            this.GrdFire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GrdFire.Location = new System.Drawing.Point(12, 213);
            this.GrdFire.Name = "GrdFire";
            this.GrdFire.Size = new System.Drawing.Size(500, 480);
            this.GrdFire.TabIndex = 3;
            this.GrdFire.GridClick += new Battleship.model.GameGrid.GridPosition(this.GrdFire_FireClick);
            // 
            // BtnAdd
            // 
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Location = new System.Drawing.Point(541, 702);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 30);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(622, 702);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 30);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Location = new System.Drawing.Point(966, 702);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 30);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "RESET";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // LblResultPlayer
            // 
            this.LblResultPlayer.AutoSize = true;
            this.LblResultPlayer.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblResultPlayer.Location = new System.Drawing.Point(208, 88);
            this.LblResultPlayer.Name = "LblResultPlayer";
            this.LblResultPlayer.Size = new System.Drawing.Size(0, 39);
            this.LblResultPlayer.TabIndex = 7;
            // 
            // LblResultAi
            // 
            this.LblResultAi.AutoSize = true;
            this.LblResultAi.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblResultAi.Location = new System.Drawing.Point(734, 88);
            this.LblResultAi.Name = "LblResultAi";
            this.LblResultAi.Size = new System.Drawing.Size(0, 39);
            this.LblResultAi.TabIndex = 7;
            // 
            // LblStepsAi
            // 
            this.LblStepsAi.AutoSize = true;
            this.LblStepsAi.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblStepsAi.Location = new System.Drawing.Point(708, 141);
            this.LblStepsAi.Name = "LblStepsAi";
            this.LblStepsAi.Size = new System.Drawing.Size(0, 20);
            this.LblStepsAi.TabIndex = 8;
            // 
            // LblStepsPlayer
            // 
            this.LblStepsPlayer.AutoSize = true;
            this.LblStepsPlayer.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblStepsPlayer.Location = new System.Drawing.Point(316, 141);
            this.LblStepsPlayer.Name = "LblStepsPlayer";
            this.LblStepsPlayer.Size = new System.Drawing.Size(0, 20);
            this.LblStepsPlayer.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Battleship.Properties.Resources.VS;
            this.pictureBox3.Location = new System.Drawing.Point(456, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 104);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // LblShipSunk
            // 
            this.LblShipSunk.AutoSize = true;
            this.LblShipSunk.Font = new System.Drawing.Font("Ink Free", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblShipSunk.Location = new System.Drawing.Point(412, 163);
            this.LblShipSunk.Name = "LblShipSunk";
            this.LblShipSunk.Size = new System.Drawing.Size(0, 34);
            this.LblShipSunk.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(208, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Steps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(743, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 39);
            this.label2.TabIndex = 13;
            this.label2.Text = "Steps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(208, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 39);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ships";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(743, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 39);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ships";
            // 
            // LblPlayerShipLeft
            // 
            this.LblPlayerShipLeft.AutoSize = true;
            this.LblPlayerShipLeft.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblPlayerShipLeft.Location = new System.Drawing.Point(316, 182);
            this.LblPlayerShipLeft.Name = "LblPlayerShipLeft";
            this.LblPlayerShipLeft.Size = new System.Drawing.Size(0, 20);
            this.LblPlayerShipLeft.TabIndex = 16;
            // 
            // LblAiShipLeft
            // 
            this.LblAiShipLeft.AutoSize = true;
            this.LblAiShipLeft.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAiShipLeft.Location = new System.Drawing.Point(716, 182);
            this.LblAiShipLeft.Name = "LblAiShipLeft";
            this.LblAiShipLeft.Size = new System.Drawing.Size(0, 20);
            this.LblAiShipLeft.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Battleship.Properties.Resources.mario;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Battleship.Properties.Resources.Yoshi;
            this.pictureBox2.Location = new System.Drawing.Point(851, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 194);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 794);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblAiShipLeft);
            this.Controls.Add(this.LblPlayerShipLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblShipSunk);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.LblStepsPlayer);
            this.Controls.Add(this.LblStepsAi);
            this.Controls.Add(this.LblResultAi);
            this.Controls.Add(this.LblResultPlayer);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.GrdFire);
            this.Controls.Add(this.GrdPlayer);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "-=Battleship=-";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private model.GameGrid GrdPlayer;
        private model.GameGrid GrdFire;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Label LblResultPlayer;
        private System.Windows.Forms.Label LblResultAi;
        private System.Windows.Forms.Label LblStepsAi;
        private System.Windows.Forms.Label LblStepsPlayer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LblShipSunk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblPlayerShipLeft;
        private System.Windows.Forms.Label LblAiShipLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

