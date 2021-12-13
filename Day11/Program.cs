
using Day11;
using Library;
using Library.Helpers;

Console.WriteLine("--- Day 11: Dumbo Octopus ---");

Map map = InputHelper.ReadComplateTextFile("input.txt").ToMap();
int totalNumberOfFlashes = 0;
bool part1done = false;
bool part2done = false;

Console.WriteLine("\nStepping...");
for (int i = 0; i < int.MaxValue; i++)
{
    map.TickAll();
    while (true)
    {
        List<Position> toFlash = map.GetAll(Enumerable.Range(10, 20).ToArray());
        if (toFlash.Count == 0) break; 
        foreach (Position p in toFlash)
        {
            map.Set(p, -1);
            foreach (Position n in p.Neighbors(true))
            {
                if (map.Get(n) != null && map.Get(n) == - 1) continue;
                map.Tick(n);
            }
        }
    }
    int simultaneouslyFlashed = 0;
    foreach (Position flashed in map.GetAll(-1))
    {
        simultaneouslyFlashed++;
        totalNumberOfFlashes++;
        map.Set(flashed, 0);
    }

    //Part 1
    if(i == 99)
    {
        Console.Write("\r {0} steps done  ", i + 1);
        part1done = true;
        Console.WriteLine("\nPart 1");
        Console.WriteLine($"Given the starting energy levels of the dumbo octopuses in your cavern, simulate 100 steps. How many total flashes are there after 100 steps? {totalNumberOfFlashes}");
        if (part1done && part2done) break;
    }

    //Part 2
    if (simultaneouslyFlashed == map.Positions.GetLength(0) * map.Positions.GetLength(1))
    {
        Console.Write("\r {0} steps done  ", i + 1);
        part2done = true;
        Console.WriteLine("\nPart 2");
        Console.WriteLine($"If you can calculate the exact moments when the octopuses will all flash simultaneously, you should be able to navigate through the cavern. What is the first step during which all octopuses flash? {i + 1}");
        if(part1done && part2done) break;
    }
    Console.Write("\r {0} steps done  ", i+1);
}







