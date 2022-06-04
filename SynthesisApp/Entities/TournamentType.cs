using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class TournamentType
    {
        public static List<TournamentType> TournamentTypes { get { return GetTS(); } }
        public abstract List<Match> CreateMatches(List<User> players);
        public abstract override string ToString();

        private static List<TournamentType> GetTS()
        {
            List<TournamentType> types = new List<TournamentType>();
            foreach (Type type in
            Assembly.GetAssembly(typeof(TournamentType)).GetTypes()
            .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(TournamentType))))
            {
                types.Add((TournamentType)Activator.CreateInstance(type));

            }
            return types;
        }
    }
}
