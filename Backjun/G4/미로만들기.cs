StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var board = new int[N, N];

for (var y = 0; y < N; y++)
{
    var inputs = sr.ReadLine().Select(x => x - '0').ToArray();
    for (var x = 0; x < N; x++)
    {
        board[y, x] = inputs[x];
    }
}

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };
BFS();

void BFS()
{
    var visited = new bool[N, N];
    PriorityQueue<(int y, int x, int count), int> pq = new PriorityQueue<(int y, int x, int count), int>();
    pq.Enqueue((0, 0, 0), 0);

    var result = 0;
    visited[0, 0] = true;
    while (pq.Count > 0)
    {
        var current = pq.Dequeue();
        var y = current.y;
        var x = current.x;
        var count = current.count;

        if (y == N - 1 && x == N - 1)
        {
            result = count;
            break;
        }

        for (var d = 0; d < 4; d++)
        {
            var nextY = y + dy[d];
            var nextX = x + dx[d];

            if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) continue;
            if (visited[nextY, nextX]) continue;
            visited[nextY, nextX] = true;
            if (board[nextY, nextX] == 0)
            {
                pq.Enqueue((nextY, nextX, count + 1), count + 1);
            }
            else
            {
                pq.Enqueue((nextY, nextX, count), count);
            }
        }
    }

    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();