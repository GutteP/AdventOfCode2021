using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public static class Helper
    {
        public static List<PolymerRule> ToPolymerRules(this IEnumerable<string> rawRules)
        {
            List<PolymerRule> rules = new();
            foreach (string rawRule in rawRules)
            {
                string[] sp = rawRule.Split(" -> ");
                rules.Add(new PolymerRule(sp[0], sp[1][0]));
            }
            return rules;
        }
    }
}
