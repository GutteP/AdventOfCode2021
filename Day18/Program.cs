
using Day18;

Console.WriteLine("--- Day 18: Snailfish ---");

SnailfishCalculator _sc = new();
IPair p = "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]".ToPair();
p = _sc.Add(p, "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]".ToPair());
