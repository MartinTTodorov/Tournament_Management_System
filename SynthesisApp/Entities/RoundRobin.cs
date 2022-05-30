using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoundRobin : TournamentType
    {

        private List<User> players = new List<User>();

        public List<User> Players { get { return players; } }

        public RoundRobin(List<User> players)
        {
            this.players = players;
        }

        public override List<Match> CreateMatches(List<User> players) 
        {
            //pri suzdavaneto na machovete, player1score i player2score shte budat 0
            //a posle kato se igraqt samite machove, kato zavurshat, shte gi updatevam v bazata danni s rezultata i
            if (players.Count%2==1)
            {
                players.Add(new User(new Account(5100, "Bye", "Bye"), "Bye", "Bye", "Bye", "Bye", "Bye"));
            }
            List<Match> matches = new List<Match>();
            int half = players.Count/2;
            int rotations = players.Count - 1;

            for (int i = 0; i < rotations; i++)
            {
                List<User> firstHalf = players.GetRange(0, half);
                List<User> secondHalf = players.GetRange(half, players.Count);
                secondHalf.Reverse();

                for (int j = 0; j < firstHalf.Count; j++)
                {
                    matches.Add(new Match(firstHalf[i], secondHalf[i], 0, 0));
                }

                RotateList(players);
            }

            return matches;
        }

        public void RotateList(List<User> players)
        {
            User lastUser = players[players.Count-1];
            players.RemoveAt(players.Count-1);
            players.Insert(1, lastUser);
        }
    }
}
