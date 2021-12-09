
using Day9;
using Library.Helpers;

Console.WriteLine("--- Day 9: Smoke Basin ---");
Console.WriteLine("\nPart 1");

//int[,] floor = new int[5, 10];
int[,] floor = new int[100, 100];
int fI = 0;
foreach (var row in InputHelper.ReadTextFile("input.txt"))
{
    for (int j = 0; j < row.Length; j++)
    {
        var c = row[j];
        floor[fI, j] = int.Parse(String.Concat(c));
    }
    fI++;
}


List<(int i, int j)> lowPoints = new();
for (int i = 0; i < floor.GetLength(0); i++)
{
    for (int j = 0; j < floor.GetLength(1); j++)
    {
        if (floor.IsLowPoint((i, j))) lowPoints.Add((i, j));
    }
}

int riskLevel = floor.ClaculateRiskLevel(lowPoints);

Console.WriteLine($"Find all of the low points on your heightmap. What is the sum of the risk levels of all low points on your heightmap? {riskLevel}");


Console.WriteLine("\nPart 2");

List<int> basinSizes = new();
foreach (var lowPoint in lowPoints)
{
    basinSizes.Add(floor.SizeOfBasin(lowPoint));
}

List<int> biggest3 = basinSizes.OrderByDescending(x => x).Take(3).ToList();


Console.WriteLine($"What do you get if you multiply together the sizes of the three largest basins? {biggest3[0] * biggest3[1] * biggest3[2]}");
