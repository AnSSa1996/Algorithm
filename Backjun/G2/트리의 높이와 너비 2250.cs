var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());


var N = int.Parse(sr.ReadLine());
var trees = new Node[N + 1];

for (var i = 0; i <= N; i++)
{
    trees[i] = new Node();
}

for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var node = inputs[0];
    var left = inputs[1];
    var right = inputs[2];

    if (left != -1)
    {
        trees[node].Left = left;
    }

    if (right != -1)
    {
        trees[node].Right = right;
    }

    if (left != -1)
    {
        trees[left].Parent = node;
    }

    if (right != -1)
    {
        trees[right].Parent = node;
    }
}

var visited = new bool[N + 1];
visited[0] = true;

var root = FindRoot();

var maxDepth = 0;
DFS(root, 1);

var order = 1;
InOrder(root);

var depthList = new List<int>[maxDepth + 1];
for (var i = 1; i <= maxDepth; i++)
{
    depthList[i] = new List<int>();
}

for (var i = 1; i <= N; i++)
{
    depthList[trees[i].Depth].Add(trees[i].Order);
}

var resultList = new List<int>();
foreach (var currentDepthLiST in depthList)
{
    if (currentDepthLiST == null)
    {
        continue;
    }

    if (currentDepthLiST.Count == 0)
    {
        continue;
    }

    if (currentDepthLiST.Count == 1)
    {
        resultList.Add(1);
        continue;
    }

    resultList.Add(currentDepthLiST.Max() - currentDepthLiST.Min() + 1);
}

var result = resultList.Max();
var level = resultList.IndexOf(result) + 1;

sw.WriteLine($"{level} {result}");

int FindRoot()
{
    for (var i = 1; i <= N; i++)
    {
        if (trees[i].Parent == -1)
        {
            return i;
        }
    }

    return -1;
}

void DFS(int node, int depth)
{
    visited[node] = true;
    trees[node].Depth = depth;
    maxDepth = Math.Max(maxDepth, depth);

    if (trees[node].Left != -1 && !visited[trees[node].Left])
    {
        DFS(trees[node].Left, depth + 1);
    }

    if (trees[node].Right != -1 && !visited[trees[node].Right])
    {
        DFS(trees[node].Right, depth + 1);
    }
}

void InOrder(int node)
{
    if (node == -1)
    {
        return;
    }

    InOrder(trees[node].Left);
    trees[node].Order = order++;
    InOrder(trees[node].Right);
}


sw.Close();
sr.Close();


public class Node
{
    public int Left = -1;
    public int Right = -1;
    public int Parent = -1;
    public int Depth = 0;
    public int Order = 0;
}