using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24;

public class Tester
{
    private readonly Alu alu;
    public Tester()
    {
        alu = new Alu(InputHelper.ReadComplateTextFile("input.txt"));
    }
    public void Test()
    {
        Console.WriteLine("Parttester");
        while (true)
        {
            Console.WriteLine("Part:");
            int part = int.Parse(Console.ReadLine());
            Console.WriteLine("w:");
            int w = int.Parse(Console.ReadLine());
            Console.WriteLine("z:");
            int z = int.Parse(Console.ReadLine());

            Console.WriteLine($"Part {part}, w {w}, z {z} returns {alu.Part(part, w, z)}");

            if (Console.ReadLine().ToLower() == "x") break;
        }
    }

}

