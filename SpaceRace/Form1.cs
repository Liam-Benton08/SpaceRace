﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

//Liam Benton
//Space Race, May 15 2024
//This is a two player racing game
namespace SpaceRace
{
    public partial class spaceRace : Form
    {
        Rectangle player1 = new Rectangle(200, 400, 20, 30);
        Rectangle player2 = new Rectangle(500, 400, 20, 30);

        int playerSpeed = 6;
        int starSpeed = 4;
        int planetSpeed = 2;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        List<Rectangle> stars = new List<Rectangle>();
        List<Rectangle> planets = new List<Rectangle>();
        List<int> planetSizes = new List<int>();

        int starSize = 2;

        SolidBrush limeBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        Random randGen = new Random();
        int randValue = 0;
        public spaceRace()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            startLabel.Text = "";
            gameTimer.Enabled = true;

            //score = 0
            // time = 0

            planets.Clear();
            planetSizes.Clear();


        }
        private void spaceRace_Click(object sender, EventArgs e)
        {
            startLabel.Text += "Game staring in 3";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text += "Game staring in 2";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text += "Game staring in 1";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text += "Gooooooo";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text += "";
            startLabel.Visible = false;

            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void spaceRace_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == false)
            {
                startLabel.Text = "Press Space to Start or Esc to Exit";
            }

            else if (gameTimer.Enabled == true)
            {

                for (int i = 0; i < stars.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, stars[i]);
                }
                for (int i = 0; i < planets.Count; i++)
                {
                    e.Graphics.FillEllipse(yellowBrush, planets[i]);
                }
                
                    
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
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled == true)
                    {
                        InitializeGame();
                    }
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            movePLayers();



            //playerInteractions();

            Refresh();
        }

        private void startLabel_Click(object sender, EventArgs e)
        {
            startLabel.Text += "\nGame staring in 3";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text = "\nGame staring in 2";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text = "\nGame staring in 1";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text = "\nGooooooo";
            Thread.Sleep(1000);
            Refresh();
            startLabel.Text += "";
            startLabel.Visible = false;

            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        public void movePLayers()
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

            if (upPressed && player2.Y >= 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downPressed && player2.Y <= this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
        }

        public void moveProjectiles()
        {
            //Draw projectiles across the screen
            for (int i = 0; i < stars.Count; i++)
            {
                int x = stars[i].X + starSpeed;

                stars[i] = new Rectangle(x, stars[i].Y, starSize, starSize);
            }

            if (gameTimer.Enabled == true)
            {
                for (int i = 0; i < planets.Count; i++)
                {
                    int x = planets[i].X + planetSpeed;

                    planets[i] = new Rectangle(x, planets[i].Y, planetSizes[i], planetSizes[i]);
                }
            }
        }

        public void newProjectile()
        {
            randValue = randGen.Next(0, 101);

            if (randValue >= 30)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle projectile = new Rectangle(0, randValue, starSize, starSize);
                stars.Add(projectile);
            }
            if (randValue >= 75)
            {
                randValue = randGen.Next(0, this.Height);

                for (int i = 0; i < planets.Count; i++)
                {
                    Rectangle planet = new Rectangle(0, randValue, planetSizes[i], planetSizes[i]);
                    planets.Add(planet);
                    planetSizes.Add(randGen.Next(10, 30));
                }
            }
        }

        public void removeProjectile()
        {
            //Remove ball if it has gone off the screen
            for (int i = 0; i < stars.Count; i++)
            {
                if (stars[i].X > this.Width)
                {
                    stars.RemoveAt(i);
                }
            }
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets[i].X > this.Width)
                {
                    planets.RemoveAt(i);
                    planetSizes.RemoveAt(i);
                }

            }
        }

        public void playerInteractions()
        {
            //Check for collision between ball and player
            for (int i = 0; i < stars.Count; i++)
            {
                if (stars[i].IntersectsWith(player1))
                {
                    gameTimer.Stop();
                }
                if (stars[i].IntersectsWith(player2))
                {
                    gameTimer.Stop();
                }
            }
        }

        private void starTimer_Tick(object sender, EventArgs e)
        {
            moveProjectiles();

            newProjectile();

            removeProjectile();
        }
    }
}
