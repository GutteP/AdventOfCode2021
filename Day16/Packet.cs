using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class RecursivePacketDecoder
    {
        public RecursivePacketDecoder() { }

        public List<RecursivePacket> Create(string binary)
        {
            List<RecursivePacket> packets = new();
            while (binary.Length != 0 && (binary.Length > 8 || Convert.ToInt32(binary, 2) != 0))
            {
                RecursivePacket p = new();
                p.PacketVersion = Convert.ToInt32(binary.Substring(0, 3), 2);
                binary = binary.Remove(0, 3);
                p.TypeId = Convert.ToInt32(binary.Substring(0, 3), 2);
                binary = binary.Remove(0, 3);
                if (p.TypeId.IsOperation())
                {
                    if (binary.IsLengthKindZero())
                    {
                        binary = binary.Remove(0, 1);
                        int length = Convert.ToInt32(binary.Substring(0, 15), 2);
                        binary = binary.Remove(0, 15);
                        p.Childs.AddRange(Create(binary.Substring(0, length)));
                        binary = binary.Remove(0, length);
                    }
                    else
                    {
                        binary = binary.Remove(0, 1);
                        if (binary.Length < 11) break;
                        int numberOfPackets = Convert.ToInt32(binary.Substring(0, 11), 2);
                        binary = binary.Remove(0, 11);
                        p.Childs.AddRange(Create(binary));
                        binary = "";
                    }
                }
                else
                {
                    while (binary.Length != 0 /*&& (binary.Length > 8 || Convert.ToInt32(binary, 2) != 0)*/)
                    {
                        string literal = binary.Substring(0, 5);
                        string binaryValue = string.Empty;
                        if (literal[0] == '1')
                        {
                            binaryValue += literal.Substring(1, 4);
                            binary = binary.Remove(0, 5);
                        }
                        else
                        {
                            binaryValue += literal.Substring(1, 4);
                            binary = binary.Remove(0, 5);
                            p.LiteralValue = Convert.ToInt32(binaryValue, 2);
                            if(p.LiteralValue == 0)
                            {

                            }
                            break;
                        }
                    }
                }
                packets.Add(p);
            }
            return packets;
        }
        public int VersionNumberSum(List<RecursivePacket> packets)
        {
            int sum = 0;
            foreach (var p in packets)
            {
                sum += p.RecursiveVersionSum();
            }
            return sum;
        }
        public long Sum(List<RecursivePacket> packets)
        {
            long sum = 0;
            foreach (var p in packets)
            {
                sum += p.Sum();
            }
            return sum;
        }
    }

    public class RecursivePacket
    {
        public int PacketVersion { get; set; }
        public int LiteralValue { get; set; }
        public int TypeId { get; set; }
        public List<RecursivePacket> Childs { get; set; }

        public RecursivePacket()
        {
            Childs = new();
        }

        public int RecursiveVersionSum()
        {
            return PacketVersion + Childs.Select(x => x.RecursiveVersionSum()).Sum();
        }
        public long TotalCount()
        {
            return 1 + Childs.Select(x => x.TotalCount()).Sum();
        }
        public long Sum()
        {
            switch ((PacketType)TypeId)
            {
                case PacketType.Sum:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Sum());
                    return Childs.Select(x => x.Sum()).Sum();
                case PacketType.Product:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Product());
                    return Childs.Select(x => x.Sum()).Product();
                case PacketType.Minimum:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Min());
                    return Childs.Select(x => x.Sum()).Min();
                case PacketType.Maximum:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Max());
                    return Childs.Select(x => x.Sum()).Max();
                case PacketType.Literal:
                    //Console.WriteLine(LiteralValue);
                    return LiteralValue;
                case PacketType.Greater:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Greater());
                    return Childs.Select(x => x.Sum()).Greater();
                case PacketType.Less:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Less());
                    return Childs.Select(x => x.Sum()).Less();
                case PacketType.Equal:
                    //Console.WriteLine(Childs.Select(x => x.Sum()).Equal());
                    return Childs.Select(x => x.Sum()).Equal();
                default:
                    throw new NotImplementedException();
            }

        }
    }

    public enum PacketType
    {
        Sum, //their value is the sum of the values of their sub-packets
        Product, //their value is the result of multiplying together the values of their sub-packets
        Minimum, //their value is the minimum of the values of their sub-packets
        Maximum, //their value is the maximum of the values of their sub-packets
        Literal, //The literal value
        Greater, //their value is 1 if the value of the first sub-packet is greater than the value of the second sub-packet; otherwise, their value is 0
        Less, //their value is 1 if the value of the first sub-packet is less than the value of the second sub-packet; otherwise, their value is 0
        Equal //their value is 1 if the value of the first sub-packet is equal to the value of the second sub-packet; otherwise, their value is 0
    }

    public static class RecuersiveHelper
    {
        public static long Product(this IEnumerable<long> nums)
        {
            long sum = -1;
            foreach (int n in nums)
            {
                if(sum == -1)
                {
                    sum = n;
                    continue;
                }
                sum = sum * n;
            }
            return sum;
        }

        public static long Greater(this IEnumerable<long> nums)
        {
            return nums.First() > nums.Last() ? 1 : 0;
        }
        public static long Equal(this IEnumerable<long> nums)
        {
            return nums.First() == nums.Last() ? 1 : 0;
        }
        public static long Less(this IEnumerable<long> nums)
        {
            return nums.First() < nums.Last() ? 1 : 0;
        }

        public static bool IsLengthKindZero(this string binary)
        {
            return binary[0] == '0';
        }
        public static bool IsOperation(this int num)
        {
            return num != 4;
        }
        public static bool IsLiteral(this string binary)
        {
            return binary.Substring(0, 3) == "100";
        }
    }
}