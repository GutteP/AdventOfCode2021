using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helpers
{
    public static class InputHelper
    {
        public static string[] ReadComplateTextFile(string name)
        {
            return File.ReadAllLines(name);
        }

        public static IEnumerable<string> ReadTextFile(string name)
        {
            using (StreamReader sr = File.OpenText(name))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }
    }
}
