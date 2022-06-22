using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BracketSim
{
    public partial class Bracket : Form
    {
        public Bracket()
        {
            InitializeComponent();
        }

        public int gameCounter = 0;

        public WelcomeScreen welcomeScreen = new WelcomeScreen();

        public void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            Color black = Color.FromArgb(255, 0, 0, 0);
            Pen blackPen = new Pen(black);
            blackPen.Width = 2;
            //
            //Left Side
            //
            //draw matchup 1L
            e.Graphics.DrawLine(blackPen, 25, 40, 125, 40);
            e.Graphics.DrawLine(blackPen, 125, 40, 140, 60);
            e.Graphics.DrawLine(blackPen, 25, 80, 125, 80);
            e.Graphics.DrawLine(blackPen, 125, 80, 140, 60);
            //draw matchup 2L
            e.Graphics.DrawLine(blackPen, 25, 120, 125, 120);
            e.Graphics.DrawLine(blackPen, 125, 120, 140, 140);
            e.Graphics.DrawLine(blackPen, 25, 160, 125, 160);
            e.Graphics.DrawLine(blackPen, 125, 160, 140, 140);
            //draw matchup 3L
            e.Graphics.DrawLine(blackPen, 25, 200, 125, 200);
            e.Graphics.DrawLine(blackPen, 125, 200, 140, 220);
            e.Graphics.DrawLine(blackPen, 25, 240, 125, 240);
            e.Graphics.DrawLine(blackPen, 125, 240, 140, 220);
            //draw matchup 4L
            e.Graphics.DrawLine(blackPen, 25, 280, 125, 280);
            e.Graphics.DrawLine(blackPen, 125, 280, 140, 300);
            e.Graphics.DrawLine(blackPen, 25, 320, 125, 320);
            e.Graphics.DrawLine(blackPen, 125, 320, 140, 300);
            //draw matchup 5L
            e.Graphics.DrawLine(blackPen, 140, 60, 240, 60);
            e.Graphics.DrawLine(blackPen, 240, 60, 260, 100);
            e.Graphics.DrawLine(blackPen, 140, 140, 240, 140);
            e.Graphics.DrawLine(blackPen, 240, 140, 260, 100);
            //draw matchup 6L
            e.Graphics.DrawLine(blackPen, 140, 220, 240, 220);
            e.Graphics.DrawLine(blackPen, 240, 220, 260, 260);
            e.Graphics.DrawLine(blackPen, 140, 300, 240, 300);
            e.Graphics.DrawLine(blackPen, 240, 300, 260, 260);
            //draw matchup 7L
            e.Graphics.DrawLine(blackPen, 260, 100, 360, 100);
            e.Graphics.DrawLine(blackPen, 360, 100, 380, 180);
            e.Graphics.DrawLine(blackPen, 260, 260, 360, 260);
            e.Graphics.DrawLine(blackPen, 360, 260, 380, 180);
            //draw left champion
            e.Graphics.DrawLine(blackPen, 380, 180, 480, 180);
            //
            //Right Side
            //
            //draw matchup 1R
            e.Graphics.DrawLine(blackPen, 975, 40, 875, 40);
            e.Graphics.DrawLine(blackPen, 875, 40, 860, 60);
            e.Graphics.DrawLine(blackPen, 975, 80, 875, 80);
            e.Graphics.DrawLine(blackPen, 875, 80, 860, 60);
            //draw matchup 2R
            e.Graphics.DrawLine(blackPen, 975, 120, 875, 120);
            e.Graphics.DrawLine(blackPen, 875, 120, 860, 140);
            e.Graphics.DrawLine(blackPen, 975, 160, 875, 160);
            e.Graphics.DrawLine(blackPen, 875, 160, 860, 140);
            //draw matchup 3R
            e.Graphics.DrawLine(blackPen, 975, 200, 875, 200);
            e.Graphics.DrawLine(blackPen, 875, 200, 860, 220);
            e.Graphics.DrawLine(blackPen, 975, 240, 875, 240);
            e.Graphics.DrawLine(blackPen, 875, 240, 860, 220);
            //draw matchup 4R
            e.Graphics.DrawLine(blackPen, 975, 280, 875, 280);
            e.Graphics.DrawLine(blackPen, 875, 280, 860, 300);
            e.Graphics.DrawLine(blackPen, 975, 320, 875, 320);
            e.Graphics.DrawLine(blackPen, 875, 320, 860, 300);
            //draw matchup 5R
            e.Graphics.DrawLine(blackPen, 860, 60, 760, 60);
            e.Graphics.DrawLine(blackPen, 760, 60, 745, 100);
            e.Graphics.DrawLine(blackPen, 860, 140, 760, 140);
            e.Graphics.DrawLine(blackPen, 760, 140, 745, 100);
            //draw matchup 6R
            e.Graphics.DrawLine(blackPen, 860, 220, 760, 220);
            e.Graphics.DrawLine(blackPen, 760, 220, 745, 260);
            e.Graphics.DrawLine(blackPen, 860, 300, 760, 300);
            e.Graphics.DrawLine(blackPen, 760, 300, 745, 260);
            //draw matchup 7R
            e.Graphics.DrawLine(blackPen, 745, 100, 645, 100);
            e.Graphics.DrawLine(blackPen, 645, 100, 620, 180);
            e.Graphics.DrawLine(blackPen, 745, 260, 645, 260);
            e.Graphics.DrawLine(blackPen, 645, 260, 620, 180);
            //draw right champion
            e.Graphics.DrawLine(blackPen, 620, 180, 520 , 180);
            //draw champion
            e.Graphics.DrawLine(blackPen, 400, 280, 600, 280);
            return;
        }

        private void simBtn_Click(object sender, EventArgs e)
        {
            int team1Score = welcomeScreen.rnd.Next(60, 120);
            int team2Score = welcomeScreen.rnd.Next(60, 120);
            switch(gameCounter)
            {
                case 0:
                    Team team1 = welcomeScreen.league.GetTeam(leftName1.Text, "West");
                    Team team2 = welcomeScreen.league.GetTeam(leftName2.Text, "West");
                    Game game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left2ndSeed1.Text = leftSeed1.Text;
                        left2ndName1.Text = team1.name;
                    }
                    else
                    {
                        left2ndSeed1.Text = leftSeed2.Text;
                        left2ndName1.Text = team2.name;
                    }
                    break;
                case 1:
                    team1 = welcomeScreen.league.GetTeam(leftName3.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(leftName4.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left2ndSeed2.Text = leftSeed3.Text;
                        left2ndName2.Text = team1.name;
                    }
                    else
                    {
                        left2ndSeed2.Text = leftSeed4.Text;
                        left2ndName2.Text = team2.name;
                    }
                    break;
                case 2:
                    team1 = welcomeScreen.league.GetTeam(leftName5.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(leftName6.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left2ndSeed3.Text = leftSeed5.Text;
                        left2ndName3.Text = team1.name;
                    }
                    else
                    {
                        left2ndSeed3.Text = leftSeed6.Text;
                        left2ndName3.Text = team2.name;
                    }
                    break;
                case 3:
                    team1 = welcomeScreen.league.GetTeam(leftName7.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(leftName8.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left2ndSeed4.Text = leftSeed7.Text;
                        left2ndName4.Text = team1.name;
                    }
                    else
                    {
                        left2ndSeed4.Text = leftSeed8.Text;
                        left2ndName4.Text = team2.name;
                    }
                    break;
                case 4:
                    team1 = welcomeScreen.league.GetTeam(rightName1.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(rightName2.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right2ndSeed1.Text = rightSeed1.Text;
                        right2ndName1.Text = team1.name;
                    }
                    else
                    {
                        right2ndSeed1.Text = rightSeed2.Text;
                        right2ndName1.Text = team2.name;
                    }
                    break;
                case 5:
                    team1 = welcomeScreen.league.GetTeam(rightName3.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(rightName4.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right2ndSeed2.Text = rightSeed3.Text;
                        right2ndName2.Text = team1.name;
                    }
                    else
                    {
                        right2ndSeed2.Text = rightSeed4.Text;
                        right2ndName2.Text = team2.name;
                    }
                    break;
                case 6:
                    team1 = welcomeScreen.league.GetTeam(rightName5.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(rightName6.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right2ndSeed3.Text = rightSeed5.Text;
                        right2ndName3.Text = team1.name;
                    }
                    else
                    {
                        right2ndSeed3.Text = rightSeed6.Text;
                        right2ndName3.Text = team2.name;
                    }
                    break;
                case 7:
                    team1 = welcomeScreen.league.GetTeam(rightName7.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(rightName8.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right2ndSeed4.Text = rightSeed7.Text;
                        right2ndName4.Text = team1.name;
                    }
                    else
                    {
                        right2ndSeed4.Text = rightSeed8.Text;
                        right2ndName4.Text = team2.name;
                    }
                    break;
                case 8:
                    team1 = welcomeScreen.league.GetTeam(left2ndName1.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(left2ndName2.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left3rdSeed1.Text = left2ndSeed1.Text;
                        left3rdName1.Text = team1.name;
                    }
                    else
                    {
                        left3rdSeed1.Text = left2ndSeed2.Text;
                        left3rdName1.Text = team2.name;
                    }
                    break;
                case 9:
                    team1 = welcomeScreen.league.GetTeam(left2ndName3.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(left2ndName4.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        left3rdSeed2.Text = left2ndSeed3.Text;
                        left3rdName2.Text = team1.name;
                    }
                    else
                    {
                        left3rdSeed2.Text = left2ndSeed4.Text;
                        left3rdName2.Text = team2.name;
                    }
                    break;
                case 10:
                    team1 = welcomeScreen.league.GetTeam(right2ndName1.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(right2ndName2.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right3rdSeed1.Text = right2ndSeed1.Text;
                        right3rdName1.Text = team1.name;
                    }
                    else
                    {
                        right3rdSeed1.Text = right2ndSeed2.Text;
                        right3rdName1.Text = team2.name;
                    }
                    break;
                case 11:
                    team1 = welcomeScreen.league.GetTeam(right2ndName3.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(right2ndName4.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        right3rdSeed2.Text = right2ndSeed3.Text;
                        right3rdName2.Text = team1.name;
                    }
                    else
                    {
                        right3rdSeed2.Text = right2ndSeed4.Text;
                        right3rdName2.Text = team2.name;
                    }
                    break;
                case 12:
                    team1 = welcomeScreen.league.GetTeam(left3rdName1.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(left3rdName2.Text, "West");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        leftChampionSeed.Text = left3rdSeed1.Text;
                        leftChampionName.Text = team1.name;
                    }
                    else
                    {
                        leftChampionSeed.Text = left3rdSeed2.Text;
                        leftChampionName.Text = team2.name;
                    }
                    break;
                case 13:
                    team1 = welcomeScreen.league.GetTeam(right3rdName1.Text, "East");
                    team2 = welcomeScreen.league.GetTeam(right3rdName2.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        rightChampionSeed.Text = right3rdSeed1.Text;
                        rightChampionName.Text = team1.name;
                    }
                    else
                    {
                        rightChampionSeed.Text = right3rdSeed2.Text;
                        rightChampionName.Text = team2.name;
                    }
                    break;
                case 14:
                    team1 = welcomeScreen.league.GetTeam(leftChampionName.Text, "West");
                    team2 = welcomeScreen.league.GetTeam(rightChampionName.Text, "East");
                    game = new Game(team1, team2, team1Score, team2Score);
                    welcomeScreen.league.AddGame(game);
                    if (game.winner == team1)
                    {
                        championSeed.Text = leftChampionSeed.Text + leftChampionName.Text;
                    }
                    else
                    {
                        championSeed.Text = rightChampionSeed.Text + rightChampionName.Text;
                    }
                    break;
            }
            gameCounter++;
        }
    }
}
