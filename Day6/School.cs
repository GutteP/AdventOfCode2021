using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class School
    {
        public long a0 { get; set; }
        public long a1 { get; set; }
        public long a2 { get; set; }
        public long a3 { get; set; }
        public long a4 { get; set; }
        public long a5 { get; set; }
        public long a6 { get; set; }
        public long a7 { get; set; }
        public long a8 { get; set; }

        public School(List<int> fishes)
        {
            foreach (var fish in fishes)
            {
                switch (fish)
                {
                    case 0:
                        a0++;
                        break;
                    case 1:
                        a1++;
                        break;
                    case 2:
                        a2++;
                        break;
                    case 3:
                        a3++;
                        break;
                    case 4:
                        a4++;
                        break;
                    case 5:
                        a5++;
                        break;
                    case 6:
                        a6++;
                        break;
                    case 7:
                        a7++;
                        break;
                    case 8:
                        a8++;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Tick()
        {
            long temp = a0;
            a0 = a1;
            a1 = a2;
            a2 = a3;
            a3 = a4;
            a4 = a5;
            a5 = a6;
            a6 = a7;
            a7 = a8;
            a6 += temp;
            a8 = temp;
        }
    }
}
