using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class Helper
    {
        public static (string, int) Deconstruct(string @string)
        {
            string[] a = @string.Split(' ');
            return (a[0], int.Parse(a[1]));
        }
    }
}
