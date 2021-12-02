using Library.Helpers;

Console.WriteLine("Day 2!");

string[] instru = InputHelper.ReadTextFile("values.txt");

int aim = 0;
int depth = 0;
int horizontal = 0;

foreach (string ins in instru)
{
    var sp = ins.Split(' ');
    switch (sp[0])
    {
        case "forward":
            horizontal += int.Parse(sp[1]);
            depth += int.Parse(sp[1]) * aim;
            break;
        case "down":
            aim += int.Parse(sp[1]);
            break;
        case "up":
            aim -= int.Parse(sp[1]);
            break;
        default:
            break;
    }

}
Console.WriteLine($"H: {horizontal}, D: {depth}, Multi: {horizontal * depth}");
