var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var current = 1;
while (true)
{
    var N = int.Parse(sr.ReadLine());
    if (N == 0) break;

    var board = new int[N, N];
    for (var y = 0; y < N; y++)
    {
        var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (var x = 0; x < N; x++)
        {
            board[y, x] = inputs[x];
        }
    }

    var visited = new bool[N, N];
    var result = 0;
    var dx = new int[4] { 1, -1, 0, 0 };
    var dy = new int[4] { 0, 0, 1, -1 };
    BFS();

    void BFS()
    {
        var queue = new PriorityQueue<(int y, int x, int value), int>();
        queue.Enqueue((0, 0, board[0, 0]), board[0, 0]);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var y = current.y;
            var x = current.x;
            var value = current.value;

            if (y == N - 1 && x == N - 1)
            {
                result = value;
                break;
            }

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dx[d];
                var nextY = y + dy[d];
                if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) continue;
                if (visited[nextY, nextX]) continue;

                visited[nextY, nextX] = true;
                var nextValue = value + board[nextY, nextX];
                queue.Enqueue((nextY, nextX, nextValue), nextValue);
            }
        }
    }

    sw.WriteLine($"Problem {current++}: {result}");
}

sr.Close();
sw.Close();