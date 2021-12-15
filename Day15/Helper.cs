using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public static class Helper
    {
        public static Dictionary<string, Node> ToNodes(this IEnumerable<string> input)
        {
            Dictionary<string, Node> nodes = new();
            int lastRowIndex = 0;
            int y = 0;
            foreach (string row in input)
            {
                for (int x = 0; x < row.Length; x++)
                {
                    Node node = new Node($"{x},{y}");
                    node.Weight = double.Parse(row[x].ToString());
                    node.AddPosition(new Position(x, y));
                    nodes.Add(node.Name, node);
                }
                if (lastRowIndex == 0) lastRowIndex = row.Length - 1;
                y++;
            }

            foreach (var node in nodes)
            {
                foreach (var n in node.Value.Position.Neighbors())
                {
                    if (n.X < 0 || n.Y < 0) continue;
                    if (n.X > lastRowIndex || n.Y > (y - 1)) continue;
                    node.Value.AddNeighbor(nodes[$"{n.X},{n.Y}"], nodes[$"{n.X},{n.Y}"].Weight);
                }
            }
            return nodes;
        }

        public static List<string> CreateCompleteMap(this IEnumerable<string> rawInput)
        {
            List<List<int>> input = new();
            foreach (string row in rawInput)
            {
                List<int> intRow = new();
                List<int> longIntRow = new();
                foreach (char c in row)
                {
                    intRow.Add(int.Parse(c.ToString()));
                }
                for (int i = 0; i < 5; i++)
                {
                    longIntRow.AddRange(intRow.Tick(i));
                }
                input.Add(longIntRow);
            }


            List<List<int>> complateIntList = new();
            for (int i = 0; i < 5; i++)
            {
                complateIntList.AddRange(input.Tick(i));
            }

            List<string> result = new();
            foreach (var row in complateIntList)
            {
                string stringRow = string.Empty;
                foreach (int num in row)
                {
                    stringRow += num.ToString();
                }
                result.Add(stringRow);
            }

            return result;
        }

        private static List<List<int>> Tick(this List<List<int>> data, int steps = 1)
        {
            List<List<int>> ticked = new();
            foreach(List<int> row in data)
            {              
                ticked.Add(row.Tick(steps));
            }
            return ticked;
        }

        private static List<int> Tick(this List<int> row, int steps = 1)
        {
            List<int> newRow = new();
            foreach (int num in row)
            {
                newRow.Add((num + steps) < 10 ? (num + steps) : (num + steps)-9);
            }
            return newRow;
        }
    }
}
