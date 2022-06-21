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
            ResetSeeds();
            SetupLeague();
        }

        public List<int> seeds = new List<int>();

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

        public void ResetSeeds()
        {
            seeds.Clear();
            seeds.AddRange(new List<int>() { 1, 8, 4, 5, 3, 6, 2, 7 });
            return;
        }

        public Bracket FillBracket()
        {
            Bracket bracket = new Bracket();
            List<Team> eastField = league.GetTeams("East");
            List<Team> westField = league.GetTeams("West");
            int i;
            for (i = 0; i < seeds.Count(); i++)
            {
                Team teamToAdd = eastField[rnd.Next(1, eastField.Count())];
                eastField.Remove(teamToAdd);

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
