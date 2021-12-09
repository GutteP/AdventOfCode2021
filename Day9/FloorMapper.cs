
namespace Day9
{
    public static class FloorMapper
    {
        public static bool IsLowPoint(this int[,] floor, (int i, int j) pos)
        {
            int depth = floor.GetLength(0)-1;
            int width = floor.GetLength(1)-1;

            int v = floor[pos.i, pos.j];
            if(pos.i != 0)
            {
                if (floor[pos.i - 1,pos.j] <= v) return false;
            }
            if(pos.j != 0)
            {
                if (floor[pos.i, pos.j-1] <= v) return false;
            }
            if (pos.i != depth)
            {
                if (floor[pos.i + 1, pos.j] <= v) return false;
            }
            if (pos.j != width)
            {
                if (floor[pos.i, pos.j + 1] <= v) return false;
            }
            return true;
        }

        public static int ClaculateRiskLevel(this int[,] floor, List<(int i, int j)> lowPoints)
        {
            int riskLevel = 0;
            foreach (var pos in lowPoints)
            {
                riskLevel += (floor[pos.i, pos.j] + 1);
            }
            return riskLevel;
        }

        public static int SizeOfBasinRecursively(this int[,] floor, (int i, int j) lowPoint)
        {
            HashSet<(int, int)> partsOfBasin = new();
            partsOfBasin.Add(lowPoint);
            partsOfBasin.UnionWith(floor.ExploreBasinRecursively(lowPoint));
            return partsOfBasin.Count;
        }

        private static HashSet<(int, int)> ExploreBasinRecursively(this int[,] floor, (int i, int j) pos, HashSet<(int, int)> discoverd = null)
        {
            if (discoverd == null) discoverd = new();

            HashSet<(int, int)> newParts = new();
            if (pos.i != 0)
            {
                if (floor[pos.i - 1, pos.j] != 9 && !discoverd.Contains((pos.i - 1, pos.j))) newParts.Add((pos.i - 1, pos.j));
            }
            if (pos.j != 0)
            {
                if (floor[pos.i, pos.j - 1] != 9 && !discoverd.Contains((pos.i, pos.j - 1))) newParts.Add((pos.i, pos.j - 1));
            }
            if (pos.i != floor.GetLength(0) - 1)
            {
                if (floor[pos.i + 1, pos.j] != 9 && !discoverd.Contains((pos.i + 1, pos.j))) newParts.Add((pos.i + 1, pos.j));
            }
            if (pos.j != floor.GetLength(1) - 1)
            {
                if (floor[pos.i, pos.j + 1] != 9 && !discoverd.Contains((pos.i, pos.j + 1))) newParts.Add((pos.i, pos.j + 1));
            }

            discoverd.UnionWith(newParts);

            for (int i = 0; i < newParts.Count; i++)
            {
                discoverd.UnionWith(floor.ExploreBasinRecursively(newParts.ElementAt(i), discoverd));
            }
            return discoverd;
        }

        public static int SizeOfBasin(this int[,] floor, (int i, int j) lowPoint)
        {
            HashSet<(int, int)> discoverd = new();
            discoverd.Add(lowPoint);
            discoverd.UnionWith(floor.ExploreBasin(discoverd));
            return discoverd.Count;
        }
        private static HashSet<(int, int)> ExploreBasin(this int[,] floor, HashSet<(int i, int j)> discoverd)
        {
            for (int i = 0; i < discoverd.Count; i++)
            {
                if (discoverd.ElementAt(i).i != 0)
                {
                    if (floor[discoverd.ElementAt(i).i - 1, discoverd.ElementAt(i).j] != 9 && !discoverd.Contains((discoverd.ElementAt(i).i - 1, discoverd.ElementAt(i).j))) discoverd.Add((discoverd.ElementAt(i).i - 1, discoverd.ElementAt(i).j));
                }
                if (discoverd.ElementAt(i).j != 0)
                {
                    if (floor[discoverd.ElementAt(i).i, discoverd.ElementAt(i).j - 1] != 9 && !discoverd.Contains((discoverd.ElementAt(i).i, discoverd.ElementAt(i).j - 1))) discoverd.Add((discoverd.ElementAt(i).i, discoverd.ElementAt(i).j - 1));
                }
                if (discoverd.ElementAt(i).i != floor.GetLength(0) - 1)
                {
                    if (floor[discoverd.ElementAt(i).i + 1, discoverd.ElementAt(i).j] != 9 && !discoverd.Contains((discoverd.ElementAt(i).i + 1, discoverd.ElementAt(i).j))) discoverd.Add((discoverd.ElementAt(i).i + 1, discoverd.ElementAt(i).j));
                }
                if (discoverd.ElementAt(i).j != floor.GetLength(1) - 1)
                {
                    if (floor[discoverd.ElementAt(i).i, discoverd.ElementAt(i).j + 1] != 9 && !discoverd.Contains((discoverd.ElementAt(i).i, discoverd.ElementAt(i).j + 1))) discoverd.Add((discoverd.ElementAt(i).i, discoverd.ElementAt(i).j + 1));
                }
            }
            return discoverd;
        }
    }
}
