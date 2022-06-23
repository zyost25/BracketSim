using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSim
{
    public class League
    {
        public BindingList<Team> westTeams = new BindingList<Team>();
        public BindingList<Team> eastTeams = new BindingList<Team>();
        public BindingList<Team> westField = new BindingList<Team>();
        public BindingList<Team> eastField = new BindingList<Team>();
        public BindingList<Game> games = new BindingList<Game>();
        public Random rnd = new Random();
        public int gameCounter = 0;

        public void AddTeam(string name, string conference)
        {
            if (conference == "East")
            {
                eastTeams.Add(new Team(name));
            }
            else
            {
                westTeams.Add(new Team(name));
            }
            return;
        }

        public List<Team> GetTeamsList(string conference)
        {
            if (conference == "East")
            {
                return eastTeams.ToList();
            }
            else
            {
                return westTeams.ToList();
            }
        }

        public void PlayGame(Team team1, Team team2)
        {
            int team1Score = rnd.Next(60, 110);
            int team2Score = rnd.Next(60, 110);
            games.Add(new Game(team1, team2, team1Score, team2Score));
            gameCounter++;
            return;
        }

        public void ClearGames()
        {
            games.Clear();
            return;
        }
    }
}
