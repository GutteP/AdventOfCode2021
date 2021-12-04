using Day_4;
using Library.Helpers;

Console.WriteLine("Day 4!");
Console.WriteLine("\nPart 1 and 2\n");

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
BingoBoard first = default;
int numOfWins = 0;
foreach (string num in randomNrs.Split(','))
{
    foreach (BingoBoard board in _boards)
    {
        if (board.Bingo(int.Parse(num)))
        {
            numOfWins++;
            if (first == default)
            {
                Console.WriteLine($"First BINGO! Result: {board.Calculate(int.Parse(num))}");
                first = board;
            }       

            if(numOfWins == 100)
            {
                Console.WriteLine($"Last BINGO! Result: {board.Calculate(int.Parse(num))}");
            }
        }
    }
}