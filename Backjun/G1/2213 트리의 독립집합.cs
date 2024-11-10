var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var tree = new List<long>[N + 1];

for (var i = 1; i <= N; i++)
{
    tree[i] = new List<long>();
}

for (var i = 1; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var left = inputs[0];
    var right = inputs[1];
    tree[left].Add(right);
    tree[right].Add(left);
}


var dp = new long[N + 1, 2];
var visited = new bool[N + 1];
var resultList = new List<long>();

DFS(1);

sw.WriteLine(Math.Max(dp[1, 0], dp[1, 1]));
if (dp[1, 0] < dp[1, 1])
{
    Find(1, 0, 1);
}
else
{
    Find(1, 0, 0);
}

resultList.Sort();
sw.WriteLine(string.Join(" ", resultList));

sr.Close();
sw.Close();


void DFS(long node)
{
    visited[node] = true;
    dp[node, 0] = 0;
    dp[node, 1] = nums[node - 1];
    
    foreach (var child in tree[node])
    {
        if (visited[child])
        {
            continue;
        }

        DFS(child);
        dp[node, 0] += Math.Max(dp[child, 0], dp[child, 1]);
        dp[node, 1] += dp[child, 0];
    }
}

void Find(long node, long parent, long isInclude)
{
    if (isInclude == 1)
    {
        resultList.Add(node);
        foreach (var child in tree[node])
        {
            if (child == parent)
            {
                continue;
            }

            Find(child, node, 0);
        }
    }
    else
    {
        foreach (var child in tree[node])
        {
            if (child == parent)
            {
                continue;
            }

            if (dp[child, 0] < dp[child, 1])
            {
                Find(child, node, 1);
            }
            else
            {
                Find(child, node, 0);
            }
        }
    }
}