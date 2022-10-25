using System.Runtime.InteropServices;
using System.Xml.XPath;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var H = inputs[0];
var W = inputs[1];
var T = inputs[2];

var board = new int[H, W];
(int X, int Y) swordPos = new();
for (var h = 0; h < H; h++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var w = 0; w < W; w++)
    {
        board[h, w] = inputs[w];
        if (inputs[w] == 2)
        {
            swordPos.X = w;
            swordPos.Y = h;
        }
    }
}

var dx = new int[4] { 1, -1, 0, 0 };
var dy = new int[4] { 0, 0, 1, -1 };

int resultCount = int.MaxValue;

JustGo();
PassThroughSword();

void JustGo()
{
    var q = new Queue<(int Y, int X, int Depth)>();
    q.Enqueue((0, 0, 0));
    var visited = new bool[H, W];
    visited[0, 0] = true;
    var count = -1;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var x = current.X;
        var y = current.Y;
        var depth = current.Depth;
        if (x == W - 1 && y == H - 1)
        {
            resultCount = depth;
            break;
        }

        for (int d = 0; d < 4; d++)
        {
            var nextX = x + dx[d];
            var nextY = y + dy[d];
            if (nextX < 0 || nextX >= W || nextY < 0 || nextY >= H) continue;
            if (board[nextY, nextX] == 1) continue;
            if (visited[nextY, nextX]) continue;
            visited[nextY, nextX] = true;
            q.Enqueue((nextY, nextX, depth + 1));
        }
    }
}

void PassThroughSword()
{
    var q = new Queue<(int Y, int X, int Depth)>();
    q.Enqueue((0, 0, 0));
    var visited = new bool[H, W];
    visited[0, 0] = true;
    var count = -1;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var x = current.X;
        var y = current.Y;
        var depth = current.Depth;
        if (x == swordPos.X && y == swordPos.Y)
        {
            count = depth;
            break;
        }

        for (int d = 0; d < 4; d++)
        {
            var nextX = x + dx[d];
            var nextY = y + dy[d];
            if (nextX < 0 || nextX >= W || nextY < 0 || nextY >= H) continue;
            if (board[nextY, nextX] == 1) continue;
            if (visited[nextY, nextX]) continue;
            visited[nextY, nextX] = true;
            q.Enqueue((nextY, nextX, depth + 1));
        }
    }

    if (count != -1)
    {
        count += (W - swordPos.X - 1) + (H - swordPos.Y - 1);
        resultCount = Math.Min(resultCount, count);
    }
}

if (resultCount > T) sw.WriteLine("Fail");
else sw.WriteLine(resultCount);

sw.Flush();
sw.Close();
sr.Close();