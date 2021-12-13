using Day7;
using Library.Helpers;

Console.WriteLine("Day 5!");
Console.WriteLine("\nPart 1");

List<int> submarinePositions = InputHelper.CommaSeparatedToIntList(InputHelper.ReadComplateTextFile("input.txt")[0]);

//Arrange all submarine positions in a table where KEY is the position and VALUE the number of submarines on that position
Dictionary<int, int> table = new Dictionary<int, int>();
foreach (int p in submarinePositions)
{
    if (table.ContainsKey(p)) table[p]++;
    else table.Add(p, 1);
}

//Calculate target
int totalCost = int.MaxValue;
for (int i = submarinePositions.Min(); i <= submarinePositions.Max(); i++)
{
    int iCost = 0;
    foreach (var group in table)
    {
        int groupCost = (Math.Abs(group.Key - i)) * group.Value;
        iCost += groupCost;
    }
    if(iCost < totalCost)
    {
        totalCost = iCost;
    }
}

Console.WriteLine($"Determine the horizontal position that the crabs can align to using the least fuel possible. How much fuel must they spend to align to that position? {totalCost}");


Console.WriteLine("\nPart 2");

//Calculate target with new information
int totalCost2 = int.MaxValue;
for (int i = submarinePositions.Min(); i <= submarinePositions.Max(); i++)
{
    int iCost = 0;
    foreach (var group in table)
    {
        int groupCost = (CrabSubmarine.CalculateFuleCost(Math.Abs(group.Key - i))) * group.Value;
        iCost += groupCost;
    }
    if (iCost < totalCost2)
    {
        totalCost2 = iCost;
    }
}

Console.WriteLine($"Determine the horizontal position that the crabs can align to using the least fuel possible so they can make you an escape route! How much fuel must they spend to align to that position? {totalCost2}");