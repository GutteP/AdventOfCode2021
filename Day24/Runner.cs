using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    public class Runner
    {
        private readonly Alu alu;
        public Runner()
        {
            alu = new Alu(InputHelper.ReadComplateTextFile("input.txt"));
        }
        public string Run(long part = 14, long expected = 0)
        {
            //List<(int, int)> ps = new();
            string result = "";
            if (part == 0) return result;
            for (int i = 9; i > 0; i--)
            {
                for (int z = -9999; z < 9999; z++)
                {
                    if (alu.TestPart(part, i, z, expected))
                    {
                        result = Run(part - 1, z);
                        if(result != "-1")
                        {
                            result = result + i.ToString();
                            return result;
                        }
                    }
                }
            }
            return "-1";
        }

        public string Run2(long part = 1, long z = 0)
        {
            string result = "";
            for (int i = 9; i > 0; i--)
            {
                var r = alu.Part(part, i, z);
                if (part < 14) 
                {
                    result = Run2(part + 1, r);
                    if (result != "-1")
                    {
                        result = result.Insert(0, i.ToString());
                        return result;
                    }
                }
                else
                {
                    if (r == 0) return i.ToString();
                } 
            }
            Console.WriteLine(part);
            return "-1";
        }
    }
}
