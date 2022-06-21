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

        public Bracket FillBracket()
        {
            Bracket bracket = new Bracket();
            BindingList<Team> eastField = league.GetTeamsList("East");
            BindingList<Team> westField = league.GetTeamsList("West");
            int i;
            for (i = 0; i < seeds.Count(); i++)
            {
                Team teamToAdd = eastField[rnd.Next(1, eastField.Count())];
                eastField.Remove(teamToAdd);
                league.SetTeamSeed(teamToAdd.name, "East", seeds[i]);
                switch (i)
                {
                    case 0:
                        bracket.rightName1.Text = teamToAdd.name;
                        break;
                    case 1:
                        bracket.rightName2.Text = teamToAdd.name;
                        break;
                    case 2:
                        bracket.rightName3.Text = teamToAdd.name;
                        break;
                    case 3:
                        bracket.rightName4.Text = teamToAdd.name;
                        break;
                    case 4:
                        bracket.rightName5.Text = teamToAdd.name;
                        break;
                    case 5:
                        bracket.rightName6.Text = teamToAdd.name;
                        break;
                    case 6:
                        bracket.rightName7.Text = teamToAdd.name;
                        break;
                    case 7:
                        bracket.rightName8.Text = teamToAdd.name;
                        break;
                }
            }
            for (i = 0; i < seeds.Count(); i++)
            {
                Team teamToAdd = westField[rnd.Next(1, westField.Count())];
                westField.Remove(teamToAdd);
                league.SetTeamSeed(teamToAdd.name, "West", seeds[i]);
                switch (i)
                {
                    case 0:
                        bracket.leftName1.Text = teamToAdd.name;
                        break;
                    case 1:
                        bracket.leftName2.Text = teamToAdd.name;
                        break;
                    case 2:
                        bracket.leftName3.Text = teamToAdd.name;
                        break;
                    case 3:
                        bracket.leftName4.Text = teamToAdd.name;
                        break;
                    case 4:
                        bracket.leftName5.Text = teamToAdd.name;
                        break;
                    case 5:
                        bracket.leftName6.Text = teamToAdd.name;
                        break;
                    case 6:
                        bracket.leftName7.Text = teamToAdd.name;
                        break;
                    case 7:
                        bracket.leftName8.Text = teamToAdd.name;
                        break;
                }
            }
            return bracket;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Bracket bracket = FillBracket();
            bracket.Show();
            this.Hide();
        }
    }
}
