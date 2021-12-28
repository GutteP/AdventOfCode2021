using Day25;
using Library;
using Library.Helpers;

Console.WriteLine("--- Day 25: Sea Cucumber --- \n");

var input = InputHelper.ReadComplateTextFile("input.txt").ToList();
SeaFloor map = new SeaFloor(input[0].Length, input.Count);
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[0].Length; x++)
    {
        int val = input[y][x] == '.' ? 0 : input[y][x] == '>' ? 1 : 2;
        map.Set(x, y, val);
    }
}

int steps = 0;
while (true)
{
    steps++;
    if (!map.Step()) break;
    
}
Console.WriteLine($"Find somewhere safe to land your submarine. What is the first step on which no sea cucumbers move? {steps}");
