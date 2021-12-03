using Library.Helpers;
using System.Linq;

Console.WriteLine("Day 3!");
Console.WriteLine("\nPart 1\n");

string binaryGammaRate = "";
string binaryEpsilonRate = "";

for (int i = 0; i < 12; i++)
{
    int numberOf1 = 0;
    int numberOf0 = 0;
    foreach (string row in InputHelper.ReadTextFile("input.txt"))
    {
        if (row[i] == '1') numberOf1++;
        else numberOf0++;
    }

    if (numberOf1 > numberOf0)
    {
        binaryGammaRate += '1';
        binaryEpsilonRate += '0';
    }
    else
    {
        binaryGammaRate += '0';
        binaryEpsilonRate += '1';
    }
}

int gammaRate = Convert.ToInt32(binaryGammaRate, 2);
int epsilonRate = Convert.ToInt32(binaryEpsilonRate, 2);

Console.WriteLine($"What is the power consumption of the submarine? GammaRate: {gammaRate}, epsilonRate: {epsilonRate}, multi: {gammaRate * epsilonRate}");


Console.WriteLine("\nPart 2\n");

var mostCommon = InputHelper.ReadComplateTextFile("input.txt").ToList();
var leastCommon = InputHelper.ReadComplateTextFile("input.txt").ToList();

for (int i = 0; i < 12; i++)
{
    if(mostCommon.Count() > 1)
    {
        var oneC = mostCommon.Where(x => x[i] == '1').ToList();
        var zeroC = mostCommon.Where(x => x[i] == '0').ToList();

        if (oneC.Count() >= zeroC.Count()) mostCommon = oneC;
        else mostCommon = zeroC;
    }
    
    if(leastCommon.Count() > 1)
    {
        var oneL = leastCommon.Where(x => x[i] == '1').ToList();
        var zeroL = leastCommon.Where(x => x[i] == '0').ToList();

        if (oneL.Count() >= zeroL.Count()) leastCommon = zeroL;
        else leastCommon = oneL;
    }   
}

int generator = Convert.ToInt32(mostCommon.First(), 2);
int scrubber = Convert.ToInt32(leastCommon.First(), 2);

Console.WriteLine($"What is the life support rating of the submarine? oxygen generator rating: {generator}, CO2 scrubber rating: {scrubber}, multi: {generator * scrubber}");