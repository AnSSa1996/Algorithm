var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

while (true)
{
    var inputs = sr.ReadLine().Split(' ');
    var X = int.Parse(inputs[0]);
    var Y = int.Parse(inputs[1]);

    if (X == 0 && Y == 0)
    {
        break;
    }

    var board = new char[Y, X];
    var dirty = new Dictionary<(int x, int y), int>();
    var count = 0;
    var startX = 0;
    var startY = 0;
    for (var y = 0; y < Y; y++)
    {
        var line = sr.ReadLine();
        for (var x = 0; x < X; x++)
        {
            var c = line[x];
            board[y, x] = c;

            if (c == 'o')
            {
                startX = x;
                startY = y;
            }

            if (c == '*')
            {
                dirty.Add((x, y), count);
                count++;
            }
        }
    }

    var visited = new bool[Y, X, 1 << count];
    var queue = new Queue<(int x, int y, int state, int move)>();
    queue.Enqueue((startX, startY, 0, 0));

    var dx = new int[] { 0, 0, 1, -1 };
    var dy = new int[] { 1, -1, 0, 0 };
    var result = -1;

    while (queue.Count > 0)
    {
        var (x, y, state, move) = queue.Dequeue();

        if (state == (1 << count) - 1)
        {
            result = move;
            break;
        }

        for (var d = 0; d < 4; d++)
        {
            var nx = x + dx[d];
            var ny = y + dy[d];

            if (nx < 0 || nx >= X || ny < 0 || ny >= Y)
            {
                continue;
            }

            if (board[ny, nx] == 'x')
            {
                continue;
            }

            if (visited[ny, nx, state])
            {
                continue;
            }

            visited[ny, nx, state] = true;

            if (board[ny, nx] == '*')
            {
                var newState = state | (1 << dirty[(nx, ny)]);
                queue.Enqueue((nx, ny, newState, move + 1));
            }
            else
            {
                queue.Enqueue((nx, ny, state, move + 1));
            }
        }
    }

    sw.WriteLine(result);
}

sr.Close();
sw.Close();