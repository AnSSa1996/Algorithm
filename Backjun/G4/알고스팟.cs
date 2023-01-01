var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var X = inputs[0];
var Y = inputs[1];

var board = new int[Y, X];
var boardValue = new int[Y, X];
var INF = 100000000;

for (var y = 0; y < Y; y++)
{
    var input = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        var currentNum = input[x] - '0';
        board[y, x] = currentNum;
        boardValue[y, x] = INF;
    }
}

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

var q = new Queue<(int Y, int X, int weight)>();
q.Enqueue((0, 0, 0));
boardValue[0, 0] = 0;
while (q.Count > 0)
{
    var current = q.Dequeue();
    var y = current.Y;
    var x = current.X;
    var weight = current.weight;

    for (var d = 0; d < 4; d++)
    {
        var nextX = x + dx[d];
        var nextY = y + dy[d];

        if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
        var nextWeight = weight;
        if (board[nextY, nextX] == 1) nextWeight += 1;
        if (boardValue[nextY, nextX] <= nextWeight) continue;

        boardValue[nextY, nextX] = nextWeight;
        q.Enqueue((nextY, nextX, nextWeight));
    }
}

sw.WriteLine(boardValue[Y - 1, X - 1]);

sw.Close();
sr.Close();