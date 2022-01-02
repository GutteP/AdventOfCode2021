using Day22;
using Library.Helpers;
using System.Diagnostics;

Console.WriteLine("--- Day 22: Reactor Reboot ---");
var input = InputHelper.ReadTextFile("input.txt");
Cuboid cuboid = new Cuboid();
int stepsDone = 0;

long max = 0;
(int[], int[], int[], bool) maxArry = Helper.ReadToArry(input.First());
foreach (var inp in input)
{
    var read = Helper.ReadToArry(inp);
    long v = read.rangeX.Count() * read.rangeY.Count() * read.rangeZ.Count();
    if (v > max)
    {
        max = v;
        maxArry = read;
    }
}
Console.WriteLine(max);
//Console.WriteLine("\nPart 1");
//Stopwatch sw = Stopwatch.StartNew();
//foreach (string inp in input)
//{
//    var read = Helper.Read(inp);
//    cuboid.Step(read.rangeX, read.rangeY, read.rangeZ, read.toggle, true);
//    stepsDone++;
//    Console.Write("\r {0} steps done  ", stepsDone);
//}
//Console.WriteLine($"\nExecute the reboot steps. Afterward, considering only cubes in the region x=-50..50,y=-50..50,z=-50..50, how many cubes are on? {cuboid.NumberOfActiveCubes()} in {sw.ElapsedMilliseconds}ms");

NewCuboid newCuboid = new NewCuboid();
stepsDone = 0;

Console.WriteLine("\nPart 2");
foreach (string inp in input)
{
    var read = Helper.ReadToArry(inp);
    newCuboid.Step(read.rangeX, read.rangeY, read.rangeZ, read.toggle);
    stepsDone++;
    Console.Write("\r {0} steps done  ", stepsDone);
}
Console.WriteLine($"Starting again with all cubes off, execute all reboot steps. Afterward, considering all cubes, how many cubes are on? {newCuboid.NumberOfActiveCubes()}");