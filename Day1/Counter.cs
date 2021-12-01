using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class Counter
    {
        public static int TimesIncreased(IEnumerable<int> depths)
        {
            int lastValue = int.MaxValue;
            int timesIncreased = 0;
            foreach (var depth in depths)
            {
                if (depth > lastValue) timesIncreased++;
                lastValue = depth;
            }
            return timesIncreased;
        }
    }
}
