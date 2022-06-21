using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSim
{
    public class Game
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }
        public int team1Score { get; set; }
        public int team2Score { get; set; }
        public Team winner { get; set; }
        public Random rnd = new Random();
        public Game(Team team1, Team team2, int team1Score, int team2Score)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.team1Score = team1Score;
            this.team2Score = team2Score;
            if (team1Score > team2Score)
            {
                this.winner = team1;
            }
            else
            {
                this.winner = team2;
            }
        }
    }
}
