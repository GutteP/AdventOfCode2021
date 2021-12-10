using Day10;
using Library.Helpers;

Console.WriteLine("--- Day 10: Syntax Scoring ---");
Console.WriteLine("\nPart 1");

string o1 = "(";
string o2 = "[";
string o3 = "{";
string o4 = "<";
string c1 = ")";
string c2 = "]";
string c3 = "}";
string c4 = ">";

List<string> incomplete = new();
Dictionary<char, int> illegalCharacters = new();
foreach (var row in InputHelper.ReadTextFile("input.txt"))
{
    bool illegal = false;
    string chunk = String.Empty;
    foreach (char c in row)
    {
        if (c.IsOpen()) chunk += c;
        else
        {
            if (chunk.Last().IsClosedBy(c)) chunk = chunk.Remove(chunk.Length - 1);
            else
            {
                if (illegalCharacters.ContainsKey(c)) illegalCharacters[c]++;
                else illegalCharacters.Add(c, 1);
                illegal = true;
                break;
            }
        }
    }
    if(!illegal) incomplete.Add(row);
}

Console.WriteLine($"Find the first illegal character in each corrupted line of the navigation subsystem. What is the total syntax error score for those errors? {illegalCharacters.ClaculateSyntaxErrorScore()}");


Console.WriteLine("\nPart 2");
List<string> complements = new();
for (int i = 0; i < incomplete.Count; i++)
{
    string complement = String.Empty;
    bool complete = false;
    while (!complete)
    {
        if (incomplete[i].Last().IsOpen())
        {
            complement += incomplete[i].Last().ComplementedBy();
            incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
        }
        else
        {
            bool found = false;
            int countToFind = 1;
            char c = incomplete[i].Last();
            incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
            while (incomplete[i].Length != 0)
            {
                
                if(incomplete[i].Last() == c.ComplementedBy() && countToFind == 1)
                {
                    incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
                    break;
                }
                else if (incomplete[i].Last() == c.ComplementedBy() && countToFind != 1)
                {
                    countToFind--;
                    incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
                }
                else if(incomplete[i].Last() == c)
                {
                    countToFind++;
                    incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
                }
                else incomplete[i] = incomplete[i].Remove(incomplete[i].Length - 1);
            }
        }

        if (incomplete[i].Length == 0) break;            
    }
    complements.Add(complement);
}

Console.WriteLine($"Find the completion string for each incomplete line, score the completion strings, and sort the scores. What is the middle score? {Helper.ClaculateCompletionScore(complements)}");