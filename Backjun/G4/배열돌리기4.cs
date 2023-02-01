using System.Runtime.InteropServices;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var K = inputs[2];
var board = new int[Y, X];

for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
    }
}

var rotationList = new List<(int R, int C, int S)>();
for (var k = 0; k < K; k++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    rotationList.Add((inputs[0] - 1, inputs[1] - 1, inputs[2]));
}

var visited = new bool[K];
var min = int.MaxValue;
DFS(0);
sw.WriteLine(min);

void DFS(int count)
{
    if (count == K)
    {
        CheckMin();
        return;
    }

    for (var i = 0; i < K; i++)
    {
        if (visited[i]) continue;
        visited[i] = true;
        var current = rotationList[i];
        var y = current.R;
        var x = current.C;
        var s = current.S;

        for (var j = 1; j <= s; j++)
        {
            LeftRotation(y, x, j);
        }

        DFS(count + 1);

        for (var j = 1; j <= s; j++)
        {
            RightRotation(y, x, j);
        }

        visited[i] = false;
    }
}


void LeftRotation(int y, int x, int s)
{
    if (s == 0) return;
    var currentY = y - s;
    var currentX = x - s;
    var interval = s * 2;

    var temp = board[currentY, currentX];
    var prev = board[currentY, currentX];
    for (var i = 0; i < interval; i++)
    {
        currentX++;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentY++;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentX--;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentY--;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }
}

void RightRotation(int y, int x, int s)
{
    if (s == 0) return;
    var currentY = y - s;
    var currentX = x - s;
    var interval = s * 2;

    var temp = board[currentY, currentX];
    var prev = board[currentY, currentX];

    for (var i = 0; i < interval; i++)
    {
        currentY++;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentX++;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentY--;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }

    for (var i = 0; i < interval; i++)
    {
        currentX--;
        temp = board[currentY, currentX];
        board[currentY, currentX] = prev;
        prev = temp;
    }
}

void CheckMin()
{
    for (var y = 0; y < Y; y++)
    {
        var total = 0;
        for (var x = 0; x < X; x++)
        {
            total += board[y, x];
        }

        min = Math.Min(min, total);
    }
}

sw.Flush();
sw.Close();
sr.Close();