var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new int[Y, X];
for (var i = 0; i < Y; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < X; j++)
    {
        board[i, j] = line[j] - '0';
    }
}

var visited = new bool[Y, X, 2];
var queue = new Queue<(int x, int y, int depth, int door)>();
queue.Enqueue((0, 0, 0, 0));
visited[0, 0, 0] = true;

var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };
var result = -1;

while (queue.Count > 0)
{
    var (y, x, depth, door) = queue.Dequeue();
    if (x == X - 1 && y == Y - 1)
    {
        result = depth + 1;
        break;
    }

    for (var i = 0; i < 4; i++)
    {
        var nx = x + dx[i];
        var ny = y + dy[i];
        if (ny < 0 || ny >= Y || nx < 0 || nx >= X) continue;
        if (visited[ny, nx, door]) continue;

        if (board[ny, nx] == 0)
        {
            queue.Enqueue((ny, nx, depth + 1, door));
            visited[ny, nx, door] = true;
        }
        else
        {
            if (door == 0)
            {
                queue.Enqueue((ny, nx, depth + 1, 1));
                visited[ny, nx, door] = true;
            }
        }
    }
}

sw.WriteLine(result);

sr.Close();
sw.Close();