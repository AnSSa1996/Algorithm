StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var order = 0;
var parent = Enumerable.Range(0, N).ToArray();

var result = 0;
for (var m = 0; m < M; m++)
{
    order++;
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var check = Union(left, right);
    if (check)
    {
        result = order;
        break;
    }
}

sw.WriteLine(result);

int FindParent(int x)
{
    return x == parent[x] ? x : FindParent(parent[x]);
}

bool Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);
    if (left == right) return true;

    if (left < right)
    {
        parent[right] = left;
    }
    else
    {
        parent[left] = right;
    }
    return false;
}

sw.Flush();
sw.Close();
sr.Close();