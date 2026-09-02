using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInetgratedQuery.Repositories
{
    /// <summary>
    /// IntergerArray
    /// </summary>
    internal class IntegerArray
    {
        private int[] _numbers =
       {
            2,
            5,
            8,
            3,
            7,
            5,
            1,
            9,
       };

        /// <summary>
        /// Get Numbers
        /// </summary>
        /// <returns>array</returns>
        public int[] GetNumbers()
        {
            return this._numbers;
        }
    }
}
