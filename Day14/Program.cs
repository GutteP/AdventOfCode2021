using Day14;
using Library.Helpers;

Console.WriteLine("--- Day 14: Extended Polymerization ---");
Console.WriteLine("\nPart 1");

string instruction = "instruction.txt";
string input = "input.txt";



Polymerization poly = new Polymerization(InputHelper.ReadComplateTextFile(instruction)[0], InputHelper.ReadTextFile(input).ToPolymerRules());
for (int i = 0; i < 10; i++)
{
    poly.Step();
    Console.WriteLine(poly.Polymer.Length);
}


Console.WriteLine($"Apply 10 steps. What do you get if you take the quantity of the most common element and subtract the quantity of the least common element? {poly.ScorPart()}");


Console.WriteLine("\nPart 2");

for (int i = 0; i < 30; i++)
{
    poly.Step();
    Console.Write("\r {0} steps done  ", i + 11);
    Console.WriteLine(poly.Polymer.Length);
}


Console.WriteLine($"What do you get if you take the quantity of the most common element and subtract the quantity of the least common element? {poly.ScorPart()}");
