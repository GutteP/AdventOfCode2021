using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public static class Helper
    {
        public static int[,] Map(List<(int x1, int y1, int x2, int y2)> lines, int[,] map)
        {
            foreach (var line in lines)
            {
                if (line.IsVerticalOrHorizontal())
                {
                    int x = line.x1;
                    while (true)
                    {
                        int y = line.y1;
                        while (true)
                        {
                            map[x, y]++;
                            if (y == line.y2) break;
                            else if (line.y1 < line.y2) y++;
                            else if (line.y1 > line.y2) y--;
                        }
                        if (x == line.x2) break;
                        else if (line.x1 < line.x2) x++;
                        else if (line.x1 > line.x2) x--;
                    }
                }
                else
                {
                    bool xIncreasing = line.x2 > line.x1;
                    bool yIncreasing = line.y2 > line.y1;
                    int x = -1;
                    int y = -1;
                    for (int i = 0; i <= Math.Abs(line.x1-line.x2); i++)
                    {
                        if (xIncreasing) x = line.x1 + i;
                        else x = line.x1 - i;
                        if (yIncreasing) y = line.y1 + i;
                        else y = line.y1 - i;

                        map[x, y]++;
                    }
                }               
            }
            return map;
        }

        public static int CheckOverlap(int[,] canvas)
        {
            int count = 0;
            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLength(1); j++)
                {
                    if (canvas[i, j] > 1) count++;
                }
            }
            return count;
        }

        public static bool IsVerticalOrHorizontal(this (int x1, int y1, int x2, int y2) line)
        {
            return line.x1 == line.x2 || line.y1 == line.y2;
        }
    }
}
