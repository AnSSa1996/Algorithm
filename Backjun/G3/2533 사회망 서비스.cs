var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());       // 정점의 개수
var edges = new List<List<int>>();         // 간선 정보

for (var i = 0; i <= N; i++)
{
    edges.Add(new List<int>());
}

for (var i = 0; i < N - 1; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = input[0];
    var b = input[1];

    edges[a].Add(b);
    edges[b].Add(a);
}

var dp = new int[N + 1, 2];

void DFS(int node, int parent)
{
    dp[node, 0] = 0;   // 현재 노드가 얼리어답터가 아닐 때
    dp[node, 1] = 1;   // 현재 노드가 얼리어답터일 때

    foreach (var child in edges[node])
    {
        if (child == parent)
        {
            continue;
        }
        
        DFS(child, node);
        dp[node, 0] += dp[child, 1]; // 현재 노드가 얼리어답터가 아니면 자식은 얼리어답터여야 한다.
        dp[node, 1] += Math.Min(dp[child, 0], dp[child, 1]); // 현재 노드가 얼리어답터이면 자식은 얼리어답터여도 되고 아니어도 된다.
    }
}

DFS(1, 0);
sw.WriteLine(Math.Min(dp[1, 0], dp[1, 1]));
sr.Close();
sw.Close();