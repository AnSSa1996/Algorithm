using Microsoft.VisualBasic;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

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

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

List<char> charList = new List<char>();
charList.Add(board[0, 0]);
var max = 0;
DFS(0, 0, 1);
sw.WriteLine(max);

void DFS(int y, int x, int distance)
{
    max = Math.Max(max, distance);
    for (var d = 0; d < 4; d++)
    {
        var nextY = y + dy[d];
        var nextX = x + dx[d];
        if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
        if (charList.Contains(board[nextY, nextX])) continue;

        charList.Add(board[nextY, nextX]);
        DFS(nextY, nextX, distance + 1);
        charList.Remove(board[nextY, nextX]);
    }
}

sw.Flush();
sr.Close();
sw.Close();