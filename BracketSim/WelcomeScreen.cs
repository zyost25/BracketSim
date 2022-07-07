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
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            SetupLeague();
        }

        public List<int> seeds = new List<int> { 1, 8, 4, 5, 3, 6, 2, 7 };

        public League league = new League();
        
        public Random rnd = new Random();

        public List<Team> easternConference;
        public List<Team> westernConference;
        public int gameCounter;
        public int simCounter = 0;

        public void Bracket_Paint(object sender, PaintEventArgs e)
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
            e.Graphics.DrawLine(blackPen, 620, 180, 520, 180);
            //draw champion
            e.Graphics.DrawLine(blackPen, 400, 280, 600, 280);
            return;
        }

        public void SetupLeague()
        {
            gameCounter = 0;
            league = new League();
            league.AddTeam("Heat", "East");
            league.AddTeam("Celtics", "East");
            league.AddTeam("Bucks", "East");
            league.AddTeam("76ers", "East");
            league.AddTeam("Raptors", "East");
            league.AddTeam("Bulls", "East");
            league.AddTeam("Nets", "East");
            league.AddTeam("Hawks", "East");
            league.AddTeam("Cavaliers", "East");
            league.AddTeam("Hornets", "East");
            league.AddTeam("Knicks", "East");
            league.AddTeam("Wizards", "East");
            league.AddTeam("Pacers", "East");
            league.AddTeam("Pistons", "East");
            league.AddTeam("Magic", "East");
            league.AddTeam("Suns", "West");
            league.AddTeam("Grizzlies", "West");
            league.AddTeam("Warriors", "West");
            league.AddTeam("Mavericks", "West");
            league.AddTeam("Jazz", "West");
            league.AddTeam("Nuggets", "West");
            league.AddTeam("Timberwolves", "West");
            league.AddTeam("Pelicans", "West");
            league.AddTeam("Clippers", "West");
            league.AddTeam("Spurs", "West");
            league.AddTeam("Lakers", "West");
            league.AddTeam("Kings", "West");
            league.AddTeam("Trail Blazers", "West");
            league.AddTeam("Thunder", "West");
            league.AddTeam("Rockets", "West");
            return;
        }

        public void FillFirstRound()
        {
            simCounter++;
            easternConference = league.GetTeamsList("East");
            westernConference = league.GetTeamsList("West");
            Team teamToAdd = new Team("");
            List<Label> leftLabels = new List<Label> { this.leftName1, this.leftName2,
                this.leftName3, this.leftName4, this.leftName5, this.leftName6,
                this.leftName7, this.leftName8 };
            List<Label> rightLabels = new List<Label> { this.rightName1, this.rightName2,
                this.rightName3, this.rightName4, this.rightName5, this.rightName6,
                this.rightName7, this.rightName8 };
            int i;
            //fill in west bracket
            for (i = 0; i < seeds.Count(); i++)
            {
                teamToAdd = westernConference[rnd.Next(1, westernConference.Count())];
                westernConference.Remove(teamToAdd);
                teamToAdd.seed = seeds[i];
                league.westField.Add(teamToAdd);
                leftLabels[i].Text = "(" + teamToAdd.seed + ") " + teamToAdd.name;
            }
            //fill in east bracket
            for (i = 0; i < seeds.Count(); i++)
            {
                teamToAdd = easternConference[rnd.Next(1, easternConference.Count())];
                easternConference.Remove(teamToAdd);
                teamToAdd.seed = seeds[i];
                league.eastField.Add(teamToAdd);
                rightLabels[i].Text = teamToAdd.name + " (" + teamToAdd.seed + ")";
            }
            return;
        }

        public void SimFirstRound()
        {
            int i;
            //west first round
            for (i = 0; i < league.westField.Count(); i += 2)
            {
                league.PlayGame(league.westField[i], league.westField[i + 1]);
            }
            //east first round
            for (i = 0; i < league.eastField.Count(); i += 2)
            {
                league.PlayGame(league.eastField[i], league.eastField[i + 1]);
            }
            return;
        }

        public void FillSecondRound()
        {
            List<Label> leftLabels = new List<Label> { this.left2ndName1, this.left2ndName2,
                this.left2ndName3, this.left2ndName4 };
            List<Label> rightLabels = new List<Label> { this.right2ndName1, this.right2ndName2,
                this.right2ndName3, this.right2ndName4 };
            int i;
            //set west labels
            for (i = 0; i < leftLabels.Count(); i++)
            {
                leftLabels[i].Text = "(" + league.games[gameCounter].winner.seed + ") " + league.games[gameCounter].winner.name;
                gameCounter++;
            }
            //set east labels
            for (i = 0; i < rightLabels.Count(); i++)
            {
                rightLabels[i].Text = league.games[gameCounter].winner.name + " (" + league.games[gameCounter].winner.seed + ")";
                gameCounter++;
            }
            return;
        }

        public void SimSecondRound()
        {
            int i;
            //west second round
            for (i = 0; i < league.games.Count() - 1; i += 2)
            {
                league.PlayGame(league.games[i].winner, league.games[i + 1].winner);
            }
            //east second round
            for (i = 4; i < league.games.Count() - 1; i += 2)
            {
                league.PlayGame(league.games[i].winner, league.games[i + 1].winner);
            }
            return;
        }

        public void FillThirdRound()
        {
            List<Label> leftLabels = new List<Label> { this.left3rdName1, this.left3rdName2 };
            List<Label> rightLabels = new List<Label> { this.right3rdName1, this.right3rdName2 };
            int i;
            int gameCounter = 8;
            //set west labels
            for (i = 0; i < leftLabels.Count(); i++)
            {
                leftLabels[i].Text = "(" + league.games[gameCounter].winner.seed + ") " + league.games[gameCounter].winner.name;
                gameCounter++;
            }
            //set east labels
            for (i = 0; i < rightLabels.Count(); i++)
            {
                rightLabels[i].Text = league.games[gameCounter].winner.name + " (" + league.games[gameCounter].winner.seed + ")";
                gameCounter++;
            }
            return;
        }

        public void SimFourthRound()
        {
            //west final
            league.PlayGame(league.games[8].winner, league.games[9].winner);

            //east final
            league.PlayGame(league.games[10].winner, league.games[11].winner);
            return;
        }

        public void FillChampionship()
        {
            this.leftChampionName.Text = "(" + league.games[12].winner.seed + ") " + league.games[12].winner.name;
            this.rightChampionName.Text = league.games[13].winner.name + " (" + league.games[13].winner.seed + ")";
            return;
        }

        public void SimChampionship()
        {
            league.PlayGame(league.games[12].winner, league.games[13].winner);
            return;
        }

        public void FillChampion()
        {
            this.championLbl.Text = "(" + league.games[14].winner.seed + ") " + league.games[14].winner.name;
            return;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetupLeague();
            FillFirstRound();
            return;
        }

        private void simBtn_Click(object sender, EventArgs e)
        {
            SimFirstRound();
            FillSecondRound();
            SimSecondRound();
            FillThirdRound();
            SimFourthRound();
            FillChampionship();
            SimChampionship();
            FillChampion();
            return;
        }
    }
}
