//System.OutOfMemoryException: 'Array dimensions exceeded supported range.'

namespace Day14
{
    public record PolymerRule
    {
        public string Pair { get; private set; }
        public char Insert { get; private set; }

        public PolymerRule(string pair, char insert)
        {
            Pair = pair;
            Insert = insert;
        }

        public List<string> Childs()
        {
            return new List<string> { String.Concat(Pair[0], Insert), String.Concat(Insert, Pair[1]) };
        }

        public long Count(char c)
        {
            return String.Concat(Pair[0], Insert, Pair[1]).Where(x => x == c).Count();
        }

        public long CountWithSteps(char c, int steps, Dictionary<string, PolymerRule> rules)
        {
            if (steps == 0) return /*(long)Pair.Where(x => x == c).Count()*/ 0;
            long count = (long)Pair.Where(x => x == c).Count();
            List<PolymerRule> s = new List<PolymerRule> { rules[String.Concat(Pair[0], Insert)], rules[String.Concat(Insert, Pair[1])] };
            foreach (PolymerRule r in s)
            {
                count += r.CountWithSteps(c, steps - 1, rules);
            }
            return count;
        }
    }
}
