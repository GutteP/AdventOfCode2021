using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public static class CrabSubmarine
    {
        /// <summary>
        /// Input the number of moves to calculate total fule cost
        /// </summary>
        /// <param name="moves">Number of positions to move</param>
        /// <returns>Fule cost</returns>
        public static int CalculateFuleCost(int moves)
        {
            int cost = 0;
            for (int i = 1; i <= moves; i++)
            {
                cost += i;
            }
            return cost;
        }
    }
}
