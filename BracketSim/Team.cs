using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSim
{
    public class Team
    {
        public int seed { get; set; }
        public string name { get; set; }

        public Team(string name)
        {
            this.name = name;
        }
    }
}
