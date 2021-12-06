using Day6;
using Library.Helpers;

Console.WriteLine("Day 6!");
Console.WriteLine("\nPart 1");

List<int> school1 = Helper.Transform(InputHelper.ReadComplateTextFile("input.txt"));

for (int i = 0; i < 80; i++)
{
    int count = school1.Count;
    for (int j = 0; j < count; j++)
    {       
        if (school1[j] == 0)
        {
            school1[j] = 7;
            school1.Add(8);
        }
        school1[j]--;
    }
}

Console.WriteLine($"Find a way to simulate lanternfish. How many lanternfish would there be after 80 days? {school1.Count}");

Console.WriteLine("\nPart 2");
Console.WriteLine();
List<int> school2 = Helper.Transform(InputHelper.ReadComplateTextFile("input.txt"));
School school = new School(school2);
for (int i = 0; i < 256; i++)
{
    school.Tick();
}

Console.WriteLine($"How many lanternfish would there be after 256 days? {school.a0 + school.a1 + school.a2 + school.a3 + school.a4 + school.a5 + school.a6 + school.a7 + school.a8}");
