var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var G = int.Parse(sr.ReadLine());
var P = int.Parse(sr.ReadLine());

var parent = new int[G + 1];
for (var i = 1; i <= G; i++)
{
    parent[i] = i;
}

int Find(int x)
{
    if (x == parent[x])
    {
        return x;
    }
    return parent[x] = Find(parent[x]);
}

void Union(int plane)
{
    var root = Find(plane);
    parent[root] = root - 1;
}

var answer = 0;

for (var i = 0; i < P; i++)
{
    var plane = int.Parse(sr.ReadLine());
    var root = Find(plane);
    if (root == 0)
    {
        break;
    }
    answer++;
    Union(root);
}

sw.WriteLine(answer);
sw.Close();
sr.Close();