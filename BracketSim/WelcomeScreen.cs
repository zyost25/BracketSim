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

        public Bracket bracket;
        public List<Team> easternConference;
        public List<Team> westernConference;
        public int gameCounter;

        public void SetupLeague()
        {
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

        public Bracket FillFirstRound()
        {
            bracket = new Bracket();
            easternConference = league.GetTeamsList("East");
            westernConference = league.GetTeamsList("West");
            Team teamToAdd = new Team("");
            List<Label> leftLabels = new List<Label> { bracket.leftName1, bracket.leftName2,
                bracket.leftName3, bracket.leftName4, bracket.leftName5, bracket.leftName6,
                bracket.leftName7, bracket.leftName8 };
            List<Label> rightLabels = new List<Label> { bracket.rightName1, bracket.rightName2,
                bracket.rightName3, bracket.rightName4, bracket.rightName5, bracket.rightName6,
                bracket.rightName7, bracket.rightName8 };
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
            return bracket;
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
            List<Label> leftLabels = new List<Label> { bracket.left2ndName1, bracket.left2ndName2, 
                bracket.left2ndName3, bracket.left2ndName4 };
            List<Label> rightLabels = new List<Label> { bracket.right2ndName1, bracket.right2ndName2, 
                bracket.right2ndName3, bracket.right2ndName4 };
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
            List<Label> leftLabels = new List<Label> { bracket.left3rdName1, bracket.left3rdName2 };
            List<Label> rightLabels = new List<Label> { bracket.right3rdName1, bracket.right3rdName2 };
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
            bracket.leftChampionName.Text = "(" + league.games[12].winner.seed + ") " + league.games[12].winner.name;
            bracket.rightChampionName.Text = league.games[13].winner.name + " (" + league.games[13].winner.seed + ")";
            return;
        }

        public void SimChampionship()
        {
            league.PlayGame(league.games[12].winner, league.games[13].winner);
            return;
        }

        public void FillChampion()
        {
            bracket.championLbl.Text = "(" + league.games[14].winner.seed + ") " + league.games[14].winner.name;
            return;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            league = new League();
            SetupLeague();
            gameCounter = 0;
            bracket = FillFirstRound();
            bracket.Show();
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
