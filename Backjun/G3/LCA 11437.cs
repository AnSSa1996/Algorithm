var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());    // 노드의 개수
var log = (int)Math.Log(N, 2) + 1;   // 노드의 높이
var parent = new int[N + 1, log];       // 부모 노드를 저장할 배열
var graph = new List<int>[N + 1]; // 그래프를 저장할 배열
var depth = new int[N + 1];       // 노드의 깊이를 저장할 배열
for (var i = 0; i <= N; i++)
{
    graph[i] = new List<int>();
}

for (int i = 0; i < N - 1; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = input[0];
    var b = input[1];
    graph[a].Add(b);
    graph[b].Add(a);
}

var visited = new bool[N + 1];

void DFS(int current, int currentDepth)
{
    visited[current] = true;
    depth[current] = currentDepth;
    foreach (var next in graph[current])
    {
        if (visited[next])
        {
            continue;
        }

        parent[next, 0] = current;             // next의 부모 노드는 current
        DFS(next, currentDepth + 1);
    }
}

void InitParent()
{
    DFS(1, 0);                   // 1번 노드를 루트 노드로 설정한다.
    for (var i = 1; i < log; i++)           // 2^i번째 부모 노드를 찾는다.
    {
        for (var j = 1; j <= N; j++)        // 모든 노드를 순회한다.
        {
            parent[j, i] = parent[parent[j, i - 1], i - 1];
        }
    }
}

InitParent();

var M = int.Parse(sr.ReadLine());    // 공통 조상을 알고 싶은 쌍의 개수
for (var i = 0; i < M; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = input[0];
    var b = input[1];

    if (a == b)
    {
        sw.WriteLine(a);
        continue;
    }
    
    var aDepth = depth[a];
    var bDepth = depth[b];
    
    if(aDepth != bDepth)
    {
        if (aDepth > bDepth)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        for (var j = log - 1; j >= 0; j--)
        {
            var diff = depth[b] - depth[a];
            if (diff < (1 << j)) continue;
            b = parent[b, j];
        }
    }
    
    if (a == b)
    {
        sw.WriteLine(a);
        continue;
    }

    for (var j = log - 1; j >= 0; j--)
    {
        if (parent[a, j] == parent[b, j]) continue;
        a = parent[a, j];
        b = parent[b, j];
    }

    sw.WriteLine(parent[a, 0]);
}

sr.Close();
sw.Close();