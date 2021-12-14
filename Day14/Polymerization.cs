using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//System.OutOfMemoryException: 'Array dimensions exceeded supported range.'

namespace Day14
{
    public class Polymerization
    {
        public string Polymer { get; private set; }

        public Dictionary<string, PolymerRule> Rules { get; private set; }

        public Polymerization(string startingPolymer, List<PolymerRule> rules)
        {
            Polymer = startingPolymer;
            Rules = new Dictionary<string, PolymerRule>();
            foreach (var rule in rules)
            {
                Rules.Add(rule.Pair, rule);
            }
        }

        public void Step()
        {
            Queue<char> newPolymer = new();
            newPolymer.Enqueue(Polymer[0]);
            for (int i = 0; i < Polymer.Length - 1; i++)
            {
                string part = Polymer.Substring(i, 2);
                if (Rules.TryGetValue(part, out PolymerRule rule))
                {
                    newPolymer.Enqueue(rule.Insert);
                    newPolymer.Enqueue(Polymer[i + 1]);
                }
                else newPolymer.Enqueue(Polymer[i + 1]);
            }
            StringBuilder sb = new StringBuilder(newPolymer.Count);
            while(newPolymer.Count != 0)
            {
                sb.Append(newPolymer.Dequeue());
            }
            Polymer = sb.ToString();
        }

        public long ScorPart()
        {
            char most = default;
            char least = default;

            long countMostCommon = 0;
            long countLeastCommon = long.MaxValue;
            char[] letters = "BCFHKNOPSVW".ToCharArray();
            foreach (char c in letters)
            {
                long count = Polymer.Where(x => x == c).Count();
                if (count > countMostCommon)
                {
                    countMostCommon = count;
                    most = c;
                }
                if (count < countLeastCommon && count != 0)
                {
                    countLeastCommon = count;
                    least = c;
                }
            }
            return countMostCommon - countLeastCommon;
        }

        public long Count(char c)
        {
            return Polymer.Where(x => x == c).Count();
        }
    }
}
