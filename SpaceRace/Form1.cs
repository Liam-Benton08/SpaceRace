using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Liam Benton
//Space Race, May 15 2024
//This is a two player racing game
namespace SpaceRace
{
    public partial class spaceRace : Form
    {
        Rectangle player1 = new Rectangle(200, 400, 30, 50);
        Rectangle player2 = new Rectangle(500, 400, 30, 50);
        
        int playerSpeed = 5;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        int startScreen = 0;

        List<Rectangle> Projectiles = new List<Rectangle>();

        SolidBrush limeBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        public spaceRace()
        {
            InitializeComponent();
        }

        private void spaceRace_Click(object sender, EventArgs e)
        {
            startLabel.Text = "";
            startLabel.Visible = false;
            gameTimer.Enabled = true;
            gameTimer.Start();
            
            startScreen++;

        }

        private void spaceRace_Paint(object sender, PaintEventArgs e)
        {
                if (startScreen == 1)
                {
                e.Graphics.FillRectangle(limeBrush, player1);
                e.Graphics.FillRectangle(limeBrush, player2);
                }

        }

        private void spaceRace_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;

            }
        }

        private void spaceRace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;

            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Move players up and down
            if (wPressed && player1.Y >= 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sPressed && player1.Y <= this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if(upPressed && player2.Y >= 0)
            {
                player2.Y -= playerSpeed;
            }

            if(downPressed && player2.Y <= this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            //

            Refresh();
        }

        private void startLabel_Click(object sender, EventArgs e)
        {
            startLabel.Text = "";
            startLabel.Visible = false;
            gameTimer.Enabled = true;
            gameTimer.Start();

            startScreen++;

        }
    }
}
