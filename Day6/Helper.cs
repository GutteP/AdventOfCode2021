using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class Helper
    {
        public static List<int> Transform(string[] input) 
        {
            List<int> result = new();
            string[] sp = input[0].Split(',');
            foreach (var fish in sp)
            {
                result.Add(int.Parse(fish));
            }
            return result;
        }
    }
}
