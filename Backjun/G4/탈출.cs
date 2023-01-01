var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y, X];
var hogQueue = new Queue<(int Y, int X)>();
var waterQueue = new Queue<(int Y, int X)>();


for (var y = 0; y < Y; y++)
{
    var charInputs = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        var current = charInputs[x];
        board[y, x] = current;
        if (current == '*') waterQueue.Enqueue((y, x));
        if (current == 'S') hogQueue.Enqueue((y, x));
    }
}

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

var count = 0;
var check = false;
while (true)
{
    if (check) break;
    if (hogQueue.Count == 0) break;
    var currentWaterCount = waterQueue.Count;
    count += 1;

    for (var i = 0; i < currentWaterCount; i++)
    {
        var currentWater = waterQueue.Dequeue();
        var y = currentWater.Y;
        var x = currentWater.X;
        for (var d = 0; d < 4; d++)
        {
            var nextX = x + dx[d];
            var nextY = y + dy[d];

            if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
            if (board[nextY, nextX] != '.') continue;
            board[nextY, nextX] = '*';
            waterQueue.Enqueue((nextY, nextX));
        }
    }

    var currentHogCount = hogQueue.Count;
    for (var i = 0; i < currentHogCount; i++)
    {
        var currentHog = hogQueue.Dequeue();
        var y = currentHog.Y;
        var x = currentHog.X;

        for (var d = 0; d < 4; d++)
        {
            var nextX = x + dx[d];
            var nextY = y + dy[d];

            if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
            if (board[nextY, nextX] == 'D')
            {
                check = true;
                break;
            }

            if (board[nextY, nextX] != '.') continue;
            board[nextY, nextX] = 'S';
            hogQueue.Enqueue((nextY, nextX));
        }
    }
}

if (check) sw.WriteLine(count);
else sw.WriteLine("KAKTUS");

sw.Close();
sr.Close();