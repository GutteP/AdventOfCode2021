using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22;

public record Cube
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public bool On { get; set; }
    public Cube(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public bool Toggle(Range x, Range y, Range z, bool turnOn, bool igoreBigNumbers = true)
    {


        return false;
    }
}

public class Cuboid
{
    public Cuboid()
    {
        Cubes = new Dictionary<(int x, int y, int z), bool>();
    }
    public Dictionary<(int x, int y, int z), bool> Cubes { get; set; }

    public void Step(IEnumerable rangeX, IEnumerable rangeY, IEnumerable rangeZ, bool toggle, bool igoreBigNumbers = true)
    {
        foreach (int x in rangeX)
        {
            if (igoreBigNumbers && (x > 50 || x < -50)) continue;
            foreach (int y in rangeY)
            {
                if (igoreBigNumbers && (y > 50 || y < -50)) continue;
                foreach (int z in rangeZ)
                {
                    if (igoreBigNumbers && (z > 50 || z < -50)) continue;
                    if (Cubes.ContainsKey((x, y, z)))
                    {
                        Cubes[(x, y, z)] = toggle;
                    }
                    //if (Cubes.TryGetValue((x, y, z), out bool on))
                    //{
                    //    if (toggle != on)
                    //    {
                    //        Cubes[(x, y, z)] = toggle;
                    //        toggled++;
                    //    }
                    //}
                    else
                    {
                        Cubes.Add((x, y, z), toggle);
                    }
                }
            }
        }
    }

    public long NumberOfActiveCubes()
    {
        long active = 0;
        foreach (bool on in Cubes.Values)
        {
            if (on) active++;
        }
        return active;
    }
}

public class NewCuboid
{
    public List<(int[] x, int[] y, int[] z)> Ranges { get; set; }
    public NewCuboid()
    {
        Ranges = new List<(int[] x, int[] y, int[] z)>();
    }
    public long NumberOfActiveCubes()
    {
        long numberOfActive = 0;
        foreach((int[] x, int[] y, int[] z) r in Ranges)
        {
            numberOfActive += r.x.Count() * r.y.Count() * r.z.Count();
        }
        return numberOfActive;
    }

    public void Step(int[] rangeX, int[] rangeY, int[] rangeZ, bool toggle)
    {
        if (toggle) Add(rangeX, rangeY, rangeZ);
        else if (!toggle) ConstrictRanges(rangeX, rangeY, rangeZ);
        else throw new Exception();

        MergeOverlapingInRanges();
    }
    private void Add(int[] x, int[] y, int[] z)
    {
        
        if (Ranges.Count == 0)
        {
            Ranges.Add((x, y, z));
        }
        else
        {
            int[] xs = x;
            int[] ys = y;
            int[] zs = z;
            for (int i = 0; i < Ranges.Count; i++)
            {
                xs = x.Intersect(Ranges[i].x).ToArray();
                ys = y.Intersect(Ranges[i].y).ToArray();
                zs = z.Intersect(Ranges[i].z).ToArray();
                var split = SplitIntoMultiple((xs, ys, zs));

            }
            int on = x.Count() * y.Count() * z.Count() - xs.Count() * ys.Count() * zs.Count();
        }            
    }

    private void MergeOverlapingInRanges()
    {
        for (int i = 0; i < Ranges.Count;)
        {
            for (int j = i; j < Ranges.Count; j++)
            {
                if (i == j) continue;
                if(ExpandIfOverlap(Ranges[i], Ranges[j], out (int[] x, int[] y, int[] z) result))
                {
                    Ranges.RemoveAt(j);
                    Ranges.RemoveAt(i);
                    Ranges.Add(result);
                    break;
                }
            }
            i++;
        }
    }

    private bool ExpandIfOverlap((int[] x, int[] y, int[] z) a, (int[] x, int[] y, int[] z) b, out (int[] x, int[] y, int[] z) result)
    {
        if (HasOverlap(a,b))
        {
            result = (a.x.Union(b.x).OrderBy(x => x).ToArray(), a.y.Union(b.y).OrderBy(x => x).ToArray(), a.z.Union(b.z).OrderBy(x => x).ToArray());
            return true;
        }
        result = a;
        return false;
    }

