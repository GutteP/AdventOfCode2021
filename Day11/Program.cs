
using Library;
using Library.Helpers;

Console.WriteLine("--- Day 11: Dumbo Octopus ---");

Console.WriteLine("\nStepping...");

Map map = new Map(InputHelper.ReadComplateTextFile("input.txt").ToList());
int flashes = 0;
int allFlashesOn = 0;
bool part1 = false;
bool part2 = false;
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
        flashes++;
        map.Set(flashed, 0);
    }
    if(i == 99)
    {
        Console.Write("\r {0} steps done  ", i + 1);
        part1 = true;
        Console.WriteLine("\nPart 1");
        Console.WriteLine($"Given the starting energy levels of the dumbo octopuses in your cavern, simulate 100 steps. How many total flashes are there after 100 steps? {flashes}");
        if (part1 && part2) break;
    }
    if (simultaneouslyFlashed == map.Positions.GetLength(0) * map.Positions.GetLength(1))
    {
        Console.Write("\r {0} steps done  ", i + 1);
        part2 = true;
        allFlashesOn = i+1;
        Console.WriteLine("\nPart 2");
        Console.WriteLine($"If you can calculate the exact moments when the octopuses will all flash simultaneously, you should be able to navigate through the cavern. What is the first step during which all octopuses flash? {allFlashesOn}");
        if(part1 && part2) break;
    }
    Console.Write("\r {0} steps done  ", i+1);
}







