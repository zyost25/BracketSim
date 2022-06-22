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

        public BindingList<Team> GetTeamsList(string conference)
        {
            if (conference == "East")
            {
                return eastTeams;
            }
            else
            {
                return westTeams;
            }
        }
    }
}
