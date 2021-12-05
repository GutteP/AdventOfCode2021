using Day5;
using Library.Helpers;

Console.WriteLine("Day 5!");
Console.WriteLine("\nPart 1");

List<(int x1, int y1, int x2, int y2)> lines = new();
foreach (var row in InputHelper.ReadTextFile("input.txt"))
{
    var sp = row.Split(',',' ');
    lines.Add((int.Parse(sp[0]), int.Parse(sp[1]), int.Parse(sp[3]), int.Parse(sp[4])));
}

int[,] map = new int[1000, 1000];
Helper.Map(lines.Where(x => x.IsVerticalOrHorizontal()).ToList(), map);
int count1 = Helper.CheckOverlap(map);

Console.WriteLine($"Consider only horizontal and vertical lines. At how many points do at least two lines overlap? {count1} times!");

Console.WriteLine("\nPart 2");

Helper.Map(lines.Where(x => !x.IsVerticalOrHorizontal()).ToList(), map);
int count2 = Helper.CheckOverlap(map);

Console.WriteLine($"Consider all of the lines. At how many points do at least two lines overlap? {count2} times!");
