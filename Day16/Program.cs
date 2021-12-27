using Day16;
using Library.Helpers;
using System.Diagnostics;
using System.Text;

Console.WriteLine("--- Day 16: Packet Decoder ---");
Console.WriteLine("\nPart 1");



string input = "input.txt";
string hexstring = InputHelper.ReadComplateTextFile(input)[0];
string binarystring = String.Join(String.Empty,
  hexstring.Select(
    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
  )
);

//PacketDecoder packetDecoder = new(binarystring);
RecursivePacketDecoder packetDecoder = new RecursivePacketDecoder();
Stopwatch stopwatch = Stopwatch.StartNew();
var result = packetDecoder.Create(binarystring);
stopwatch.Stop();
Console.WriteLine($"Decode the structure of your hexadecimal-encoded BITS transmission; what do you get if you add up the version numbers in all packets? {packetDecoder.VersionNumberSum(result)} in {stopwatch.ElapsedMilliseconds}ms");

Console.WriteLine("\nPart 2");
Console.WriteLine($"Total count: {result[0].TotalCount()}");
Console.WriteLine($"What do you get if you evaluate the expression represented by your hexadecimal-encoded BITS transmission? {packetDecoder.Sum(result)} in {stopwatch.ElapsedMilliseconds}ms");
