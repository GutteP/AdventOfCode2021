using Day12;
using Library;
using Library.Helpers;

Console.WriteLine("--- Day 12: Passage Pathing ---");

Dictionary<string, Node> nodes = Helper.NodeFromInput(InputHelper.ReadTextFile("input.txt"));
PathFinder pathFinder = new PathFinder(nodes);

Console.WriteLine("\nPart 1");
var paths = pathFinder.FindPaths();
Console.WriteLine($"How many paths through this cave system are there that visit small caves at most once? {paths.Count}");


Console.WriteLine("\nPart 2");
var paths2 = pathFinder.FindPaths(true);
Console.WriteLine($"Given these new rules, how many paths through this cave system are there? {paths2.Count}");
