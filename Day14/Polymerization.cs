using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Polymerization
    {
        public int Steps { get; private set; }
        public string Polymer { get; private set; }

        public Dictionary<string, PolymerRule> Rules { get; private set; }

        public Polymerization(string startingPolymer, List<PolymerRule> rules)
        {
            Steps = 0;
            Polymer = startingPolymer;
            Rules = new Dictionary<string, PolymerRule>();
            foreach (var rule in rules)
            {
                Rules.Add(rule.Pair, rule);
            }
        }

        public void Step()
        {
            string newPolymer = Polymer[0].ToString();
            for (int i = 0; i < Polymer.Length - 1; i++)
            {
                string part = Polymer.Substring(i, 2);
                if (Rules.TryGetValue(part, out PolymerRule rule))
                {
                    newPolymer += string.Concat(rule.Insert, Polymer[i+1]);
                }
                else newPolymer += part.Substring(1);
            }
            Polymer = newPolymer;
        }

        //public async Task StepAsync()
        //{
        //    string newPolymer = Polymer[0].ToString();
        //    List<(char[] Part, long Num)> result = new();
        //    List<Task<(string Part, long Num)>> tasks = new();
        //    for (int i = 0; i < Polymer.Length - 1; i++)
        //    {
        //        string part = String.Concat(Polymer[i], Polymer[i + 1]);
        //        if (Rules.TryGetValue(, out PolymerRule rule))
        //        {
        //            tasks.Add(Step(part, i, rule));
        //        }
        //        else result.Add((new char[1] { Polymer[i + 1] }, i));

        //    }
        //    await Task.WhenAll(tasks);

        //    foreach (var task in tasks)
        //    {
        //        result.Add(await task);
        //    }
        //    foreach (var r in result.OrderBy(x => x.Num))
        //    {
        //        newPolymer += r.Part;
        //    }
        //    Polymer = newPolymer.ToCharArray();
        //}

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

        //public async Task<(char[] Part, long Num)> Step(string part, long num, PolymerRule rule)
        //{
        //    if()
        //    return (new char[2] { rule.Insert, part[1] }, num );

        //}
    }

    public class PolymerRule
    {
        public string Pair { get; private set; }
        public char Insert { get; private set; }

        public PolymerRule(string pair, char insert)
        {
            Pair = pair;
            Insert = insert;
        }
    }
}
