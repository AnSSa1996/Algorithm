using System.Xml.XPath;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var birus = new List<(int Y, int X)>();
var board = new int[Y, X];
for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int x = 0; x < X; x++)
    {
        var current = inputs[x];
        if (current == 2) birus.Add((y, x));
        board[y, x] = current;
    }
}

var max = 0;
DFS(0);

sw.WriteLine(max);

void DFS(int wallCount)
{
    if (wallCount == 3)
    {
        var count = BFS(board.Clone() as int[,]);
        max = Math.Max(max, count);
        return;
    }

    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            if (board[y, x] != 0) continue;

            board[y, x] = 1;
            DFS(wallCount + 1);
            board[y, x] = 0;
        }
    }
}


int BFS(int[,]? newBoard)
{
    Queue<(int Y, int X)> q = new Queue<(int Y, int X)>(birus);

    var dx = new int[4] { 1, 0, -1, 0 };
    var dy = new int[4] { 0, 1, 0, -1 };
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var x = current.X;
        var y = current.Y;

        for (var d = 0; d < 4; d++)
        {
            var nextX = x + dx[d];
            var nextY = y + dy[d];

            if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
            if (newBoard[nextY, nextX] != 0) continue;
            newBoard[nextY, nextX] = 2;
            q.Enqueue((nextY, nextX));
        }
    }

    var count = 0;
    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            if (newBoard[y, x] == 0) count++;
        }
    }

    return count;
}

sw.Close();
sr.Close();