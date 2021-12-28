using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    public class Alu : ICloneable
    {
        private long w = 0;
        private long x = 0;
        private long y = 0;
        private long z = 0;

        private IEnumerable<string> Monad;
        private IEnumerable<string> BinaryProgram;
        private string MonadMNr = "";

        public Alu(IEnumerable<string> monad)
        {
            Monad = monad ?? throw new ArgumentNullException(nameof(monad));
            BinaryProgram = InputHelper.ReadComplateTextFile("BinaryProgram.txt");
        }

        public bool TestMonad(long mNr)
        {
            MonadMNr = mNr.ToString();
            if (MonadMNr.Contains('0')) return false;
            Reset();
            long i = 0;
            foreach (string ins in Monad)
            {
                Instructionlongerpeter(ins.Split(' '));
                i++;
            }
            return z == 0; 
        }



        public void Reset()
        {
            w = 0;
            x = 0;
            y = 0;
            z = 0;
        }
        public bool TestPart(long p, long nr, long zV, long expected)
        {
            MonadMNr = nr.ToString();
            w = 0;
            x = 0;
            y = 0;
            z = zV;
            long highestValid = 0;
            long inp = 0;
            foreach (string ins in Monad)
            {
                if (ins.Split(' ')[0] == "inp") inp++;
                if (p == inp)
                {
                    Instructionlongerpeter(ins.Split(' '));
                }
            }
            if (z == expected) return true;

            return false;
        }
        public long Part(long p, long nr, long zV)
        {
            MonadMNr = nr.ToString();
            w = 0;
            x = 0;
            y = 0;
            z = zV;
            long highestValid = 0;
            long inp = 0;
            foreach (string ins in Monad)
            {
                var sp = ins.Split(' ');
                if (sp[0] == "inp") inp++;
                if (p == inp)
                {
                    Instructionlongerpeter(sp);
                }
            }
            return z;
        }
        public void Instructionlongerpeter(string[] sp)
        {
            if (sp[0] == "inp")
            {
                switch (sp[1])
                {
                    case "w":
                        Inp(ref w, long.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "x":
                        Inp(ref x, long.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "y":
                        Inp(ref y, long.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "z":
                        Inp(ref z, long.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    default:
                        throw new Exception();
                }
            }
            else if (sp[0] == "add")
            {
                switch (sp[1])
                {
                    case "w":
                        Add(ref w, GetValue(sp[2]));
                        break;
                    case "x":
                        Add(ref x, GetValue(sp[2]));
                        break;
                    case "y":
                        Add(ref y, GetValue(sp[2]));
                        break;
                    case "z":
                        Add(ref z, GetValue(sp[2]));
                        break;
                    default:
                        throw new Exception();
                }
            }
            else if (sp[0] == "mul")
            {
                switch (sp[1])
                {
                    case "w":
                        Mul(ref w, GetValue(sp[2]));
                        break;
                    case "x":
                        Mul(ref x, GetValue(sp[2]));
                        break;
                    case "y":
                        Mul(ref y, GetValue(sp[2]));
                        break;
                    case "z":
                        Mul(ref z, GetValue(sp[2]));
                        break;
                    default:
                        throw new Exception();
                }
            }
            else if (sp[0] == "div")
            {
                switch (sp[1])
                {
                    case "w":
                        Div(ref w, GetValue(sp[2]));
                        break;
                    case "x":
                        Div(ref x, GetValue(sp[2]));
                        break;
                    case "y":
                        Div(ref y, GetValue(sp[2]));
                        break;
                    case "z":
                        Div(ref z, GetValue(sp[2]));
                        break;
                    default:
                        throw new Exception();
                }
            }
            else if (sp[0] == "mod")
            {
                switch (sp[1])
                {
                    case "w":
                        Mod(ref w, GetValue(sp[2]));
                        break;
                    case "x":
                        Mod(ref x, GetValue(sp[2]));
                        break;
                    case "y":
                        Mod(ref y, GetValue(sp[2]));
                        break;
                    case "z":
                        Mod(ref z, GetValue(sp[2]));
                        break;
                    default:
                        throw new Exception();
                }
            }
            else if (sp[0] == "eql")
            {
                switch (sp[1])
                {
                    case "w":
                        Eql(ref w, GetValue(sp[2]));
                        break;
                    case "x":
                        Eql(ref x, GetValue(sp[2]));
                        break;
                    case "y":
                        Eql(ref y, GetValue(sp[2]));
                        break;
                    case "z":
                        Eql(ref z, GetValue(sp[2]));
                        break;
                    default:
                        throw new Exception();
                }
            }
            else throw new NotImplementedException();
        }

        private long GetValue(string s)
        {
            long v = 0;
            if (long.TryParse(s, out long value)) v = value;
            else
            {
                switch (s)
                {
                    case "w":
                        v = w;
                        break;
                    case "x":
                        v = x;
                        break;
                    case "y":
                        v = y;
                        break;
                    case "z":
                        v = z;
                        break;
                    default:
                        throw new Exception();
                }
            }
            return v;
        }

        public (long w, long x, long y, long z) ConvertToBinary(long toConvert)
        {
            Reset();
            w = toConvert;
            foreach (var ins in BinaryProgram)
            {
                if (ins == "inp w") continue;
                Instructionlongerpeter(ins.Split(' '));
            }
            return (w, x, y, z);
        }

        public void Inp(ref long a, long b)
        {
            a = b;
        }
        public void Add(ref long a, long b)
        {
            a = a + b;
        }
        public void Mul(ref long a, long b)
        {
            a = a * b;
        }
        public void Div(ref long a, long b)
        {
            if(a == 0 || b == 0)
            {
                return;
            }
            double da = (double)a / (double)b;
            da = Math.Truncate(da);
            a = (long)da;
        }
        public void Mod(ref long a, long b)
        {
            
            if (a == 0 || b == 0)
            {
                return;
            }
            a = (Math.Abs(a * b) + a) % b;
        }
        public void Eql(ref long a, long b)
        {
            a = a == b ? 1 : 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
