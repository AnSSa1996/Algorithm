using System.Xml;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
var INF = 100000000;
for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var D = inputs[1];
    var C = inputs[2];

    var board = new List<List<(int next, int distance)>>();
    for (var y = 0; y <= N; y++)
    {
        board.Add(new List<(int next, int distance)>());
    }

    for (var d = 0; d < D; d++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var left = inputs[0];
        var right = inputs[1];
        var value = inputs[2];
        board[right].Add((left, value));
    }

    var result_Count = 0;
    var result_Max = 0;
    Dijkstra();
    sw.WriteLine($"{result_Count} {result_Max}");

    void Dijkstra()
    {
        var dp = Enumerable.Repeat(INF, N + 1).ToArray();
        var pq = new PriorityQueue<(int pos, int distance), int>();
        var visited = new bool[N + 1];
        pq.Enqueue((C, 0), 0);
        dp[C] = 0;
        visited[C] = true;

        while (pq.Count > 0)
        {
            var current = pq.Dequeue();
            var pos = current.pos;
            var distance = current.distance;

            foreach (var nextPair in board[pos])
            {
                var next = nextPair.next;
                var nextWeight = nextPair.distance;
                if (visited[next]) continue;
                var nextDistance = distance + nextWeight;
                if (dp[next] <= nextDistance) continue;
                dp[next] = nextDistance;
                pq.Enqueue((next, nextDistance), nextDistance);
            }
        }

        result_Count = dp.Count(x => x != INF);
        result_Max = dp.Where(x => x != INF).Max();
    }
}

sw.Flush();
sw.Close();
sr.Close();