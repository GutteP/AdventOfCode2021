using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class SnailfishCalculator
    {
        public Pair Add(IPair a, IPair b)
        {
            Pair p = new Pair($"[{a},{b}]");
            p = p.Reduce();
            return p;
        }
    }

    public interface IPair
    {
        void AddFromB(int v);
        void AddFromA(int v);
    }

    public record Pair : IPair
    {
        public Pair(string a)
        {
            string striped = a.Substring(1, a.Length - 2);

            int starts = 0;
            int ends = 0;
            for (int i = 0; i < striped.Length; i++)
            {
                if (striped[i] == ',')
                {
                    if (starts == ends)
                    {
                        string aa = striped.Substring(0, i);
                        string bb = striped.Substring(i + 1);

                        if (aa.Length == 1 || aa.Length == 2) A = new PairValue(int.Parse(aa));
                        else if (aa.IsSingle())
                        {
                            var sp = aa.Substring(1, aa.Length - 2).Split(',');
                            A = new Pair(new PairValue(int.Parse(sp[0])), new PairValue(int.Parse(sp[1])));
                        }
                        else A = new Pair(aa);

                        if (bb.Length == 1 || bb.Length == 2) B = new PairValue(int.Parse(bb));
                        else if (bb.IsSingle())
                        {
                            var sp = bb.Substring(1, bb.Length - 2).Split(',');
                            B = new Pair(new PairValue(int.Parse(sp[0])), new PairValue(int.Parse(sp[1])));
                        }
                        else B = new Pair(bb);

                        //if (aa.Count(x => x == ',') > 1) A = new Pair(aa);
                        //else A = new PairValue(int.Parse(aa));

                        //if(bb.Count(x => x == ',') > 1) B = new Pair(bb);
                        //else B = new PairValue(int.Parse(bb));
                        break;
                    }                   
                }
                else if (striped[i] == '[') starts++;
                else if (striped[i] == ']') ends++;

            }
        }
        public Pair(IPair a, IPair b)
        {
            A = a;
            B = b;
        }
        public IPair A { get; set; }
        public IPair B { get; set; }

        public int First()
        {
            string s = ToString();
            int starts = 0;
            int ends = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == '[')
                {
                    starts++;
                    continue;
                }
                else if (s[i] == ']')
                {
                    ends++;
                    continue;
                }
                else if(s[i] != ',')
                {
                    if(starts - ends >= 5)
                    {
                        return 1;
                    }
                    var sv = s.Substring(i).Split(',')[0].Trim('[', ']', ',');
                    var v = int.Parse(sv);
                    if (v > 9)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        public void AddFromB(int v)
        {
            if (v == 0) return;
            A.AddFromB(v);
        }

        public void AddFromA(int v)
        {
            if (v == 0) return;
            B.AddFromA(v);
        }

        public override string ToString()
        {
            return $"[{A.ToString()},{B.ToString()}]";
        }
    }

    public record PairValue : IPair
    {
        public PairValue(int v)
        {
            Value = v;
        }
        public int Value { get; set; }

        public void AddFromA(int v)
        {
            if (v == 0) return;
            Value += v;
        }

        public void AddFromB(int v)
        {
            if (v == 0) return;
            Value += v;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public static class PairHelper
    {
        public static Pair Reduce(this Pair p)
        {
            while (true)
            {
                Console.WriteLine(p.ToString());
                int first = p.First();
                if (first == 1)
                {
                    if (p.Explode(out Pair np)) p = np;
                }
                else if (first == 2)
                {
                    if (p.Split(out Pair np)) p = np;
                }
                else break;
            }
            return p;
        }

        public static bool Explode(this Pair p, out Pair nP)
        {
            nP = new Pair(p.ToString());
            var r = nP.RExplode(0, out Pair nnp);
            nP = nnp;
            return p.ToString() != nP.ToString();
        }

        public static (int?,int?) RExplode(this Pair p, int depth, out Pair np)
        {
            np = p;
            (int?, int?) returnValue = (null,null);
            if (p.A is Pair pa)
            {
                var r = pa.RExplode(depth + 1, out Pair nnp);
                if (r.Item1 == -1 && r.Item2 == -1) return r;
                np.A = nnp;
                if (r.Item2 != null)
                {
                    np.B.AddFromB((int)r.Item2);
                    if(r.Item1 != null) np.A = new PairValue(0);
                    if (r.Item1 == null) return (-1, -1);
                    return (r.Item1, null);
                }
                returnValue = (r.Item1, returnValue.Item2);
                if (returnValue != (null, null)) return returnValue;
            }
            if (p.B is Pair pb)
            {
                var r = pb.RExplode(depth + 1, out Pair nnp);
                if (r.Item1 == -1 && r.Item2 == -1) return r;
                np.B = nnp;

                if (r.Item1 != null)
                {
                    np.A.AddFromA((int)r.Item1);
                    if (r.Item2 != null) np.B = new PairValue(0);
                    if (r.Item2 == null) return (-1, -1);
                    return (null, r.Item2);
                }
                returnValue = (returnValue.Item1, r.Item2);
                if (returnValue != (null, null)) return returnValue;
            }

            if (p.A is PairValue av && p.B is PairValue bv)
            {
                if (depth >= 4)
                {
                    return (av.Value, bv.Value);
                }
            }
            return returnValue;
        }

        public static bool Split(this Pair p, out Pair sp)
        {
            Pair np = new Pair(p.ToString());
            np.A = np.A.RSplit();
            if(np.A.ToString() == p.A.ToString()) np.B = np.B.RSplit();
            sp = np;
            return p != sp;
        }

        public static IPair RSplit(this IPair p)
        {
            if (p is PairValue pv && pv.Value > 9)
            {
                return new Pair(new PairValue((int)Math.Round(((double)pv.Value / 2), MidpointRounding.ToZero)), new PairValue((int)Math.Round(((double)pv.Value / 2), MidpointRounding.AwayFromZero)));
            }
            else if (p is Pair pp)
            {

                var ppA = new Pair(pp.ToString()).A.RSplit();
                if(ppA.ToString() != pp.A.ToString())
                {
                    pp.A = ppA;
                    return pp;
                }
                pp.B = pp.B.RSplit();
                return pp;
            }
            return p;
        }

        public static IPair ToPair(this string a)
        {
            if (a.IsSingle())
            {
                var sp = a.Substring(1, a.Length - 2).Split(',');
                return new Pair(new PairValue(int.Parse(sp[0])), new PairValue(int.Parse(sp[1])));
            }
            return new Pair(a);
        }
        public static bool IsSingle(this string a)
        {
            if (a.Count(x => x == '[') == 1 && a.Count(x => x == ']') == 1) return true;
            return false;
        }
    }
}
