var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var dx = new int[4] { 1, -1, 0, 0 };
var dy = new int[4] { 0, 0, 1, -1 };

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y, X];
for (var y = 0; y < Y; y++)
{
    var str = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = str[x];
    }
}

var check = false;
var visited = new bool[Y, X];
for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        visited = new bool[Y, X];
        visited[y, x] = true;
        DFS(y, x, board[y, x], y, x, 1);
        if (check)
        {
            sw.WriteLine("Yes");
            sw.Close();
            sr.Close();
            Environment.Exit(0);
        }
    }
}

sw.WriteLine("No");

void DFS(int y, int x, char color, int startY, int startX, int count = 0)
{
    for (var d = 0; d < 4; d++)
    {
        var nextY = y + dy[d];
        var nextX = x + dx[d];
        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
        if (board[nextY, nextX] != color) continue;

        if (count >= 4 && nextY == startY && nextX == startX)
        {
            check = true;
            return;
        }

        if (visited[nextY, nextX]) continue;

        visited[y, x] = true;
        DFS(nextY, nextX, color, startY, startX, count + 1);
        visited[y, x] = false;
    }
}

sw.Flush();
sw.Close();
sr.Close();