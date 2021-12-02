using Day2;
using Library.Helpers;

Console.WriteLine("Day 2!");

int aim = 0;
int depth = 0;
int horizontal = 0;

foreach (string rawInstruction in InputHelper.ReadTextFile("Values.txt"))
{
    (string Command, int Value) instruction = Helper.Deconstruct(rawInstruction);
    switch (instruction.Command)
    {
        case "forward":
            horizontal += instruction.Value;
            depth += instruction.Value * aim;
            break;
        case "down":
            aim += instruction.Value;
            break;
        case "up":
            aim -= instruction.Value;
            break;
        default:
            break;
    }
}
Console.WriteLine($"H: {horizontal}, D: {depth}, Multi: {horizontal * depth}");
