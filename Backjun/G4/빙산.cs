using System.Runtime.InteropServices;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new int[Y, X];

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
    }
}

var result = 0;
while (true)
{
    var count = check();
    if (count >= 2) break;
    if (NextYear() == false)
    {
        result = 0;
        break;
    }

    result++;
}

sw.WriteLine(result);

int check()
{
    var count = 0;
    var visited = new bool[Y, X];
    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            if (board[y, x] == 0) continue;
            if (visited[y, x]) continue;
            count++;
            BFS(y, x, visited);
        }
    }

    return count;
}

bool NextYear()
{
    var changeValueList = new List<(int y, int x, int value)>();
    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            if (board[y, x] != 0)
            {
                var nextValue = MELT(y, x, board[y, x]);
                changeValueList.Add((y, x, nextValue));
            }
        }
    }

    foreach (var changeValue in changeValueList)
    {
        var y = changeValue.y;
        var x = changeValue.x;
        var value = changeValue.value;
        board[y, x] = value;
    }

    return changeValueList.Any();
}

void BFS(int y, int x, bool[,] visited)
{
    var q = new Queue<(int y, int x)>();
    q.Enqueue((y, x));
    visited[y, x] = true;

    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var currentX = current.x;
        var currentY = current.y;
        for (var d = 0; d < 4; d++)
        {
            var nextY = currentY + dy[d];
            var nextX = currentX + dx[d];
            if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
            if (board[nextY, nextX] == 0) continue;
            if (visited[nextY, nextX]) continue;
            q.Enqueue((nextY, nextX));
            visited[nextY, nextX] = true;
        }
    }
}

int MELT(int y, int x, int value)
{
    var count = 0;

    for (var d = 0; d < 4; d++)
    {
        var nextX = x + dx[d];
        var nextY = y + dy[d];
        if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
        if (board[nextY, nextX] != 0) continue;
        count++;
    }

    value -= count;
    if (value < 0) value = 0;
    return value;
}

sw.Flush();
sw.Close();
sr.Close();