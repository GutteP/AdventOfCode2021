using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public static class Helper
    {
        public static bool ConatinsAllLetters(this string a, params string[] letters)
        {
            foreach (var letter in letters)
            {
                foreach (char c in letter)
                {
                    if (!a.Contains(c)) return false;
                }
            }
            
            return true;
        }

        public static int CountNotContained(this string a, params string[] letters)
        {
            int num = 0;
            foreach (var letter in letters)
            {
                foreach (char c in letter)
                {
                    if (!a.Contains(c)) num++;
                }
            }

            return num;
        }
    }
}
