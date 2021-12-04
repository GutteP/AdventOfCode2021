using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    public class BingoBoard
    {
        private List<List<(int Value, bool Set)>> _board;

        private bool done = false;

        public BingoBoard(IEnumerable<string> input)
        {
            _board = new List<List<(int, bool)>>();
            foreach (var row in input)
            {
                string[] values = row.Trim().Split(' ');
                List<(int, bool)> r = new();
                foreach (string value in values)
                {
                    if (value == "") continue;
                    r.Add((int.Parse(value), false));
                }
                _board.Add(r);
            }
        }

        public bool Bingo(int num)
        {
            if (done) return false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_board[i][j].Value == num)
                    {
                        _board[i][j] = (_board[i][j].Value, true);
                        if (Check(i, j))
                        {
                            done = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Check(int i, int j)
        {
            bool bingo = true;
            for (int k = 0; k < 5; k++)
            {
                if (!_board[i][k].Set) bingo = false;

            }
            if (bingo) return bingo;
            bingo = true;
            for (int k = 0; k < 5; k++)
            {
                if (!_board[k][j].Set) bingo = false;

            }
            return bingo;
        }

        public int Calculate(int num)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!_board[i][j].Set) sum += _board[i][j].Value;
                }
            }
            return sum * num;
        }
    }
}
