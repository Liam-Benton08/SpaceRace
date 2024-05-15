namespace SpaceRace
{
    partial class spaceRace
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // startLabel
            // 
            this.startLabel.BackColor = System.Drawing.Color.Transparent;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Red;
            this.startLabel.Location = new System.Drawing.Point(227, 51);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(381, 62);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Click Anywhere to Start";
            this.startLabel.Click += new System.EventHandler(this.startLabel_Click);
            // 
            // spaceRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "spaceRace";
            this.Text = "Space Race";
            this.Click += new System.EventHandler(this.spaceRace_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.spaceRace_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spaceRace_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.spaceRace_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label startLabel;
    }
}

