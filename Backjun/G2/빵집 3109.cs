var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new int[Y, X];

for (var y = 0; y < Y; y++)
{
    var line = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        var current = line[x];
        if (current == 'x')
        {
            // 2는 갈 수 없는 곳(건물)
            board[y, x] = 2;
        }
    }
}

var result = 0;
var dx = new int[] { 1, 1, 1 };
var dy = new int[] { -1, 0, 1 };

bool DFS(int y, int x)
{
    if (x == X - 1)
    {
        result++;
        return true;
    }

    for (var d = 0; d < 3; d++)
    {
        var ny = y + dy[d];
        var nx = x + dx[d];
        if (ny < 0 || ny >= Y || nx < 0 || nx >= X)
        {
            continue;
        }

        if (board[ny, nx] == 2)
        {
            continue;
        }

        if (board[ny, nx] == 0)
        {
            board[ny, nx] = 2;
            if (DFS(ny, nx))
            {
                return true;
            }
        }
    }
    
    return false;
}

for (var y = 0; y < Y; y++)
{
    if (board[y, 0] == 0)
    {
        DFS(y, 0);
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();