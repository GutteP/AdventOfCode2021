using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public static class Helper
    {
        public static Map ToMap(this List<Position> positions)
        {
            Map map = new Map(positions.MaxBy(x => x.Y).Y + 1, positions.MaxBy(y => y.X).X + 1);
            foreach (Position p in positions)
            {
                map.Set(p.Y, p.X, 1);
            }
            return map;
        }

        public static void Print(this Map map)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < map.Positions.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < map.Positions.GetLength(1); j++)
                {
                    row += map.Positions[i, j] > 0 ? "#" : ".";
                }
                Console.WriteLine(row);
            }
        }
    }
}
