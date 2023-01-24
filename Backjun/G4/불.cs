using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var X = inputs[0];
    var Y = inputs[1];

    var dx = new int[4] { 1, -1, 0, 0 };
    var dy = new int[4] { 0, 0, 1, -1 };

    var board = new char[Y, X];
    var humanList = new Queue<(int y, int x, int depth)>();
    var fireList = new Queue<(int y, int x)>();

    var check = false;
    var count = 0;

    var visitFire = new bool[Y, X];
    var visitHuman = new bool[Y, X];

    for (var y = 0; y < Y; y++)
    {
        var str = sr.ReadLine();
        for (var x = 0; x < X; x++)
        {
            var currentChar = str[x];
            board[y, x] = currentChar;

            if (currentChar == '@') humanList.Enqueue((y, x, 1));
            if (currentChar == '*') fireList.Enqueue((y, x));
        }
    }

    while (true)
    {
        if (check) break;
        if (humanList.Count == 0) break;
        BFS_Fire();
        BFS_Human();
    }

    if (check) sw.WriteLine(count);
    else sw.WriteLine("IMPOSSIBLE");

    void BFS_Fire()
    {
        var q = new Queue<(int y, int x)>(fireList);
        var nextQ = new Queue<(int y, int x)>();
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var x = current.x;
            var y = current.y;

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dx[d];
                var nextY = y + dy[d];

                if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
                if (visitFire[nextY, nextX]) continue;
                if (board[nextY, nextX] == '*') continue;
                if (board[nextY, nextX] == '#') continue;

                visitFire[nextY, nextX] = true;
                board[nextY, nextX] = '*';
                nextQ.Enqueue((nextY, nextX));
            }
        }

        fireList = nextQ;
    }

    void BFS_Human()
    {
        var q = new Queue<(int y, int x, int depth)>(humanList);
        var nextQ = new Queue<(int y, int x, int depth)>();
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var x = current.x;
            var y = current.y;
            var depth = current.depth;

            if (y == 0 || y == Y - 1 || x == 0 || x == X - 1)
            {
                count = depth;
                check = true;
                break;
            }

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dx[d];
                var nextY = y + dy[d];
                if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
                if (board[nextY, nextX] != '.') continue;
                if (visitHuman[nextY, nextX]) continue;
                
                visitHuman[nextY, nextX] = true;
                nextQ.Enqueue((nextY, nextX, depth + 1));
            }
        }

        humanList = nextQ;
    }
}

sw.Flush();
sw.Close();
sr.Close();