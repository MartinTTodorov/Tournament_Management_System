using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class SportType
    {
        public static List<SportType> SportTypes { get { return GetSportTypes(); } }
        public abstract void ValidateResults( int score1, int score2);
        public abstract override string ToString();

        private static List<SportType> GetSportTypes()
        {
            List<SportType> types = new List<SportType>();
            foreach (Type type in
            Assembly.GetAssembly(typeof(SportType)).GetTypes()
            .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(SportType))))
            {
                types.Add((SportType)Activator.CreateInstance(type));

            }
            return types;
        }
    }
}
