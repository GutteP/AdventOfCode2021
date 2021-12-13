using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public static class Helper
    {
        public static Map ToMap(this IEnumerable<string> input)
        {
            Map map = new Map(input.Count(), input.ElementAt(0).Length);
            for (int i = 0; i < input.Count(); i++)
            {
                for (int j = 0; j < input.ElementAt(i).Length; j++)
                {
                    map.Set(i, j, (int)Char.GetNumericValue(input.ElementAt(i).ElementAt(j)));
                }
            }
            return map;
        }
    }
}
