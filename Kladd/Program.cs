
//int size = 2130180726;
using System.Numerics;

//int size = 100000000;
int size = 2130180726;
Console.WriteLine($"Trying to create a {size}");

//List<int[]> list = new();
//for (int x = 0; x < size; x++)
//{
//    list.Add(new int[] { x, x, x });
//}
//Console.WriteLine(); //607 mb

//List<float[]> list = new();
//for (int x = 0; x < size; x++)
//{
//    list.Add(new float[] { (float)x, (float)x, (float)x });
//}
//Console.WriteLine(); //607

List<Vector3> list = new();
for (int x = 0; x < size; x++)
{
    list.Add(new Vector3((float)x, (float)x, (float)x));
}
Console.WriteLine(); //2.3 gb