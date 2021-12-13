using Day13;
using Library;
using Library.Helpers;

Console.WriteLine("--- Day 13: Transparent Origami ---");
List<Position> positions = InputHelper.ToPositions(InputHelper.ReadTextFile("input.txt"));
var foldInstructions = InputHelper.ReadComplateTextFile("fold.txt");

Console.WriteLine("\nPart 1");
string[] singleFold = foldInstructions[0].Split(' ')[2].Split('=');

if(singleFold[0] == "y")
{
    int row = int.Parse(singleFold[1]);
    foreach (Position p in positions)
    {
        if(p.Y > row)
        {
            p.Y += (row - p.Y)*2;
        }
    }
}

else if(singleFold[0] == "x")
{
    int col = int.Parse(singleFold[1]);
    foreach (Position p in positions)
    {
        if (p.X > col)
        {
            p.X += (col - p.X) * 2;
        }
    }
}

int count = positions.Distinct().Count();

Console.WriteLine($"How many dots are visible after completing just the first fold instruction on your transparent paper? {count}");



Console.WriteLine("\nPart 2");

for (int i = 1; i < foldInstructions.Length; i++)
{
    string[] fold = foldInstructions[i].Split(' ')[2].Split('=');
    if (fold[0] == "y")
    {
        int row = int.Parse(fold[1]);
        foreach (Position p in positions)
        {
            if (p.Y > row)
            {
                p.Y += (row - p.Y) * 2;
            }
        }
    }

    else if (fold[0] == "x")
    {
        int col = int.Parse(fold[1]);
        foreach (Position p in positions)
        {
            if (p.X > col)
            {
                p.X += (col - p.X) * 2;
            }
        }
    }
}

Map map = new Map(positions);
map.Print();

Console.WriteLine($"What code do you use to activate the infrared thermal imaging camera system?");

