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

        /// <summary>
        /// Takes a comma separated string and splits it into a List<int>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> CommaSeparatedToIntList(string input)
        {
            List<int> result = new();
            string[] sp = input.Split(',');
            foreach (var fish in sp)
            {
                result.Add(int.Parse(fish));
            }
            return result;
        }

        /// <summary>
        /// Takes a IEnumerable of strings with the format "int,int"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<Position> ToPositions(IEnumerable<string> input)
        {
            List<Position> positions = new();
            foreach (var p in input)
            {
                var sp = p.Split(',');
                positions.Add(new Position(int.Parse(sp[0]), int.Parse(sp[1])));
            }
            return positions;
        }
    }
}
