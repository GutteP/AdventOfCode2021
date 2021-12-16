using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class PartTwo
    {
        public Dictionary<string, PolymerRule> Rules { get; private set; }
        public Dictionary<string, long> PairCount { get; private set; }
        public PartTwo(string starting, List<PolymerRule> rules)
        {
            Rules = new Dictionary<string, PolymerRule>();
            foreach (var rule in rules)
            {
                Rules.Add(rule.Pair, rule);
            }
            PairCount = new Dictionary<string, long>();
            for (int i = 0; i < starting.Length - 1; i++)
            {
                string pair = starting.Substring(i, 2);
                if (PairCount.ContainsKey(pair))
                {
                    PairCount[pair]++;
                }
                else PairCount.Add(pair, 1); 
            }
        }

        public void Step()
        {
            Dictionary<string, long> newPairCount = new();
            foreach (var pair in PairCount.Keys)
            {
                foreach (var child in Rules[pair].Childs())
                {
                    if (newPairCount.ContainsKey(child))
                    {
                        newPairCount[child] += PairCount[pair];
                    }
                    else newPairCount.Add(child, PairCount[pair]);
                }
            }
            PairCount = newPairCount;
        }

        public long Scor()
        {
            Dictionary<char, long> charCount = new();
            char[] letters = "BCFHKNOPSVW".ToCharArray();
            foreach (char c in letters)
            {
                foreach (var pair in PairCount)
                {
                    if (pair.Key.Contains(c))
                    {
                        if (charCount.ContainsKey(c)) charCount[c] += pair.Value;
                        else charCount.Add(c, pair.Value);
                    }
                }
            }

            return charCount.MaxBy(x => x.Value).Value - charCount.MinBy(x => x.Value).Value;
        }



    }

    public class Recursive
    {
        public long Score(string starting, int steps, List<PolymerRule> ruleList)
        {
            Dictionary<string, PolymerRule> rules = new Dictionary<string, PolymerRule>();
            foreach (var rule in ruleList)
            {
                rules.Add(rule.Pair, rule);
            }
            List<PolymerRule> list = new();
            for (int i = 0; i < starting.Length - 1; i++)
            {
                string pair = starting.Substring(i, 2);
                list.Add(rules[pair]);
            }
            Dictionary<string, long> counts = new();
            char[] letters = "BCFHKNOPSVW".ToCharArray();
            foreach (char c in letters)
            {
                foreach (PolymerRule rule in list)
                {
                    var count = rule.CountWithSteps(c, steps, rules);
                    if (counts.ContainsKey(rule.Pair)) counts[rule.Pair] += count;
                    else counts.Add(rule.Pair, count);
                }               
            }

            return counts.MaxBy(x => x.Value).Value - counts.MinBy(x => x.Value).Value;
        }
    }
}
