using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{

    public static class Helper
    {
        static char o1 = '(';
        static char o2 = '[';
        static char o3 = '{';
        static char o4 = '<';
        static char c1 = ')';
        static char c2 = ']';
        static char c3 = '}';
        static char c4 = '>';

        public static bool IsOpen(this char c)
        {
            return c == o1 || c == o2 || c == o3 || c == o4;
        }

        public static bool IsClosedBy(this char o, char c)
        {
            if(o == o1 && c == c1) return true;
            if (o == o2 && c == c2) return true;
            if (o == o3 && c == c3) return true;
            if (o == o4 && c == c4) return true;
            return false;
        }

        public static char ComplementedBy(this char o)
        {
            if (o == o1) return c1;
            if (o == o2) return c2;
            if (o == o3) return c3;
            if (o == o4) return c4;
            if (o == c1) return o1;
            if (o == c2) return o2;
            if (o == c3) return o3;
            if (o == c4) return o4;
            else throw new Exception();
        }

        public static int ClaculateSyntaxErrorScore(this Dictionary<char, int> illegalCharacters)
        {
            int score = 0;
            foreach (var c in illegalCharacters)
            {
                score += (c.Key.CharErrorPoints() * c.Value);
            }
            return score;
        }

        public static long ClaculateCompletionScore(List<string> compleats)
        {
            List<long> scores = new();
            foreach (string comp in compleats)
            {
                long score = 0;
                foreach (char c in comp)
                {
                    score = (5 * score) + c.CharCompletionPoints();
                }
                scores.Add(score);
            }
            scores = scores.OrderBy(x => x).ToList();
            return scores[scores.Count / 2];
        }
        private static int CharCompletionPoints(this char c)
        {
            if (c == c1) return 1;
            if (c == c2) return 2;
            if (c == c3) return 3;
            if (c == c4) return 4;
            return 0;
        }
        private static int CharErrorPoints(this char c)
        {
            if (c == c1) return 3;
            if (c == c2) return 57;
            if (c == c3) return 1197;
            if (c == c4) return 25137;
            return 0;
        }
    }
}
