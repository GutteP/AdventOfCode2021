using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    public class Alu : ICloneable
    {
        private int w = 0;
        private int x = 0;
        private int y = 0;
        private int z = 0;

        private IEnumerable<string> Monad;
        private string MonadMNr = "";

        public Alu(IEnumerable<string> monad)
        {
            Monad = monad ?? throw new ArgumentNullException(nameof(monad));
        }

        public bool TestMonad(long mNr)
        {
            MonadMNr = mNr.ToString();
            if (MonadMNr.Contains('0')) return false;
            Reset();
            int i = 0;
            foreach (string ins in Monad)
            {
                InstructionInterpeter(ins.Split(' '));
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
        public bool TestPart(int p, int nr, int zV, int expected)
        {
            MonadMNr = nr.ToString();
            w = 0;
            x = 0;
            y = 0;
            z = zV;
            int highestValid = 0;
            int inp = 0;
            foreach (string ins in Monad)
            {
                if (ins.Split(' ')[0] == "inp") inp++;
                if (p == inp)
                {
                    InstructionInterpeter(ins.Split(' '));
                }
            }
            if (z == expected) return true;

            return false;
        }
        public int Part(int p, int nr, int zV)
        {
            MonadMNr = nr.ToString();
            w = 0;
            x = 0;
            y = 0;
            z = zV;
            int highestValid = 0;
            int inp = 0;
            foreach (string ins in Monad)
            {
                if (ins.Split(' ')[0] == "inp") inp++;
                if (p == inp)
                {
                    InstructionInterpeter(ins.Split(' '));
                }
            }
            return z;
        }
        public void InstructionInterpeter(string[] sp)
        {
            if (sp[0] == "inp")
            {
                switch (sp[1])
                {
                    case "w":
                        Inp(ref w, int.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "x":
                        Inp(ref x, int.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "y":
                        Inp(ref y, int.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    case "z":
                        Inp(ref z, int.Parse(MonadMNr.Substring(0, 1)));
                        MonadMNr = MonadMNr.Remove(0, 1);
                        break;
                    default:
                        break;
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
                        break;
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
                        break;
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
                        break;
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
                        break;
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
                        break;
                }
            }
            else throw new NotImplementedException();
        }

        private int GetValue(string s)
        {
            int v = 0;
            if (int.TryParse(s, out int value)) v = value;
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

        public void Inp(ref int a, int b)
        {
            a = b;
        }
        public void Add(ref int a, int b)
        {
            a = a + b;
        }
        public void Mul(ref int a, int b)
        {
            a = a * b;
        }
        public void Div(ref int a, int b)
        {
            if(a == 0 || b == 0)
            {
                return;
            }
            a = a/b;
        }
        public void Mod(ref int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return;
            }
            a = a%b;
        }
        public void Eql(ref int a, int b)
        {
            a = a == b ? 1 : 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
