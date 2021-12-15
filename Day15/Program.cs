using Day15;
using Library;
using Library.Helpers;
using System.Diagnostics;

Console.WriteLine("--- Day 15: Chiton ---");

string input = "input.txt";
IEnumerable<string> rawInput = InputHelper.ReadComplateTextFile(input);
Dictionary<string, Node> nodes = rawInput.ToNodes();
Stopwatch stopwatch = new Stopwatch();


Console.WriteLine("\nPart 1");
CavePathfinding pathfinding = new CavePathfinding(nodes, 15);
stopwatch.Start();
var r = pathfinding.AStar(nodes["0,0"], nodes[$"{rawInput.Count() - 1},{rawInput.First().Length - 1}"]);
Console.WriteLine($"What is the lowest total risk of any path from the top left to the bottom right? {r.Weight} in {stopwatch.ElapsedMilliseconds}ms");


Console.WriteLine("\nPart 2");
var rawInput2 = InputHelper.ReadComplateTextFile(input).CreateCompleteMap();
var nodes2 = rawInput2.ToNodes();
CavePathfinding pathfinding2 = new CavePathfinding(nodes2, 15);
stopwatch.Restart();
var r2 = pathfinding2.AStar(nodes2["0,0"], nodes2[$"{rawInput2.Count() - 1},{rawInput2.First().Length - 1}"]);
Console.WriteLine($"Using the full map, what is the lowest total risk of any path from the top left to the bottom right? {r2.Weight} in {stopwatch.ElapsedMilliseconds}ms");
