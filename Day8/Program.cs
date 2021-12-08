using Day8;
using Library.Helpers;

Console.WriteLine("--- Day 8: Seven Segment Search ---");
Console.WriteLine("\nPart 1");

Dictionary<int, int> numbers = new();
numbers.Add(0, 0);
numbers.Add(1, 0);
numbers.Add(2, 0);
numbers.Add(3, 0);
numbers.Add(5, 0);
numbers.Add(6, 0);
numbers.Add(7, 0);
numbers.Add(4, 0);
numbers.Add(8, 0);
numbers.Add(9, 0);
foreach (var row in InputHelper.ReadTextFile("input.txt"))
{
    var values = row.Split('|')[1].Trim().Split(' ');
    foreach (var value in values)
    {
        switch (value.Length)
        {
            case 2:
                numbers[1]++;
                break;
            case 3:
                numbers[7]++;
                break;
            case 4:
                numbers[4]++;
                break;
            case 7:
                numbers[8]++;
                break;
            default:
                break;
        }
    }
}

Console.WriteLine($"In the output values, how many times do digits 1, 4, 7, or 8 appear? {numbers[1] + numbers[7] + numbers[4] + numbers[8]}");


Console.WriteLine("\nPart 2");
int sum = 0;
foreach (var row in InputHelper.ReadTextFile("input.txt"))
{
    var values = row.Split('|')[1].Trim().Split(' ');
    var unique = row.Split('|')[0].Trim().Split(' ');

    string zero = String.Empty;
    string one = String.Concat(unique.Where(x => x.Length == 2).FirstOrDefault().OrderBy(c => c));
    string two = String.Empty;
    string three = String.Empty;
    string four = String.Concat(unique.Where(x => x.Length == 4).FirstOrDefault().OrderBy(c => c));
    string five = String.Empty;
    string six = String.Empty;
    string seven = String.Concat(unique.Where(x => x.Length == 3).FirstOrDefault().OrderBy(c => c));
    string eight = String.Concat(unique.Where(x => x.Length == 7).FirstOrDefault().OrderBy(c => c));
    string nine = String.Empty;

    three = String.Concat(unique.Where(x => x.Length == 5).Where(x => x.ConatinsAllLetters(one, seven)).FirstOrDefault().OrderBy(c => c));
    nine = String.Concat(unique.Where(x => x.Length == 6).Where(x => x.ConatinsAllLetters(four, one, seven, three)).FirstOrDefault().OrderBy(c => c));
    zero = String.Concat(unique.Where(x => x.Length == 6).Where(x => x.ConatinsAllLetters(one, seven) && !x.ConatinsAllLetters(four)).FirstOrDefault().OrderBy(c => c));
    six = String.Concat(unique.Where(x => x.Length == 6).Where(x => String.Concat(x.OrderBy(c => c)) != zero && String.Concat(x.OrderBy(c => c)) != nine).FirstOrDefault().OrderBy(c => c));
    five = String.Concat(unique.Where(x => x.Length == 5).Where(x => x.CountNotContained(six) == 1).FirstOrDefault().OrderBy(c => c));
    two = String.Concat(unique.Where(x => x.Length == 5).Where(x => !x.ConatinsAllLetters(three) && !x.ConatinsAllLetters(five)).FirstOrDefault().OrderBy(c => c));

    string rV = String.Empty;
    foreach (var value in values)
    {
        var ord = String.Concat(value.OrderBy(c => c));
        if (ord == zero) rV = rV + "0";
        else if (ord == one) rV = rV + "1";
        else if (ord == two) rV = rV + "2";
        else if (ord == three) rV = rV + "3";
        else if (ord == four) rV = rV + "4";
        else if (ord == five) rV = rV + "5";
        else if (ord == six) rV = rV + "6";
        else if (ord == seven) rV = rV + "7";
        else if (ord == eight) rV = rV +"8";
        else if (ord == nine) rV = rV + "9";
    }
    sum += int.Parse(rV);
}

Console.WriteLine($"What do you get if you add up all of the output values? {sum}");

