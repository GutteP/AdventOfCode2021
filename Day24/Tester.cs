﻿using Library.Helpers;
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

    public bool TestBinaryProgram()
    {
        for (int i = 0; i < 10; i++)
        {
            (long w, long x, long y, long z) = alu.ConvertToBinary(i);
            int result = Convert.ToInt32($"{w}{x}{y}{z}", 2);
            if (i != result) return false;
        }
        return true;
        
    }

    public void Test()
    {
        Console.WriteLine("Tester");
        while (true)
        {
            Console.WriteLine("SpecificTester = 1");
            Console.WriteLine("BruteTester = 2");
            Console.WriteLine("FrontBruteTester = 3");
            Console.WriteLine("ReadFrontBruteTestResult = 4"); 
            Console.WriteLine("FindHighestValidModelNumber = 5");
            Console.WriteLine("GetHighestValidModelNumber = 6");
            Console.WriteLine("GetLowestValidModelNumber = 7");

            string c = Console.ReadLine();
            if (c.ToLower() == "x") break;
            else if (c == "1") SpecificTester();
            else if (c == "2") BruteTester();
            else if (c == "3") FrontBruteTester();
            else if (c == "4") ReadFrontBruteTestResult();
            else if (c == "5") FindHighestValidModelNumber();
            else if (c == "6")
            {
                long r = GetHighestValidModelNumber();
                Console.WriteLine(r);
                Console.WriteLine(alu.TestMonad(r));
            }
            else if (c == "7")
            {
                long r = GetHighestValidModelNumber(null, false);
                Console.WriteLine(r);
                Console.WriteLine(alu.TestMonad(r));
            }

        }
    }

    public void SpecificTester()
    {
        Console.WriteLine("SpecificTester");
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

    public void BruteTester()
    {
        Console.WriteLine("Brutetester");
        //List<List<(int,int)>> valids = new List<List<(int, int)>>
        //{
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(),
        //    new(){ (9,-51), (9,-50), (9,-49), (9,-48), (9,-47), (9,-46), (9,-45), (9,-44), (9,-43), (9,-42), (9,-41), (9,-40), (9,-39), (9,-38), (9,-37), (9,-36), (9,-35), (9,-34), (9,-33), (9,-32), (9,-31), (9,-30), (9,-29), (9,-28), (9,-27), (9,-26), (9,-25), (9,-24), (9,-23), (9,-22), (9,-21), (9,-20), (9,-19), (9,-18), (9,-17), (9,-16), (9,-15), (9,-14), (9,-13), (9,-12), (9,-11), (9,-10), (9,-9), (9,-8), (9,-7), (9,-6), (9,-5), (9,-4), (9,-3), (9,-2), (9,-1), (9,0), (9,1), (9,2), (9,3), (9,4), (9,5), (9,6), (9,7), (9,8), (9,9), (9,10), (9,11), (9,12), (9,13), (9,14), (9,15), (9,16), (9,17), (9,18), (9,19), (9,20), (9,21), (9,22), (9,23), (9,24), (9,25), (9,39), (9,65), (9,91), (9,117), (9,143), (9,169), (9,195), (9,221), (9,234), (9,235), (9,236), (9,237), (9,238), (9,239), (9,240), (9,241), (9,242), (9,243), (9,244), (9,245), (9,246), (9,247), (9,248), (9,249), (9,250), (9,251), (9,252), (9,253), (9,254), (9,255), (9,256), (9,257), (9,258), (9,259), (9,260), (9,261), (9,262), (9,263), (9,264), (9,265), (9,266), (9,267), (9,268), (9,269), (9,270), (9,271), (9,272), (9,273), (9,274), (9,275), (9,276), (9,277), (9,278), (9,279), (9,280), (9,281), (9,282), (9,283), (9,284), (9,285), (9,286), (9,287), (9,288), (9,289), (9,290), (9,291), (9,292), (9,293), (9,294), (9,295), (9,296), (9,297), (9,298), (9,299), (9,300), (9,301), (9,302), (9,303), (9,304), (9,305), (9,306), (9,307), (9,308), (9,309), (9,310), (9,311), (9,312), (9,313), (9,314), (9,315), (9,316), (9,317), (9,318), (9,319), (9,320), (9,321), (9,322), (9,323), (9,324), (9,325), (9,326), (9,327), (9,328), (9,329), (9,330), (9,331), (9,332), (9,333), (9,334), (9,335), (9,336), (9,337), (9,338), (9,339), (9,340), (9,341), (9,342), (9,343), (9,344), (9,345), (9,346), (9,347), (9,348), (9,349), (9,350), (9,351), (9,352), (9,353), (9,354), (9,355), (9,356), (9,357), (9,358), (9,359), (9,360), (9,361), (9,362), (9,363), (9,364), (9,365), (9,366), (9,367), (9,368), (9,369), (9,370), (9,371), (9,372), (9,373), (9,374), (9,375), (9,376), (9,377), (9,378), (9,379), (9,380), (9,381), (9,382), (9,383), (9,384), (9,385), (9,386), (9,387), (9,388), (9,389), (9,390), (9,391), (9,392), (9,393), (9,394), (9,395), (9,396), (9,397), (9,398), (9,399), (9,400), (9,401), (9,402), (9,403), (9,404), (9,405), (9,406), (9,407), (9,408), (9,409), (9,410), (9,411), (9,412), (9,413), (9,414), (9,415), (9,416), (9,417), (9,418), (9,419), (9,420), (9,421), (9,422), (9,423), (9,424), (9,425), (9,426), (9,427), (9,428), (9,429), (9,430), (9,431), (9,432), (9,433), (9,434), (9,435), (9,436), (9,437), (9,438), (9,439), (9,440), (9,441), (9,442), (9,443), (9,444), (9,445), (9,446), (9,447), (9,448), (9,449), (9,450), (9,451), (9,452), (9,453), (9,454), (9,455), (9,456), (9,457), (9,458), (9,459), (9,460), (9,461), (9,462), (9,463), (9,464), (9,465), (9,466), (9,467), (9,481), (9,507), (9,533), (9,559), (9,585), (9,611), (9,637), (9,663), (9,6461), (9,6487), (9,6513), (9,6539), (9,6565), (9,6591), (9,6617), (9,6643), (9,6669), (9,7137), (9,7163), (9,7189), (9,7215), (9,7241), (9,7267), (9,7293), (9,7319), (9,7345), (9,7813), (9,7839), (9,7865), (9,7891), (9,7917), (9,7943), (9,7969), (9,7995), (9,8021), (9,8489), (9,8515), (9,8541), (9,8567), (9,8593), (9,8619), (9,8645), (9,8671), (9,8697), (9,9165), (9,9191), (9,9217), (9,9243), (9,9269), (9,9295), (9,9321), (9,9347), (9,9373), (9,9841), (9,9867), (9,9893), (9,9919), (9,9945), (9,9971), (9,9997), (8,-51), (8,-50), (8,-49), (8,-48), (8,-47), (8,-46), (8,-45), (8,-44), (8,-43), (8,-42), (8,-41), (8,-40), (8,-39), (8,-38), (8,-37), (8,-36), (8,-35), (8,-34), (8,-33), (8,-32), (8,-31), (8,-30), (8,-29), (8,-28), (8,-27), (8,-26), (8,-25), (8,-24), (8,-23), (8,-22), (8,-21), (8,-20), (8,-19), (8,-18), (8,-17), (8,-16), (8,-15), (8,-14), (8,-13), (8,-12), (8,-11), (8,-10), (8,-9), (8,-8), (8,-7), (8,-6), (8,-5), (8,-4), (8,-3), (8,-2), (8,-1), (8,0), (8,1), (8,2), (8,3), (8,4), (8,5), (8,6), (8,7), (8,8), (8,9), (8,10), (8,11), (8,12), (8,13), (8,14), (8,15), (8,16), (8,17), (8,18), (8,19), (8,20), (8,21), (8,22), (8,23), (8,24), (8,25), (8,38), (8,64), (8,90), (8,116), (8,142), (8,168), (8,194), (8,220), (8,234), (8,235), (8,236), (8,237), (8,238), (8,239), (8,240), (8,241), (8,242), (8,243), (8,244), (8,245), (8,246), (8,247), (8,248), (8,249), (8,250), (8,251), (8,252), (8,253), (8,254), (8,255), (8,256), (8,257), (8,258), (8,259), (8,260), (8,261), (8,262), (8,263), (8,264), (8,265), (8,266), (8,267), (8,268), (8,269), (8,270), (8,271), (8,272), (8,273), (8,274), (8,275), (8,276), (8,277), (8,278), (8,279), (8,280), (8,281), (8,282), (8,283), (8,284), (8,285), (8,286), (8,287), (8,288), (8,289), (8,290), (8,291), (8,292), (8,293), (8,294), (8,295), (8,296), (8,297), (8,298), (8,299), (8,300), (8,301), (8,302), (8,303), (8,304), (8,305), (8,306), (8,307), (8,308), (8,309), (8,310), (8,311), (8,312), (8,313), (8,314), (8,315), (8,316), (8,317), (8,318), (8,319), (8,320), (8,321), (8,322), (8,323), (8,324), (8,325), (8,326), (8,327), (8,328), (8,329), (8,330), (8,331), (8,332), (8,333), (8,334), (8,335), (8,336), (8,337), (8,338), (8,339), (8,340), (8,341), (8,342), (8,343), (8,344), (8,345), (8,346), (8,347), (8,348), (8,349), (8,350), (8,351), (8,352), (8,353), (8,354), (8,355), (8,356), (8,357), (8,358), (8,359), (8,360), (8,361), (8,362), (8,363), (8,364), (8,365), (8,366), (8,367), (8,368), (8,369), (8,370), (8,371), (8,372), (8,373), (8,374), (8,375), (8,376), (8,377), (8,378), (8,379), (8,380), (8,381), (8,382), (8,383), (8,384), (8,385), (8,386), (8,387), (8,388), (8,389), (8,390), (8,391), (8,392), (8,393), (8,394), (8,395), (8,396), (8,397), (8,398), (8,399), (8,400), (8,401), (8,402), (8,403), (8,404), (8,405), (8,406), (8,407), (8,408), (8,409), (8,410), (8,411), (8,412), (8,413), (8,414), (8,415), (8,416), (8,417), (8,418), (8,419), (8,420), (8,421), (8,422), (8,423), (8,424), (8,425), (8,426), (8,427), (8,428), (8,429), (8,430), (8,431), (8,432), (8,433), (8,434), (8,435), (8,436), (8,437), (8,438), (8,439), (8,440), (8,441), (8,442), (8,443), (8,444), (8,445), (8,446), (8,447), (8,448), (8,449), (8,450), (8,451), (8,452), (8,453), (8,454), (8,455), (8,456), (8,457), (8,458), (8,459), (8,460), (8,461), (8,462), (8,463), (8,464), (8,465), (8,466), (8,467), (8,480), (8,506), (8,532), (8,558), (8,584), (8,610), (8,636), (8,662), (8,6460), (8,6486), (8,6512), (8,6538), (8,6564), (8,6590), (8,6616), (8,6642), (8,6668), (8,7136), (8,7162), (8,7188), (8,7214), (8,7240), (8,7266), (8,7292), (8,7318), (8,7344), (8,7812), (8,7838), (8,7864), (8,7890), (8,7916), (8,7942), (8,7968), (8,7994), (8,8020), (8,8488), (8,8514), (8,8540), (8,8566), (8,8592), (8,8618), (8,8644), (8,8670), (8,8696), (8,9164), (8,9190), (8,9216), (8,9242), (8,9268), (8,9294), (8,9320), (8,9346), (8,9372), (8,9840), (8,9866), (8,9892), (8,9918), (8,9944), (8,9970), (8,9996), (7,-51), (7,-50), (7,-49), (7,-48), (7,-47), (7,-46), (7,-45), (7,-44), (7,-43), (7,-42), (7,-41), (7,-40), (7,-39), (7,-38), (7,-37), (7,-36), (7,-35), (7,-34), (7,-33), (7,-32), (7,-31), (7,-30), (7,-29), (7,-28), (7,-27), (7,-26), (7,-25), (7,-24), (7,-23), (7,-22), (7,-21), (7,-20), (7,-19), (7,-18), (7,-17), (7,-16), (7,-15), (7,-14), (7,-13), (7,-12), (7,-11), (7,-10), (7,-9), (7,-8), (7,-7), (7,-6), (7,-5), (7,-4), (7,-3), (7,-2), (7,-1), (7,0), (7,1), (7,2), (7,3), (7,4), (7,5), (7,6), (7,7), (7,8), (7,9), (7,10), (7,11), (7,12), (7,13), (7,14), (7,15), (7,16), (7,17), (7,18), (7,19), (7,20), (7,21), (7,22), (7,23), (7,24), (7,25), (7,37), (7,63), (7,89), (7,115), (7,141), (7,167), (7,193), (7,219), (7,234), (7,235), (7,236), (7,237), (7,238), (7,239), (7,240), (7,241), (7,242), (7,243), (7,244), (7,245), (7,246), (7,247), (7,248), (7,249), (7,250), (7,251), (7,252), (7,253), (7,254), (7,255), (7,256), (7,257), (7,258), (7,259), (7,260), (7,261), (7,262), (7,263), (7,264), (7,265), (7,266), (7,267), (7,268), (7,269), (7,270), (7,271), (7,272), (7,273), (7,274), (7,275), (7,276), (7,277), (7,278), (7,279), (7,280), (7,281), (7,282), (7,283), (7,284), (7,285), (7,286), (7,287), (7,288), (7,289), (7,290), (7,291), (7,292), (7,293), (7,294), (7,295), (7,296), (7,297), (7,298), (7,299), (7,300), (7,301), (7,302), (7,303), (7,304), (7,305), (7,306), (7,307), (7,308), (7,309), (7,310), (7,311), (7,312), (7,313), (7,314), (7,315), (7,316), (7,317), (7,318), (7,319), (7,320), (7,321), (7,322), (7,323), (7,324), (7,325), (7,326), (7,327), (7,328), (7,329), (7,330), (7,331), (7,332), (7,333), (7,334), (7,335), (7,336), (7,337), (7,338), (7,339), (7,340), (7,341), (7,342), (7,343), (7,344), (7,345), (7,346), (7,347), (7,348), (7,349), (7,350), (7,351), (7,352), (7,353), (7,354), (7,355), (7,356), (7,357), (7,358), (7,359), (7,360), (7,361), (7,362), (7,363), (7,364), (7,365), (7,366), (7,367), (7,368), (7,369), (7,370), (7,371), (7,372), (7,373), (7,374), (7,375), (7,376), (7,377), (7,378), (7,379), (7,380), (7,381), (7,382), (7,383), (7,384), (7,385), (7,386), (7,387), (7,388), (7,389), (7,390), (7,391), (7,392), (7,393), (7,394), (7,395), (7,396), (7,397), (7,398), (7,399), (7,400), (7,401), (7,402), (7,403), (7,404), (7,405), (7,406), (7,407), (7,408), (7,409), (7,410), (7,411), (7,412), (7,413), (7,414), (7,415), (7,416), (7,417), (7,418), (7,419), (7,420), (7,421), (7,422), (7,423), (7,424), (7,425), (7,426), (7,427), (7,428), (7,429), (7,430), (7,431), (7,432), (7,433), (7,434), (7,435), (7,436), (7,437), (7,438), (7,439), (7,440), (7,441), (7,442), (7,443), (7,444), (7,445), (7,446), (7,447), (7,448), (7,449), (7,450), (7,451), (7,452), (7,453), (7,454), (7,455), (7,456), (7,457), (7,458), (7,459), (7,460), (7,461), (7,462), (7,463), (7,464), (7,465), (7,466), (7,467), (7,479), (7,505), (7,531), (7,557), (7,583), (7,609), (7,635), (7,661), (7,6459), (7,6485), (7,6511), (7,6537), (7,6563), (7,6589), (7,6615), (7,6641), (7,6667), (7,7135), (7,7161), (7,7187), (7,7213), (7,7239), (7,7265), (7,7291), (7,7317), (7,7343), (7,7811), (7,7837), (7,7863), (7,7889), (7,7915), (7,7941), (7,7967), (7,7993), (7,8019), (7,8487), (7,8513), (7,8539), (7,8565), (7,8591), (7,8617), (7,8643), (7,8669), (7,8695), (7,9163), (7,9189), (7,9215), (7,9241), (7,9267), (7,9293), (7,9319), (7,9345), (7,9371), (7,9839), (7,9865), (7,9891), (7,9917), (7,9943), (7,9969), (7,9995), (6,-51), (6,-50), (6,-49), (6,-48), (6,-47), (6,-46), (6,-45), (6,-44), (6,-43), (6,-42), (6,-41), (6,-40), (6,-39), (6,-38), (6,-37), (6,-36), (6,-35), (6,-34), (6,-33), (6,-32), (6,-31), (6,-30), (6,-29), (6,-28), (6,-27), (6,-26), (6,-25), (6,-24), (6,-23), (6,-22), (6,-21), (6,-20), (6,-19), (6,-18), (6,-17), (6,-16), (6,-15), (6,-14), (6,-13), (6,-12), (6,-11), (6,-10), (6,-9), (6,-8), (6,-7), (6,-6), (6,-5), (6,-4), (6,-3), (6,-2), (6,-1), (6,0), (6,1), (6,2), (6,3), (6,4), (6,5), (6,6), (6,7), (6,8), (6,9), (6,10), (6,11), (6,12), (6,13), (6,14), (6,15), (6,16), (6,17), (6,18), (6,19), (6,20), (6,21), (6,22), (6,23), (6,24), (6,25), (6,36), (6,62), (6,88), (6,114), (6,140), (6,166), (6,192), (6,218), (6,234), (6,235), (6,236), (6,237), (6,238), (6,239), (6,240), (6,241), (6,242), (6,243), (6,244), (6,245), (6,246), (6,247), (6,248), (6,249), (6,250), (6,251), (6,252), (6,253), (6,254), (6,255), (6,256), (6,257), (6,258), (6,259), (6,260), (6,261), (6,262), (6,263), (6,264), (6,265), (6,266), (6,267), (6,268), (6,269), (6,270), (6,271), (6,272), (6,273), (6,274), (6,275), (6,276), (6,277), (6,278), (6,279), (6,280), (6,281), (6,282), (6,283), (6,284), (6,285), (6,286), (6,287), (6,288), (6,289), (6,290), (6,291), (6,292), (6,293), (6,294), (6,295), (6,296), (6,297), (6,298), (6,299), (6,300), (6,301), (6,302), (6,303), (6,304), (6,305), (6,306), (6,307), (6,308), (6,309), (6,310), (6,311), (6,312), (6,313), (6,314), (6,315), (6,316), (6,317), (6,318), (6,319), (6,320), (6,321), (6,322), (6,323), (6,324), (6,325), (6,326), (6,327), (6,328), (6,329), (6,330), (6,331), (6,332), (6,333), (6,334), (6,335), (6,336), (6,337), (6,338), (6,339), (6,340), (6,341), (6,342), (6,343), (6,344), (6,345), (6,346), (6,347), (6,348), (6,349), (6,350), (6,351), (6,352), (6,353), (6,354), (6,355), (6,356), (6,357), (6,358), (6,359), (6,360), (6,361), (6,362), (6,363), (6,364), (6,365), (6,366), (6,367), (6,368), (6,369), (6,370), (6,371), (6,372), (6,373), (6,374), (6,375), (6,376), (6,377), (6,378), (6,379), (6,380), (6,381), (6,382), (6,383), (6,384), (6,385), (6,386), (6,387), (6,388), (6,389), (6,390), (6,391), (6,392), (6,393), (6,394), (6,395), (6,396), (6,397), (6,398), (6,399), (6,400), (6,401), (6,402), (6,403), (6,404), (6,405), (6,406), (6,407), (6,408), (6,409), (6,410), (6,411), (6,412), (6,413), (6,414), (6,415), (6,416), (6,417), (6,418), (6,419), (6,420), (6,421), (6,422), (6,423), (6,424), (6,425), (6,426), (6,427), (6,428), (6,429), (6,430), (6,431), (6,432), (6,433), (6,434), (6,435), (6,436), (6,437), (6,438), (6,439), (6,440), (6,441), (6,442), (6,443), (6,444), (6,445), (6,446), (6,447), (6,448), (6,449), (6,450), (6,451), (6,452), (6,453), (6,454), (6,455), (6,456), (6,457), (6,458), (6,459), (6,460), (6,461), (6,462), (6,463), (6,464), (6,465), (6,466), (6,467), (6,478), (6,504), (6,530), (6,556), (6,582), (6,608), (6,634), (6,660), (6,6458), (6,6484), (6,6510), (6,6536), (6,6562), (6,6588), (6,6614), (6,6640), (6,6666), (6,7134), (6,7160), (6,7186), (6,7212), (6,7238), (6,7264), (6,7290), (6,7316), (6,7342), (6,7810), (6,7836), (6,7862), (6,7888), (6,7914), (6,7940), (6,7966), (6,7992), (6,8018), (6,8486), (6,8512), (6,8538), (6,8564), (6,8590), (6,8616), (6,8642), (6,8668), (6,8694), (6,9162), (6,9188), (6,9214), (6,9240), (6,9266), (6,9292), (6,9318), (6,9344), (6,9370), (6,9838), (6,9864), (6,9890), (6,9916), (6,9942), (6,9968), (6,9994), (5,-51), (5,-50), (5,-49), (5,-48), (5,-47), (5,-46), (5,-45), (5,-44), (5,-43), (5,-42), (5,-41), (5,-40), (5,-39), (5,-38), (5,-37), (5,-36), (5,-35), (5,-34), (5,-33), (5,-32), (5,-31), (5,-30), (5,-29), (5,-28), (5,-27), (5,-26), (5,-25), (5,-24), (5,-23), (5,-22), (5,-21), (5,-20), (5,-19), (5,-18), (5,-17), (5,-16), (5,-15), (5,-14), (5,-13), (5,-12), (5,-11), (5,-10), (5,-9), (5,-8), (5,-7), (5,-6), (5,-5), (5,-4), (5,-3), (5,-2), (5,-1), (5,0), (5,1), (5,2), (5,3), (5,4), (5,5), (5,6), (5,7), (5,8), (5,9), (5,10), (5,11), (5,12), (5,13), (5,14), (5,15), (5,16), (5,17), (5,18), (5,19), (5,20), (5,21), (5,22), (5,23), (5,24), (5,25), (5,35), (5,61), (5,87), (5,113), (5,139), (5,165), (5,191), (5,217), (5,234), (5,235), (5,236), (5,237), (5,238), (5,239), (5,240), (5,241), (5,242), (5,243), (5,244), (5,245), (5,246), (5,247), (5,248), (5,249), (5,250), (5,251), (5,252), (5,253), (5,254), (5,255), (5,256), (5,257), (5,258), (5,259), (5,260), (5,261), (5,262), (5,263), (5,264), (5,265), (5,266), (5,267), (5,268), (5,269), (5,270), (5,271), (5,272), (5,273), (5,274), (5,275), (5,276), (5,277), (5,278), (5,279), (5,280), (5,281), (5,282), (5,283), (5,284), (5,285), (5,286), (5,287), (5,288), (5,289), (5,290), (5,291), (5,292), (5,293), (5,294), (5,295), (5,296), (5,297), (5,298), (5,299), (5,300), (5,301), (5,302), (5,303), (5,304), (5,305), (5,306), (5,307), (5,308), (5,309), (5,310), (5,311), (5,312), (5,313), (5,314), (5,315), (5,316), (5,317), (5,318), (5,319), (5,320), (5,321), (5,322), (5,323), (5,324), (5,325), (5,326), (5,327), (5,328), (5,329), (5,330), (5,331), (5,332), (5,333), (5,334), (5,335), (5,336), (5,337), (5,338), (5,339), (5,340), (5,341), (5,342), (5,343), (5,344), (5,345), (5,346), (5,347), (5,348), (5,349), (5,350), (5,351), (5,352), (5,353), (5,354), (5,355), (5,356), (5,357), (5,358), (5,359), (5,360), (5,361), (5,362), (5,363), (5,364), (5,365), (5,366), (5,367), (5,368), (5,369), (5,370), (5,371), (5,372), (5,373), (5,374), (5,375), (5,376), (5,377), (5,378), (5,379), (5,380), (5,381), (5,382), (5,383), (5,384), (5,385), (5,386), (5,387), (5,388), (5,389), (5,390), (5,391), (5,392), (5,393), (5,394), (5,395), (5,396), (5,397), (5,398), (5,399), (5,400), (5,401), (5,402), (5,403), (5,404), (5,405), (5,406), (5,407), (5,408), (5,409), (5,410), (5,411), (5,412), (5,413), (5,414), (5,415), (5,416), (5,417), (5,418), (5,419), (5,420), (5,421), (5,422), (5,423), (5,424), (5,425), (5,426), (5,427), (5,428), (5,429), (5,430), (5,431), (5,432), (5,433), (5,434), (5,435), (5,436), (5,437), (5,438), (5,439), (5,440), (5,441), (5,442), (5,443), (5,444), (5,445), (5,446), (5,447), (5,448), (5,449), (5,450), (5,451), (5,452), (5,453), (5,454), (5,455), (5,456), (5,457), (5,458), (5,459), (5,460), (5,461), (5,462), (5,463), (5,464), (5,465), (5,466), (5,467), (5,477), (5,503), (5,529), (5,555), (5,581), (5,607), (5,633), (5,659), (5,6457), (5,6483), (5,6509), (5,6535), (5,6561), (5,6587), (5,6613), (5,6639), (5,6665), (5,7133), (5,7159), (5,7185), (5,7211), (5,7237), (5,7263), (5,7289), (5,7315), (5,7341), (5,7809), (5,7835), (5,7861), (5,7887), (5,7913), (5,7939), (5,7965), (5,7991), (5,8017), (5,8485), (5,8511), (5,8537), (5,8563), (5,8589), (5,8615), (5,8641), (5,8667), (5,8693), (5,9161), (5,9187), (5,9213), (5,9239), (5,9265), (5,9291), (5,9317), (5,9343), (5,9369), (5,9837), (5,9863), (5,9889), (5,9915), (5,9941), (5,9967), (5,9993), (4,-51), (4,-50), (4,-49), (4,-48), (4,-47), (4,-46), (4,-45), (4,-44), (4,-43), (4,-42), (4,-41), (4,-40), (4,-39), (4,-38), (4,-37), (4,-36), (4,-35), (4,-34), (4,-33), (4,-32), (4,-31), (4,-30), (4,-29), (4,-28), (4,-27), (4,-26), (4,-25), (4,-24), (4,-23), (4,-22), (4,-21), (4,-20), (4,-19), (4,-18), (4,-17), (4,-16), (4,-15), (4,-14), (4,-13), (4,-12), (4,-11), (4,-10), (4,-9), (4,-8), (4,-7), (4,-6), (4,-5), (4,-4), (4,-3), (4,-2), (4,-1), (4,0), (4,1), (4,2), (4,3), (4,4), (4,5), (4,6), (4,7), (4,8), (4,9), (4,10), (4,11), (4,12), (4,13), (4,14), (4,15), (4,16), (4,17), (4,18), (4,19), (4,20), (4,21), (4,22), (4,23), (4,24), (4,25), (4,34), (4,60), (4,86), (4,112), (4,138), (4,164), (4,190), (4,216), (4,234), (4,235), (4,236), (4,237), (4,238), (4,239), (4,240), (4,241), (4,242), (4,243), (4,244), (4,245), (4,246), (4,247), (4,248), (4,249), (4,250), (4,251), (4,252), (4,253), (4,254), (4,255), (4,256), (4,257), (4,258), (4,259), (4,260), (4,261), (4,262), (4,263), (4,264), (4,265), (4,266), (4,267), (4,268), (4,269), (4,270), (4,271), (4,272), (4,273), (4,274), (4,275), (4,276), (4,277), (4,278), (4,279), (4,280), (4,281), (4,282), (4,283), (4,284), (4,285), (4,286), (4,287), (4,288), (4,289), (4,290), (4,291), (4,292), (4,293), (4,294), (4,295), (4,296), (4,297), (4,298), (4,299), (4,300), (4,301), (4,302), (4,303), (4,304), (4,305), (4,306), (4,307), (4,308), (4,309), (4,310), (4,311), (4,312), (4,313), (4,314), (4,315), (4,316), (4,317), (4,318), (4,319), (4,320), (4,321), (4,322), (4,323), (4,324), (4,325), (4,326), (4,327), (4,328), (4,329), (4,330), (4,331), (4,332), (4,333), (4,334), (4,335), (4,336), (4,337), (4,338), (4,339), (4,340), (4,341), (4,342), (4,343), (4,344), (4,345), (4,346), (4,347), (4,348), (4,349), (4,350), (4,351), (4,352), (4,353), (4,354), (4,355), (4,356), (4,357), (4,358), (4,359), (4,360), (4,361), (4,362), (4,363), (4,364), (4,365), (4,366), (4,367), (4,368), (4,369), (4,370), (4,371), (4,372), (4,373), (4,374), (4,375), (4,376), (4,377), (4,378), (4,379), (4,380), (4,381), (4,382), (4,383), (4,384), (4,385), (4,386), (4,387), (4,388), (4,389), (4,390), (4,391), (4,392), (4,393), (4,394), (4,395), (4,396), (4,397), (4,398), (4,399), (4,400), (4,401), (4,402), (4,403), (4,404), (4,405), (4,406), (4,407), (4,408), (4,409), (4,410), (4,411), (4,412), (4,413), (4,414), (4,415), (4,416), (4,417), (4,418), (4,419), (4,420), (4,421), (4,422), (4,423), (4,424), (4,425), (4,426), (4,427), (4,428), (4,429), (4,430), (4,431), (4,432), (4,433), (4,434), (4,435), (4,436), (4,437), (4,438), (4,439), (4,440), (4,441), (4,442), (4,443), (4,444), (4,445), (4,446), (4,447), (4,448), (4,449), (4,450), (4,451), (4,452), (4,453), (4,454), (4,455), (4,456), (4,457), (4,458), (4,459), (4,460), (4,461), (4,462), (4,463), (4,464), (4,465), (4,466), (4,467), (4,476), (4,502), (4,528), (4,554), (4,580), (4,606), (4,632), (4,658), (4,6456), (4,6482), (4,6508), (4,6534), (4,6560), (4,6586), (4,6612), (4,6638), (4,6664), (4,7132), (4,7158), (4,7184), (4,7210), (4,7236), (4,7262), (4,7288), (4,7314), (4,7340), (4,7808), (4,7834), (4,7860), (4,7886), (4,7912), (4,7938), (4,7964), (4,7990), (4,8016), (4,8484), (4,8510), (4,8536), (4,8562), (4,8588), (4,8614), (4,8640), (4,8666), (4,8692), (4,9160), (4,9186), (4,9212), (4,9238), (4,9264), (4,9290), (4,9316), (4,9342), (4,9368), (4,9836), (4,9862), (4,9888), (4,9914), (4,9940), (4,9966), (4,9992), (3,-51), (3,-50), (3,-49), (3,-48), (3,-47), (3,-46), (3,-45), (3,-44), (3,-43), (3,-42), (3,-41), (3,-40), (3,-39), (3,-38), (3,-37), (3,-36), (3,-35), (3,-34), (3,-33), (3,-32), (3,-31), (3,-30), (3,-29), (3,-28), (3,-27), (3,-26), (3,-25), (3,-24), (3,-23), (3,-22), (3,-21), (3,-20), (3,-19), (3,-18), (3,-17), (3,-16), (3,-15), (3,-14), (3,-13), (3,-12), (3,-11), (3,-10), (3,-9), (3,-8), (3,-7), (3,-6), (3,-5), (3,-4), (3,-3), (3,-2), (3,-1), (3,0), (3,1), (3,2), (3,3), (3,4), (3,5), (3,6), (3,7), (3,8), (3,9), (3,10), (3,11), (3,12), (3,13), (3,14), (3,15), (3,16), (3,17), (3,18), (3,19), (3,20), (3,21), (3,22), (3,23), (3,24), (3,25), (3,33), (3,59), (3,85), (3,111), (3,137), (3,163), (3,189), (3,215), (3,241), (3,267), (3,293), (3,319), (3,345), (3,371), (3,397), (3,423), (3,449), (3,475), (3,501), (3,527), (3,553), (3,579), (3,605), (3,631), (3,657), (3,6455), (3,6481), (3,6507), (3,6533), (3,6559), (3,6585), (3,6611), (3,6637), (3,6663), (3,7131), (3,7157), (3,7183), (3,7209), (3,7235), (3,7261), (3,7287), (3,7313), (3,7339), (3,7807), (3,7833), (3,7859), (3,7885), (3,7911), (3,7937), (3,7963), (3,7989), (3,8015), (3,8483), (3,8509), (3,8535), (3,8561), (3,8587), (3,8613), (3,8639), (3,8665), (3,8691), (3,9159), (3,9185), (3,9211), (3,9237), (3,9263), (3,9289), (3,9315), (3,9341), (3,9367), (3,9835), (3,9861), (3,9887), (3,9913), (3,9939), (3,9965), (3,9991), (2,-51), (2,-50), (2,-49), (2,-48), (2,-47), (2,-46), (2,-45), (2,-44), (2,-43), (2,-42), (2,-41), (2,-40), (2,-39), (2,-38), (2,-37), (2,-36), (2,-35), (2,-34), (2,-33), (2,-32), (2,-31), (2,-30), (2,-29), (2,-28), (2,-27), (2,-26), (2,-25), (2,-24), (2,-23), (2,-22), (2,-21), (2,-20), (2,-19), (2,-18), (2,-17), (2,-16), (2,-15), (2,-14), (2,-13), (2,-12), (2,-11), (2,-10), (2,-9), (2,-8), (2,-7), (2,-6), (2,-5), (2,-4), (2,-3), (2,-2), (2,-1), (2,0), (2,1), (2,2), (2,3), (2,4), (2,5), (2,6), (2,7), (2,8), (2,9), (2,10), (2,11), (2,12), (2,13), (2,14), (2,15), (2,16), (2,17), (2,18), (2,19), (2,20), (2,21), (2,22), (2,23), (2,24), (2,25), (2,32), (2,58), (2,84), (2,110), (2,136), (2,162), (2,188), (2,214), (2,240), (2,266), (2,292), (2,318), (2,344), (2,370), (2,396), (2,422), (2,448), (2,474), (2,500), (2,526), (2,552), (2,578), (2,604), (2,630), (2,656), (2,6454), (2,6480), (2,6506), (2,6532), (2,6558), (2,6584), (2,6610), (2,6636), (2,6662), (2,7130), (2,7156), (2,7182), (2,7208), (2,7234), (2,7260), (2,7286), (2,7312), (2,7338), (2,7806), (2,7832), (2,7858), (2,7884), (2,7910), (2,7936), (2,7962), (2,7988), (2,8014), (2,8482), (2,8508), (2,8534), (2,8560), (2,8586), (2,8612), (2,8638), (2,8664), (2,8690), (2,9158), (2,9184), (2,9210), (2,9236), (2,9262), (2,9288), (2,9314), (2,9340), (2,9366), (2,9834), (2,9860), (2,9886), (2,9912), (2,9938), (2,9964), (2,9990), (1,-51), (1,-50), (1,-49), (1,-48), (1,-47), (1,-46), (1,-45), (1,-44), (1,-43), (1,-42), (1,-41), (1,-40), (1,-39), (1,-38), (1,-37), (1,-36), (1,-35), (1,-34), (1,-33), (1,-32), (1,-31), (1,-30), (1,-29), (1,-28), (1,-27), (1,-26), (1,-25), (1,-24), (1,-23), (1,-22), (1,-21), (1,-20), (1,-19), (1,-18), (1,-17), (1,-16), (1,-15), (1,-14), (1,-13), (1,-12), (1,-11), (1,-10), (1,-9), (1,-8), (1,-7), (1,-6), (1,-5), (1,-4), (1,-3), (1,-2), (1,-1), (1,0), (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12), (1,13), (1,14), (1,15), (1,16), (1,17), (1,18), (1,19), (1,20), (1,21), (1,22), (1,23), (1,24), (1,25), (1,31), (1,57), (1,83), (1,109), (1,135), (1,161), (1,187), (1,213), (1,239), (1,265), (1,291), (1,317), (1,343), (1,369), (1,395), (1,421), (1,447), (1,473), (1,499), (1,525), (1,551), (1,577), (1,603), (1,629), (1,655), (1,6453), (1,6479), (1,6505), (1,6531), (1,6557), (1,6583), (1,6609), (1,6635), (1,6661), (1,7129), (1,7155), (1,7181), (1,7207), (1,7233), (1,7259), (1,7285), (1,7311), (1,7337), (1,7805), (1,7831), (1,7857), (1,7883), (1,7909), (1,7935), (1,7961), (1,7987), (1,8013), (1,8481), (1,8507), (1,8533), (1,8559), (1,8585), (1,8611), (1,8637), (1,8663), (1,8689), (1,9157), (1,9183), (1,9209), (1,9235), (1,9261), (1,9287), (1,9313), (1,9339), (1,9365), (1,9833), (1,9859), (1,9885), (1,9911), (1,9937), (1,9963), (1,9989) },
        //    new() { (9,256), (9,282), (9,308), (9,334), (9,360), (9,386), (9,412), (9,438), (9,464), (8,255), (8,281), (8,307), (8,333), (8,359), (8,385), (8,411), (8,437), (8,463), (7,254), (7,280), (7,306), (7,332), (7,358), (7,384), (7,410), (7,436), (7,462), (6,253), (6,279), (6,305), (6,331), (6,357), (6,383), (6,409), (6,435), (6,461), (5,252), (5,278), (5,304), (5,330), (5,356), (5,382), (5,408), (5,434), (5,460), (4,251), (4,277), (4,303), (4,329), (4,355), (4,381), (4,407), (4,433), (4,459), (3,250), (3,276), (3,302), (3,328), (3,354), (3,380), (3,406), (3,432), (3,458), (2,-25), (2,-24), (2,-23), (2,-22), (2,-21), (2,-20), (2,-19), (2,-18), (2,-17), (2,-16), (2,-15), (2,-14), (2,-13), (2,-12), (2,-11), (2,-10), (2,-9), (2,-8), (2,-7), (2,-6), (2,-5), (2,-4), (2,-3), (2,-2), (2,-1), (2,0), (2,1), (2,2), (2,3), (2,4), (2,5), (2,6), (2,7), (2,8), (2,9), (2,10), (2,11), (2,12), (2,13), (2,14), (2,16), (2,17), (2,18), (2,19), (2,20), (2,21), (2,22), (2,23), (2,24), (2,25), (2,249), (2,275), (2,301), (2,327), (2,353), (2,379), (2,405), (2,431), (2,457), (1,-25), (1,-24), (1,-23), (1,-22), (1,-21), (1,-20), (1,-19), (1,-18), (1,-17), (1,-16), (1,-15), (1,-14), (1,-13), (1,-12), (1,-11), (1,-10), (1,-9), (1,-8), (1,-7), (1,-6), (1,-5), (1,-4), (1,-3), (1,-2), (1,-1), (1,0), (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12), (1,13), (1,15), (1,16), (1,17), (1,18), (1,19), (1,20), (1,21), (1,22), (1,23), (1,24), (1,25), (1,248), (1,274), (1,300), (1,326), (1,352), (1,378), (1,404), (1,430), (1,456) },
        //    new() { (9,17), (8,16), (7,15), (6,14), (5,13), (4,12), (3,11), (2,10), (1,9) },
        //    new() { (9,0), (8,0), (7,0), (6,0), (5,0), (4,0), (3,0), (2,0) },
        //    new() { (9,20), (8,19), (7,18), (6,17), (5,16), (4,15), (3,14), (2,13), (1,12) },
        //    new() { (0,0) }
        //};

        List<List<(int, int)>> valids = Valids.valids;

        for (int part = 14; part > 0; part--)
        {
            if (valids[part - 1].Any()) continue;
            for (int i = 9; i > 0; i--)
            {
                for (int j = -9999; j <= 9999; j++)
                {
                    if (valids[part].Where(x => x.Item2 == alu.Part(part, i, j)).Any())
                    {
                        valids[part - 1].Add((i, j));
                    }
                }
            }
            PrintValid(part, valids[part - 1]);
        }
        PrintValids(valids);
    }

    public void FrontBruteTester()
    {
        List<HashSet<(int, long)>> frontValids = Valids.frontValids;
        for (int part = 1; part <= 14; part++)
        {
            if (frontValids[part].Any()) continue;
            for (int i = 9; i > 0; i--)
            {
                foreach (var val in frontValids[part - 1])
                {
                    frontValids[part].Add((i, alu.Part(part, i, val.Item2)));
                }
            }   
        }
        BinaryFileHelper.WriteToBinaryFile("FrontBruteTester", frontValids);
    }

    public void ReadFrontBruteTestResult()
    {
        List<HashSet<(int, long)>> frontValids = BinaryFileHelper.ReadFromBinaryFile<List<HashSet<(int, long)>>>("FrontBruteTester");
        var valid = frontValids[14].Where(x => x.Item2 == 0).ToList();
        Console.WriteLine();
    }

    public void FindHighestValidModelNumber()
    {
        List<HashSet<(int, long)>> frontValids = BinaryFileHelper.ReadFromBinaryFile<List<HashSet<(int, long)>>>("FrontBruteTester");
        List<HashSet<(int, long)>> producingValidEndResult = new();
        producingValidEndResult.Insert(0, frontValids[14].Where(x => x.Item2 == 0).ToHashSet());
        for (int i = 13; i >= 0; i--)
        {
            producingValidEndResult.Insert(0, new HashSet<(int, long)>());
            foreach (var res in frontValids[i])
            {
                for (int j = 1; j < 10; j++)
                {
                    if (producingValidEndResult[1].Where(x => x.Item2 == alu.Part(i + 1, j, res.Item2)).Any())
                    {
                        producingValidEndResult[0].Add((j,res.Item2));
                    }
                }
            }
        }
        BinaryFileHelper.WriteToBinaryFile("producingValidEndResult", producingValidEndResult);
    }

    public long GetHighestValidModelNumber(List<HashSet<(int, long)>> valids = null, bool biggest = true)
    {
        if(valids == null) valids = BinaryFileHelper.ReadFromBinaryFile<List<HashSet<(int, long)>>>("producingValidEndResult");
        if (biggest)
        {
            foreach (var val in valids[0].OrderByDescending(x => x.Item1))
            {
                long r = TestPath(val, valids, biggest);
                if (r != 0) return r;
            }
        }
        else
        {
            foreach (var val in valids[0].OrderBy(x => x.Item1))
            {
                long r = TestPath(val, valids, biggest);
                if (r != 0) return r;
            }
        }
        
        return 0;
    }

    private long TestPath((int, long) current, List<HashSet<(int, long)>> valids, bool biggest = true)
    {
        long next = 0;
        string result = "";
    
    for (int w = 1; w < 15; w++)
        {
            result += current.Item1;
            next = alu.Part(w, current.Item1, next);
            var matching = valids[w].Where(x => x.Item2 == next);
            current = matching.OrderByDescending(x => x.Item1).FirstOrDefault();
            if(!biggest) current = matching.OrderBy(x => x.Item1).FirstOrDefault();
            if (current == (0, 0)) return 0;
        }
        return long.Parse(result);
    }

    private void PrintValids(List<List<(int, int)>> valids)
    {
        for (int i = 14; i >= 0; i--)
        {
            string toPrint = $"{i} has valids: ";
            foreach (var item in valids[i])
            {
                toPrint += $"(w {item.Item1}, z {item.Item2})";
            }
            Console.WriteLine(toPrint);
        }
        Console.WriteLine();
    }
    
    private void PrintValid(int part, List<(int, int)> valid)
    {
        string toPrint = $"{part} has valids: ";
        foreach (var item in valid)
        {
            toPrint += $"({item.Item1},{item.Item2}), ";
        }
        Console.WriteLine(toPrint);
    }

}

