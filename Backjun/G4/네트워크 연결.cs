using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var M = int.Parse(sr.ReadLine());

var lines = new List<(int A, int B, int C)>();
for (var i = 0; i < M; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var A = inputs[0];
    var B = inputs[1];
    var C = inputs[2];

    lines.Add((A, B, C));
}

lines.Sort((a, b) => a.C.CompareTo(b.C));

var parents = Enumerable.Range(0, N + 1).ToArray();
var sum = 0;
for (var index = 0; index < M; index++)
{
    (int A, int B, int C) = lines[index];
    if (FindParent(A) != FindParent(B))
    {
        Union(A, B);
        sum += C;
    }
}

sw.WriteLine(sum);

int FindParent(int x)
{
    if (parents[x] != x) return parents[x] = FindParent(parents[x]);
    else return x;
}

void Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);

    if (left < right)
    {
        parents[right] = left;
    }
    else
    {
        parents[left] = right;
    }
}

sw.Flush();
sw.Close();
sr.Close();