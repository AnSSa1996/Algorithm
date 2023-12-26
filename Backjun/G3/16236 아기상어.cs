var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var board = new int[N, N];
var startY = 0;
var startX = 0;
for (var y = 0; y < N; y++)
{
    var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        if (line[x] == 9)
        {
            startY = y;
            startX = x;
            continue;
        }

        board[y, x] = line[x];
    }
}

var currentSize = 2;
var currentEat = 0; // 먹은 물고기 수

var dx = new int[4] { -1, 0, 1, 0 };
var dy = new int[4] { 0, -1, 0, 1 };

var distance = 0;

var nextQueue = new Queue<(int y, int x, int depth)>();
nextQueue.Enqueue((startY, startX, 0));
board[startY, startX] = 0;

while (nextQueue.Count > 0)
{
    var queue = new Queue<(int y, int x, int depth)>();
    var startQueue = nextQueue.Dequeue();
    var sY = startQueue.y;
    var sX = startQueue.x;
    queue.Enqueue((sY, sX, 0));

    var visited = new bool[N, N];
    var result = new List<(int y, int x, int depth)>();
    var minDepth = int.MaxValue;
    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        var y = current.y;
        var x = current.x;
        var depth = current.depth;

        visited[y, x] = true;

        if (board[y, x] < currentSize && board[y, x] != 0)
        {
            result.Add((y, x, depth));
            minDepth = Math.Min(minDepth, depth);
        }

        for (var i = 0; i < 4; i++)
        {
            var nextY = y + dy[i];
            var nextX = x + dx[i];
            if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N)
                continue;

            if (visited[nextY, nextX])
                continue;

            if (board[nextY, nextX] > currentSize)
                continue;

            visited[nextY, nextX] = true;
            queue.Enqueue((nextY, nextX, depth + 1));
        }
    }

    if (result.Count == 0) break;
    var next = result.Where(x => x.depth == minDepth).OrderBy(x => x.y).ThenBy(x => x.x).First();
    nextQueue.Enqueue((next.y, next.x, 0));
    currentEat++;
    if (currentSize == currentEat)
    {
        currentSize++;
        currentEat = 0;
    }

    board[next.y, next.x] = 0;
    distance += minDepth;
}

sw.WriteLine(distance);

sr.Close();
sw.Close();