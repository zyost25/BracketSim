using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSim
{
    public class League
    {
        public List<Team> westTeams = new List<Team>();
        public List<Team> eastTeams = new List<Team>();

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

        public List<Team> GetTeams(string conference)
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
