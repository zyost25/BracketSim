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

        public BindingList<Team> westField = new BindingList<Team>();

        public BindingList<Team> eastField = new BindingList<Team>();

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

        public Bracket FillFirstRound()
        {
            Bracket bracket = new Bracket();
            Team teamToAdd = new Team("");
            List<Label> leftLabels = new List<Label> { bracket.leftName1, bracket.leftName2,
                bracket.leftName3, bracket.leftName4, bracket.leftName5, bracket.leftName6,
                bracket.leftName7, bracket.leftName8 };
            List<Label> rightLabels = new List<Label> { bracket.rightName1, bracket.rightName2,
                bracket.rightName3, bracket.rightName4, bracket.rightName5, bracket.rightName6,
                bracket.rightName7, bracket.rightName8 };
            BindingList<Team> easternConference = league.GetTeamsList("East");
            BindingList<Team> westernConference = league.GetTeamsList("West");
            int i;
            for (i = 0; i < seeds.Count(); i++)
            {
                teamToAdd = easternConference[rnd.Next(1, easternConference.Count())];
                easternConference.Remove(teamToAdd);
                teamToAdd.seed = seeds[i];
                eastField.Add(teamToAdd);
                rightLabels[i].Text = teamToAdd.name;
            }
            for (i = 0; i < seeds.Count(); i++)
            {
                teamToAdd = westernConference[rnd.Next(1, westernConference.Count())];
                westernConference.Remove(teamToAdd);
                teamToAdd.seed = seeds[i];
                westField.Add(teamToAdd);
                leftLabels[i].Text = teamToAdd.name;
            }
            return bracket;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Bracket bracket = FillFirstRound();
            bracket.Show();
            this.Hide();
        }
    }
}