    private bool HasOverlap((int[] x, int[] y, int[] z) a, (int[] x, int[] y, int[] z) b)
    {
        var xI = a.x.Intersect(b.x);
        var yI = a.y.Intersect(b.y);
        var zI = a.z.Intersect(b.z);
        if (xI.Count() > 0 && yI.Count() > 0 && zI.Count() > 0) return true;
        return false;
    }

    private void ConstrictRanges(int[] x, int[] y, int[] z)
    {
        if (Ranges.Count == 0) return;
        for (int i = 0; i < Ranges.Count;)
        {
            if (HasOverlap(Ranges[i], (x, y, z)))
            {
                Ranges.AddRange(SplitIntoMultiple(RemoveOverlap(Ranges[i], (x, y, z))));
                Ranges.RemoveAt(i);
            }
            else i++;
        }
    }

    private (int[] x, int[] y, int[] z) RemoveOverlap((int[] x, int[] y, int[] z) a, (int[] x, int[] y, int[] z) b)
    {
        var xI = a.x.Intersect(b.x).ToArray();
        var yI = a.y.Intersect(b.y).ToArray();
        var zI = a.z.Intersect(b.z).ToArray();
        var xC = a.x.Except(xI).ToArray();
        var yC = a.y.Except(yI).ToArray();
        var zC = a.z.Except(zI).ToArray();
        return (xC, yC, zC);
    }

    private List<(int[] x, int[] y, int[] z)> SplitIntoMultiple((int[] x, int[] y, int[] z) a)
    {
        List<(int[] x, int[] y, int[] z)> result = new();
        List<int[]> xs = Split(a.x);
        List<int[]> ys = Split(a.y);
        List<int[]> zs = Split(a.z);
        foreach (var x in xs)
        {
            foreach (var y in ys)
            {
                foreach (var z in zs)
                {
                    result.Add((x, y, z));
                }
            }
        }

        return result;
    }

    private List<int[]> Split(int[] a)
    {
        List<int[]> r = new();
        var orderd = a.OrderBy(x => x);
        int v = orderd.First();
        for (int i = 0; i < a.Count(); i++)
        {
            if (v + i != orderd.ElementAt(i))
            {
                r.Add(orderd.Take(i).ToArray());
                r.Add(orderd.Take(new Range(i, orderd.Count())).ToArray());
                break;
            }
        }
        if (r.Count == 0) r.Add(orderd.ToArray());

        return r;
    }


}

public static class Helper
{
    public static (IEnumerable rangeX, IEnumerable rangeY, IEnumerable rangeZ, bool toggle) Read(string step)
    {
        string[] sp = step.Split(' ');
        bool toggle = sp[0] == "on" ? true : false;
        string[] ranges = sp[1].Split(',');
        var x = ranges[0].Split('=')[1].Split('.');
        IEnumerable rangeX = Enumerable.Range(int.Parse(x.First()), int.Parse(x.Last()) - int.Parse(x.First())+1);
        var y = ranges[1].Split('=')[1].Split('.');
        IEnumerable rangeY = Enumerable.Range(int.Parse(y.First()), int.Parse(y.Last()) - int.Parse(y.First())+1);
        var z = ranges[2].Split('=')[1].Split('.');
        IEnumerable rangeZ = Enumerable.Range(int.Parse(z.First()), int.Parse(z.Last()) - int.Parse(z.First())+1);
        return (rangeX, rangeY, rangeZ, toggle);
    }

    public static (int[] rangeX, int[] rangeY, int[] rangeZ, bool toggle) ReadToArry(string step)
    {
        string[] sp = step.Split(' ');
        bool toggle = sp[0] == "on" ? true : false;
        string[] ranges = sp[1].Split(',');
        var x = ranges[0].Split('=')[1].Split('.');
        int[] rangeX = Enumerable.Range(int.Parse(x.First()), int.Parse(x.Last()) - int.Parse(x.First()) + 1).ToArray();
        var y = ranges[1].Split('=')[1].Split('.');
        int[] rangeY = Enumerable.Range(int.Parse(y.First()), int.Parse(y.Last()) - int.Parse(y.First()) + 1).ToArray();
        var z = ranges[2].Split('=')[1].Split('.');
        int[] rangeZ = Enumerable.Range(int.Parse(z.First()), int.Parse(z.Last()) - int.Parse(z.First()) + 1).ToArray();
        return (rangeX, rangeY, rangeZ, toggle);
    }
}
