var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var M = int.Parse(sr.ReadLine());
var parent = Enumerable.Range(0, N + 1).ToArray();
for (var i = 1; i <= N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 1; j <= N; j++)
    {
        if (i == j) continue;
        if (inputs[j - 1] == 0) continue;
        Union(i, j);
    }
}

void Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);
    if (left == right) return;
    if (left < right) parent[right] = left;
    else parent[left] = right;
}

int FindParent(int x)
{
    return x != parent[x] ? FindParent(parent[x]) : x;
}

bool Check(int left, int right)
{
    return parent[left] == parent[right];
}

var map = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var hash = new HashSet<int>();
foreach (var pos in map)
{
    var par = FindParent(pos);
    if (hash.Contains(par)) continue;
    hash.Add(par);
}

sw.WriteLine(hash.Count == 1 ? "YES" : "NO");

sw.Close();
sr.Close();