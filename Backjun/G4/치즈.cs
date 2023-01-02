var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new int[Y, X];
for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
    }
}


var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

void BFS()
{
    var visited = new bool[Y, X];
    var q = new Queue<(int y, int x)>();
    q.Enqueue((0, 0));

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
            if (visited[nextY, nextX]) continue;
            visited[nextY, nextX] = true;
            if (board[nextY, nextX] == 1)
            {
                board[nextY, nextX] = 0;
                continue;
            }

            q.Enqueue((nextY, nextX));
        }
    }
}

int Check()
{
    var count = 0;
    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            if (board[y, x] == 1) count++;
        }
    }

    return count;
}

var time = 0;
var result = 0;
while (true)
{
    var count = Check();
    if (count == 0) break;
    result = count;
    BFS();
    time++;
}

sw.WriteLine(time);
sw.WriteLine(result);

sw.Close();
sr.Close();