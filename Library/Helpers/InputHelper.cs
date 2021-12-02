using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helpers
{
    public static class InputHelper
    {
        public static string[] ReadTextFile(string name)
        {
            return File.ReadAllLines(name);
        }
    }
}
