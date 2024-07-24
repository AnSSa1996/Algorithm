var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var INF = 10000000;
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var graph = new List<(int end, int weight)>[N + 1];

for (var i = 1; i <= N; i++)
{
    graph[i] = new List<(int end, int weight)>();
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    var weight = inputs[2];

    graph[start].Add((end, weight));
    graph[end].Add((start, weight));
}

var parents = new int[N + 1];
var visited = new bool[N + 1];
var dist = new int[N + 1];
Array.Fill(dist, INF);

var pq = new PriorityQueue<(int node, int dist), int>();
pq.Enqueue((1, 0), 0);
dist[1] = 0;

while (pq.Count > 0)
{
    var (current, currentDist) = pq.Dequeue();

    if (visited[current])
    {
        continue;
    }

    visited[current] = true;

    foreach (var (end, weight) in graph[current])
    {
        if (visited[end])
        {
            continue;
        }

        if (dist[end] > currentDist + weight)
        {
            dist[end] = currentDist + weight;
            parents[end] = current;
            pq.Enqueue((end, dist[end]), dist[end]);
        }
    }
}

sw.WriteLine(N - 1);
for (var Node = 2; Node <= N; Node++)
{
    sw.WriteLine($"{Node} {parents[Node]}");
}


sw.Flush();
sw.Close();
sr.Close();