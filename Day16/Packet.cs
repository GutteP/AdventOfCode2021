using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class RecursivePacketDecoder
    {
        public RecursivePacketDecoder()
        {

        }

        public void Run()
        {

        }

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
                        packets.AddRange(Create(binary.Substring(0, length)));
                        binary = binary.Remove(0, length);
                    }
                    else
                    {
                        binary = binary.Remove(0, 1);
                        if (binary.Length < 11) break;
                        int numberOfPackets = Convert.ToInt32(binary.Substring(0, 11), 2);
                        binary = binary.Remove(0, 11);
                        packets.AddRange(Create(binary));
                        binary = "";
                    }
                }
                else
                {
                    while (binary.Length != 0 && (binary.Length > 8 || Convert.ToInt32(binary, 2) != 0))
                    {
                        string literal = binary.Substring(0, 5);
                        string binaryValue = string.Empty;
                        if(literal[0] == '1')
                        {
                            binaryValue += literal.Substring(1, 4);
                            binary = binary.Remove(0, 5);
                        }
                        else
                        {
                            binaryValue += literal.Substring(1, 4);
                            binary = binary.Remove(0, 5);
                            p.LiteralValue = Convert.ToInt32(binaryValue, 2);
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
                sum += p.PacketVersion;
            }
            return sum;
        }
    }

    public class RecursivePacket
    {
        public int PacketVersion { get; set; }
        public int LiteralValue { get; set; }
        public int TypeId { get; set; }
        public RecursivePacket()
        {

        }
    }

    public static class RecuersiveHelper
    {
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
    //public class PacketDecoder
    //{
    //    public List<Packet> Packets { get; set; }

    //    public PacketDecoder(string binary)
    //    {
    //        Packets = new();
    //        while (binary.Length > 7)
    //        {
    //            Packet p = new();
    //            p.PacketVersion = Convert.ToInt32(binary.Substring(0, 3), 2);
    //            p.TypeId = Convert.ToInt32(binary.Substring(3, 3), 2);
    //            int currentIndex = 0;
    //            switch (p.PType())
    //            {
    //                case PacketType.Operator:
    //                    currentIndex = p.DecodeOperator(binary);
    //                    break;
    //                case PacketType.Literal:
    //                    currentIndex = p.DecodeLiteral(binary);
    //                    break;
    //                default:
    //                    break;
    //            }
    //            Packets.Add(p);
    //            try
    //            {
    //                binary = binary.Substring(currentIndex);
    //            }
    //            catch (Exception)
    //            {
    //                break;
    //            }
                
    //        }
    //    }

    //    public int VersionNumberSum()
    //    {
    //        int sum = 0;
    //        foreach (var p in Packets)
    //        {
    //            sum += p.PacketVersion;
    //        }
    //        return sum;
    //    }
    //}
    //public class Packet
    //{
    //    public int PacketVersion { get; set; }
    //    public int TypeId { get; set; }

    //    /// <summary>
    //    /// If TypeId == 4
    //    /// </summary>
    //    public int Litteral { get; set; }

    //    /// <summary>
    //    /// If TypeId == 3, 6 ?
    //    /// </summary>
    //    public int LengthTypeId { get; set; }
    //    public int Length { get; set; }
    //    public List<string> Subpackets { get; set; }

    //    public Packet()
    //    {
    //        Subpackets = new List<string>();
    //    }

    //    public (List<Packet>) DecodeOperator(string binary)
    //    {
    //        LengthTypeId = int.Parse(binary[6].ToString());
    //        int currentIndex = 7;
    //        int trailingZeros = 0;
    //        if(LengthTypeId == 0)
    //        {
    //            //trailingZeros = 7;
    //            int packetLength = Convert.ToInt32(binary.Substring(currentIndex, 15), 2);
    //            currentIndex += 15;
    //            string packet = binary.Substring(currentIndex, packetLength);
    //            currentIndex += 15 + packetLength;
    //            trailingZeros = packetLength % 4;
    //        }
    //        else
    //        {
    //            //trailingZeros = 5;
    //            int numberOfPackets = Convert.ToInt32(binary.Substring(currentIndex, 11), 2);
    //            for (int i = 0; i < numberOfPackets; i++)
    //            {
    //                currentIndex += 11;
    //                Subpackets.Add(binary.Substring(currentIndex, 11));
    //            }
    //        }
    //        return currentIndex + trailingZeros;         
    //    }

    //    public List<Packet> BinaryPackets(string substring)
    //    {
    //        List<Packet> packets = new();
    //        while (substring.Length != 0)
    //        {
    //            Packet p = new();
    //            p.PacketVersion = Convert.ToInt32(substring.Substring(0, 3), 2);
    //            p.TypeId = Convert.ToInt32(substring.Substring(3, 3), 2);
    //            int currentIndex = 0;
    //            switch (p.PType())
    //            {
    //                case PacketType.Operator:
    //                    currentIndex = p.DecodeOperator(substring);
    //                    break;
    //                case PacketType.Literal:
    //                    currentIndex = p.DecodeLiteral(substring);
    //                    break;
    //                default:
    //                    break;
    //            }
    //            packets.Add(p);
    //            try
    //            {
    //                substring = substring.Substring(currentIndex);
    //            }
    //            catch (Exception)
    //            {
    //                break;
    //            }
    //        }
    //        return packets;
    //    }

    //    public int DecodeLiteral(string binary)
    //    {
    //        int trailingZeros = -1;
    //        string literalString = binary.Substring(6);
    //        string binaryLiteralValue = String.Empty;
    //        int endIndex = -1;
    //        for (int i = 0; i != -1; i++)
    //        {
    //            if (literalString[5*i] == '1')
    //            {
    //                binaryLiteralValue += literalString.Substring((5 * i) + 1, 4);
    //            }
    //            else
    //            {
    //                binaryLiteralValue += literalString.Substring((5 * i) + 1, 4);
    //                endIndex = (5 * i) + 5 + 6;
    //                int sLength = binary.Length;
    //                trailingZeros = (5 * (i+1)) % 4;
    //                break;
    //            }
    //        }
    //        Litteral = Convert.ToInt32(binaryLiteralValue, 2);
    //        return endIndex +1 + trailingZeros;
    //    }

    //    public PacketType PType()
    //    {
    //        switch (TypeId)
    //        {
    //            case 0:
    //                throw new NotImplementedException();
    //            case 3:
    //            case 6:
    //                return PacketType.Operator;
    //            case 4:
    //                return PacketType.Literal;
    //            default:
    //                return PacketType.Operator;
    //        }
    //    }
    //}

    //public enum PacketType
    //{
    //    Unknown = 0,
    //    Operator = 1,
    //    Literal = 2,
    //}
}

//110100101111111000101000
//VVVTTTAAAAABBBBBCCCCC
//V - Packet Version
//TT - Type Id
//A, B, C - Litteral
//Literal - 011111100101 - 2021

//00111000000000000110111101000101001010010001001000000000
//VVVTTTILLLLLLLLLLLLLLLAAAAAAAAAAABBBBBBBBBBBBBBBB
//V - PackerVersion (1)     The three bits labeled V (001) are the packet version, 1.
//T - TypeId (6)            The three bits labeled T (110) are the packet type ID, 6, which means the packet is an operator.
//I - LengthTypeId (1)      The bit labeled I (0) is the length type ID, which indicates that the length is a 15-bit number representing the number of bits in the sub-packets.
//L - Length (27)           The 15 bits labeled L (000000000011011) contain the length of the sub-packets in bits, 27.
//A - Subpacket (10)        The 11 bits labeled A contain the first sub-packet, a literal value representing the number 10.
//B - Subpacket (20)        The 16 bits labeled B contain the second sub-packet, a literal value representing the number 20.