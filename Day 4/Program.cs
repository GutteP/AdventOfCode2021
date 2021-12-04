using Day_4;
using Library.Helpers;

Console.WriteLine("Day 4!");
Console.WriteLine("\nPart 1\n");

List<BingoBoard> _boards = new();

var input = InputHelper.ReadTextFile("input.txt").ToList();

string randomNrs = input[0];
input.RemoveAt(0);

while(input.Count > 0)
{
    if(input[0] == "") input.RemoveAt(0);
    else
    {
        _boards.Add(new BingoBoard(input.Take(5)));
        input.RemoveRange(0, 5);
    }
}

foreach (string num in randomNrs.Split(','))
{
    bool done = false;
    foreach (BingoBoard board in _boards)
    {
        if (board.Bingo(int.Parse(num)))
        {
            Console.WriteLine($"BINGO! Result: {board.Calculate(int.Parse(num))}");
            done = true;
            break;
        }
    }
    if (done) break;
}