using Day24;
using Library.Helpers;
using System.Diagnostics;

Console.WriteLine("--- Day 24: Arithmetic Logic Unit ---");
Console.WriteLine();
Tester tester = new Tester();
if (tester.TestBinaryProgram())
{
    Console.WriteLine("Binary program is VALID");
}
else
{
    Console.WriteLine("INVALID");
}
tester.Test();
//Stopwatch stopwatch = Stopwatch.StartNew();
//Runner runner = new Runner();
//string result = runner.Run2();
//Console.WriteLine(result);
//Alu alu = new Alu(InputHelper.ReadComplateTextFile("input.txt"));

//long b = 99999999999999;
//long a = 11111111111111;
//int[] nr = new int[14];
//bool valid = alu.TestMonad(11111111111111);

//if(alu.TestPart(14, 9, 20, 0))
//{
//    nr[13] = 9;
//    Console.WriteLine($"VALID");
//}

//for (int i = 9; i > 0; i--)
//{
//    for (int z = -9999; z < 9999; z++)
//    {
//        if(alu.TestPart(14, i, z, 0))
//        {

//        }
//    }
//}


//for (long i = a; i <= b; i++)
//{
//    //bool valid = alu.TestMonad(i);
//    //if (valid)
//    //{
//    //    Console.WriteLine(i);
//    //    break;
//    //}
//    if (i % 100000 == 0)
//    {
//        Console.Write("\r {0} in {1}                         ", i, stopwatch.ElapsedMilliseconds);
//        stopwatch.Restart();
//    }
//}

//long j = 0;
//Parallel.For(a, b, (i) =>
//{
//    j++;
//    //Alu aluCopy = (Alu)alu.Clone();
//    //bool valid = aluCopy.TestMonad(i);
//    //if (valid)
//    //{
//    //    Console.WriteLine("VALID");
//    //    Console.WriteLine(i);
//    //}
//    if (j % 100000 == 0)
//    {
//        Console.Write("\r {0} in {1}                      ", j, stopwatch.ElapsedMilliseconds);
//        stopwatch.Restart();
//    }
//});



//Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
