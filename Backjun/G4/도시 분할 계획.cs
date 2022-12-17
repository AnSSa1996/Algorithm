using System.Runtime.InteropServices;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var vistied = new bool[N + 1];
var sum = 0;
var parent = Enumerable.Range(0, N + 1).ToArray();

List<(int A, int B, int COST)> roadList = new List<(int A, int B, int COST)>();
for (int i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];

    roadList.Add((a, b, c));
}

roadList.Sort((a, b) => a.COST.CompareTo(b.COST));
List<int> costList = new List<int>();

foreach (var road in roadList)
{
    var a = road.A;
    var b = road.B;
    var cost = road.COST;
    if (find_parent(a) != find_parent(b))
    {
        Union_Parent(a, b);
        costList.Add(cost);
    }
}

costList.RemoveAt(costList.Count - 1);
sw.WriteLine(costList.Sum());

sr.Close();
sw.Close();

int find_parent(int index)
{
    if (parent[index] != index) return find_parent(parent[index]);
    return parent[index];
}

void Union_Parent(int left, int right)
{
    left = find_parent(left);
    right = find_parent(right);
    if (left < right)
    {
        parent[right] = left;
    }
    else
    {
        parent[left] = right;
    }
}