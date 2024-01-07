StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0]; // Y
var X = inputs[1]; // X
var K = inputs[2]; // 벽을 부술 수 있는 횟수

var board = new int[Y, X];
for (var y = 0; y < Y; y++)
{
    var line = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = line[x] - '0';
    }
}

var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };

var visited = new bool[Y, X, K + 1];
var queue = new Queue<(int y, int x, int breakCount, int moveCount)>();
queue.Enqueue((0, 0, 0, 0));
visited[0, 0, 0] = true;

var result = -1;

while (queue.Count > 0)
{
    var (y, x, breakCount, moveCount) = queue.Dequeue();

    if (y == Y - 1 && x == X - 1)
    {
        result = moveCount + 1;
        break;
    }

    for (var i = 0; i < 4; i++)
    {
        var nextX = x + dx[i];
        var nextY = y + dy[i];

        if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
        var next = board[nextY, nextX];

        if (next == 0 && visited[nextY, nextX, breakCount] == false)
        {
            visited[nextY, nextX, breakCount] = true;
            queue.Enqueue((nextY, nextX, breakCount, moveCount + 1));
            continue;
        }

        if (next == 1 && breakCount < K && visited[nextY, nextX, breakCount + 1] == false)
        {
            visited[nextY, nextX, breakCount + 1] = true;
            queue.Enqueue((nextY, nextX, breakCount + 1, moveCount + 1));
            continue;
        }
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();