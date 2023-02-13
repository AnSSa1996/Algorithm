var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y, X];
var coin = new List<(int y, int x)>();
for (var y = 0; y < Y; y++)
{
    var str = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        var c = str[x];
        if (c == 'o')
        {
            coin.Add((y, x));
            continue;
        }

        board[y, x] = c;
    }
}

var visited = new bool[Y, X, Y, X];

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

BFS();

void BFS()
{
    var q = new Queue<(Coin first, Coin second, int depth)>();
    var firstCoin = new Coin(coin[0].y, coin[0].x);
    var secondCoin = new Coin(coin[1].y, coin[1].x);
    q.Enqueue((firstCoin, secondCoin, 1));
    visited[firstCoin.Y, firstCoin.X, secondCoin.Y, secondCoin.X] = true;
    var result = -1;
    var check = false;

    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var first = current.first;
        var second = current.second;
        var depth = current.depth;
        if (depth > 10) continue;

        for (var d = 0; d < 4; d++)
        {
            var count = 0;

            var firstX = first.X + dx[d];
            var firstY = first.Y + dy[d];

            var secondX = second.X + dx[d];
            var secondY = second.Y + dy[d];

            if (firstX < 0 || firstX >= X || firstY < 0 || firstY >= Y) count++;
            if (secondX < 0 || secondX >= X || secondY < 0 || secondY >= Y) count++;
            if (count == 2) continue;
            if (count == 1)
            {
                result = depth;
                check = true;
                break;
            }

            if (board[firstY, firstX] == '#')
            {
                firstX -= dx[d];
                firstY -= dy[d];
            }

            if (board[secondY, secondX] == '#')
            {
                secondX -= dx[d];
                secondY -= dy[d];
            }

            if (visited[firstY, firstX, secondY, secondX]) continue;
            visited[firstY, firstX, secondY, secondX] = true;
            var firstCo = new Coin(firstY, firstX);
            var secondCo = new Coin(secondY, secondX);
            q.Enqueue((firstCo, secondCo, depth + 1));
        }

        if (check) break;
    }

    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();


public class Coin
{
    public int Y = 0;
    public int X = 0;

    public Coin(int y, int x)
    {
        Y = y;
        X = x;
    }
}