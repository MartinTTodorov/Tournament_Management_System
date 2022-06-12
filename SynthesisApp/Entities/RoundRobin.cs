using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoundRobin : TournamentType
    {

        public override List<Match> CreateMatches(Tournament tournament)
        {
            List<User> players = tournament.PlayersInTournament;
            //If the number of players are odd, add a dummy/bye player. Bye player has ID of 0.
            //Later if the bye player has to play against someone, we dont add that match

            if (players.Count % 2 == 1)
            {
                players.Add(new User(new Account(0, "Bye", "Bye"), "Bye", "Bye", "Bye@gmail.com", "Bye", "Bye"));
            }
            List<Match> matches = new List<Match>();
            int half = players.Count / 2;
            int rotations = players.Count - 1;

            for (int i = 0; i < rotations; i++)
            {
                List<User> firstHalf = players.GetRange(0, half);
                List<User> secondHalf = players.GetRange(half, half);
                secondHalf.Reverse();

                for (int j = 0; j < firstHalf.Count; j++)
                {
                    //If a dummy/bye player is caught, this match does not get added, as every player will have to play against a dummy
                    //and automatically win anyways
                    if (firstHalf[j].Account.ID!=0 && secondHalf[j].Account.ID!=0)
                    {
                        matches.Add(new Match(firstHalf[j], secondHalf[j], 0, 0, tournament.Sport));
                    }
                }

                RotateList(players);
            }

            return matches;
        }

        private void RotateList(List<User> players)
        {
            User lastUser = players[players.Count - 1];
            players.RemoveAt(players.Count - 1);
            players.Insert(1, lastUser);
        }

        public override string ToString()
        {
            return "RoundRobin";
        }
    }
}
