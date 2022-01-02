using Day18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Day18Tests
    {
        private readonly SnailfishCalculator _sc;
        public Day18Tests()
        {
            _sc = new SnailfishCalculator();
        }
        [TestMethod]
        public void Add_Test_1()
        {
            List<string> list = new() { "[1,1]", "[2,2]", "[3,3]", "[4,4]" };

            IPair p = default;
            foreach (var v in list)
            {
                if(p == default)
                {
                    p = v.ToPair();
                    continue;
                }
                p = _sc.Add(p, v.ToPair());
            }
            Assert.AreEqual("[[[[1,1],[2,2]],[3,3]],[4,4]]", p.ToString());
        }
        
        [TestMethod]
        public void Add_Test_2()
        {
            List<string> list = new() { "[1,1]", "[2,2]", "[3,3]", "[4,4]", "[5,5]" };

            IPair p = default;
            foreach (var v in list)
            {
                if (p == default)
                {
                    p = v.ToPair();
                    continue;
                }
                p = _sc.Add(p, v.ToPair());
            }
            Assert.AreEqual("[[[[3,0],[5,3]],[4,4]],[5,5]]", p.ToString());
        }

        [TestMethod]
        public void Add_Test_3()
        {
            List<string> list = new() { "[[[[3,0],[5,3]],[4,4]],[5,5]]", "[6,6]" };

            IPair p = default;
            foreach (var v in list)
            {
                if (p == default)
                {
                    p = v.ToPair();
                    continue;
                }
                p = _sc.Add(p, v.ToPair());
            }
            Assert.AreEqual("[[[[5,0],[7,4]],[5,5]],[6,6]]", p.ToString());
        }

        [TestMethod]
        public void Add_Test_4()
        {
            List<string> list = new() 
            { 
                "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]",
                "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]",
                "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]",
                "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]",
                "[7,[5,[[3,8],[1,4]]]]",
                "[[2,[2,2]],[8,[8,1]]]",
                "[2,9]",
                "[1,[[[9,3],9],[[9,0],[0,7]]]]",
                "[[[5,[7,4]],7],1]",
                "[[[[4,2],2],6],[8,7]]"
            };

            List<string> stepResults = new()
            {
                "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]",
                "[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]",
                "[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]",
                "[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]",
                "[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]",
                "[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]",
                "[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]",
                "[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]",
                "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]",
            };

            IPair p = list[0].ToPair();
            for (int i = 1; i < list.Count; i++)
            {
                p = _sc.Add(p, list[i].ToPair());
                Assert.AreEqual(stepResults[i-1], p.ToString());
            }
            Assert.AreEqual("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", p.ToString());
        }

        [TestMethod]
        public void Explode_Test()
        {
            List<string> starts = new() { "[[[[[9,8],1],2],3],4]", "[7,[6,[5,[4,[3,2]]]]]", "[[6,[5,[4,[3,2]]]],1]", "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]" };
            List<string> ends = new() { "[[[[0,9],2],3],4]", "[7,[6,[5,[7,0]]]]", "[[6,[5,[7,0]]],3]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]" };
            for (int i = 0; i < 5; i++)
            {
                Pair p = new Pair(starts[i]);
                p.Explode(out Pair ep);
                p = ep;
                Assert.AreEqual(ends[i], p.ToString());
            }
            
        }

        [TestMethod]
        public void Pair_Test_1()
        {
            Pair p = new Pair("[[[[1,1],[2,2]],[3,3]],[4,4]]");
            Assert.AreEqual("[[[[1,1],[2,2]],[3,3]],[4,4]]", p.ToString());
        }

        [TestMethod]
        public void Add_Reduce_1()
        {
            Pair p = new Pair("[[[[4,3],4],4],[7,[[8,4],9]]]");
            p = _sc.Add(p, "[1,1]".ToPair());
            Assert.AreEqual("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", p.ToString());
        }
    }
}