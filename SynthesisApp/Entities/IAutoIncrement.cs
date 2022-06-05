using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IAutoIncrement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns> The ID from the database that is needed to create an object</returns>
        public int GetID();
    }
}
