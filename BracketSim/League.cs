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

        public Team GetTeam(string name, string conference)
        {
            int i;
            if (conference == "East")
            {
                for (i = 0; i < eastTeams.Count(); i++)
                {
                    if (eastTeams[i].name == name)
                    {
                        return eastTeams[i];
                    }
                }
            }
            else
            {
                for (i = 0; i < westTeams.Count(); i++)
                {
                    if (westTeams[i].name == name)
                    {
                        return westTeams[i];
                    }
                }
            }
            return new Team("");
        }

        public void AddGame(Game game)
        {
            games.Add(game);
            return;
        }
    }
}
