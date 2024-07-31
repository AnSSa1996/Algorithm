var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var board = new int[N, N];

var startLog = new List<(int y, int x)>();
var endLog = new List<(int y, int x)>();

for (var y = 0; y < N; y++)
{
    var line = sr.ReadLine();
    for (var x = 0; x < N; x++)
    {
        var c = line[x];
        if (c == '1')
        {
            board[y, x] = 1;
            continue;
        }

        if (c == '0') continue;
        if (c == 'B') startLog.Add((y, x));
        if (c == 'E') endLog.Add((y, x));
    }
}

var startLogDirection = startLog[0].y == startLog[1].y ? 0 : 1; // 0: 가로, 1: 세로
var endLogDirection = endLog[0].y == endLog[1].y ? 0 : 1; // 0: 가로, 1: 세로

var visited = new bool[N, N, 2];
var queue = new Queue<(int y, int x, int direction, int count)>();
queue.Enqueue((startLog[1].y, startLog[1].x, startLogDirection, 0));

var result = 0;

var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };

var rotateDx = new int[] { 0, 0, 1, 1, 1, -1, -1, -1 };
var rotateDy = new int[] { 1, -1, 0, 1, -1, 0, 1, -1 };

while (queue.Count > 0)
{
    var (y, x, direction, count) = queue.Dequeue();
    if (y == endLog[1].y && x == endLog[1].x && direction == endLogDirection)
    {
        result = count;
        break;
    }

    for (var d = 0; d < 4; d++)
    {
        var nx = x + dx[d];
        var ny = y + dy[d];
        if (IsIn(ny, nx, direction) == false) continue;
        if (visited[ny, nx, direction]) continue;
        visited[ny, nx, direction] = true;
        queue.Enqueue((ny, nx, direction, count + 1));
    }

    if (direction == 0)
    {
        if (CanRotate(y, x) == false) continue;
        if (visited[y, x, 1]) continue;
        visited[y, x, 1] = true;
        queue.Enqueue((y, x, 1, count + 1));
    }
    else
    {
        if (CanRotate(y, x) == false) continue;
        if (visited[y, x, 0]) continue;
        visited[y, x, 0] = true;
        queue.Enqueue((y, x, 0, count + 1));
    }
}

sw.WriteLine(result);

sw.Flush();
sw.Close();

bool IsIn(int y, int x, int direction)
{
    if (y < 0 || x < 0 || y >= N || x >= N) return false;
    if (direction == 0)
    {
        if (x + 1 >= N) return false;
        if (x - 1 < 0) return false;
        if (board[y, x - 1] == 1 || board[y, x + 1] == 1 || board[y, x] == 1) return false;
    }

    if (direction == 1)
    {
        if (y + 1 >= N) return false;
        if (y - 1 < 0) return false;
        if (board[y - 1, x] == 1 || board[y + 1, x] == 1 || board[y, x] == 1) return false;
    }

    return true;
}

bool CanRotate(int y, int x)
{
    for (var d = 0; d < 8; d++)
    {
        var nx = x + rotateDx[d];
        var ny = y + rotateDy[d];
        if (ny < 0 || nx < 0 || ny >= N || nx >= N) return false;
        if (board[ny, nx] == 1) return false;
    }

    return true;
}