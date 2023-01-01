var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var E = inputs[1];

var lines = new List<List<(int next, int cost)>>();
for (var n = 0; n <= N; n++) lines.Add(new List<(int next, int cost)>());

for (var e = 0; e < E; e++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var cost = inputs[2];

    lines[left].Add((right, cost));
    lines[right].Add((left, cost));
}

inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var start = 1;
var v1 = inputs[0];
var v2 = inputs[1];

var INF = 10000000;
var startDp = Enumerable.Repeat(INF, N + 1).ToArray();
var v1Dp = Enumerable.Repeat(INF, N + 1).ToArray();
var v2Dp = Enumerable.Repeat(INF, N + 1).ToArray();

void Dijkstra(int first, int[] dp)
{
    dp[first] = 0;
    var pq = new PriorityQueue<(int next, int cost), int>();
    pq.Enqueue((first, 0), 0);

    while (pq.Count > 0)
    {
        (var current, var cost) = pq.Dequeue();
        foreach (var nextLine in lines[current])
        {
            var next = nextLine.next;
            var nextCost = nextLine.cost;
            if (dp[next] <= nextCost + cost) continue;

            dp[next] = nextCost + cost;
            pq.Enqueue((next, dp[next]), dp[next]);
        }
    }
}

Dijkstra(start, startDp);
Dijkstra(v1, v1Dp);
Dijkstra(v2, v2Dp);

var a = startDp[v1] + v1Dp[v2] + v2Dp[N];
var b = startDp[v2] + v2Dp[v1] + v1Dp[N];

var result = Math.Min(a, b);
if (result < INF) sw.WriteLine(result);
else sw.WriteLine(-1);

sw.Flush();
sw.Close();
sr.Close();