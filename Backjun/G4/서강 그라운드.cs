StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var R = inputs[2];

var INF = 10000000;
var items = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var board = new int[N + 1, N + 1];
for (var y = 0; y <= N; y++)
{
    for (var x = 0; x <= N; x++)
    {
        board[y, x] = INF;
    }
}

for (var r = 0; r < R; r++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var value = inputs[2];

    board[left, right] = value;
    board[right, left] = value;
}

var result = -100000000;
for (var start = 1; start <= N; start++)
{
    Dijkstra(start);
}

sw.WriteLine(result);

void Dijkstra(int start)
{
    var visited = new bool[N + 1];
    var dp = Enumerable.Repeat(INF, N + 1).ToArray();
    dp[start] = 0;
    visited[start] = true;

    var pq = new PriorityQueue<(int pos, int distance), int>();
    pq.Enqueue((start, 0), 0);
    while(pq.Count > 0)
    {
        var current = pq.Dequeue();
        var pos = current.pos;
        var distance = current.distance;

        for (var next = 1; next <= N; next++)
        {
            if (board[pos, next] == INF) continue;
            if (visited[next]) continue;
            var nextDistance = distance + board[pos, next];
            if (dp[next] <= nextDistance) continue;
            dp[next] = nextDistance;
            pq.Enqueue((next, nextDistance), nextDistance);
        }
    }

    var total = 0;
    for (var i = 1; i <= N; i++)
    {
        if (dp[i] > M) continue;
        total += items[i - 1];
    }

    result = Math.Max(result, total);
}

sw.Flush();
sw.Close();
sr.Close();