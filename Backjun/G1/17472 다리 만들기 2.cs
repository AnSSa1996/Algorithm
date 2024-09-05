var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };

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

var iland = 2;
for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        if (board[y, x] == 1)
        {
            CheckIland(y, x);
            iland++;
        }
    }
}

var result = 0;
var edgeList = new PriorityQueue<(int start, int end, int distance), int>();
var visited = new bool[Y, X];

for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        if (board[y, x] == 0) continue;
        if (visited[y, x]) continue;
        visited[y, x] = true;
        PathIland(y, x, 0, board[y, x], 0);
    }
}

var parent = new int[iland];

for (var i = 0; i < iland; i++)
{
    parent[i] = i;
}

while (edgeList.Count > 0)
{
    var (start, end, distance) = edgeList.Dequeue();
    if (FindParent(start) != FindParent(end))
    {
        Union(start, end);
        result += distance - 1;
    }
}

for (var i = 2; i < iland; i++)
{
    if (FindParent(i) != FindParent(2))
    {
        result = 0;
        break;
    }
}

sw.WriteLine(result == 0 ? -1 : result);
sr.Close();
sw.Close();

void CheckIland(int y, int x)
{
    if (y < 0 || y >= Y || x < 0 || x >= X)
    {
        return;
    }

    if (board[y, x] == 1)
    {
        board[y, x] = iland;
        for (var i = 0; i < 4; i++)
        {
            CheckIland(y + dy[i], x + dx[i]);
        }
    }
}

void PathIland(int y, int x, int dir, int start, int count)
{
    if (y < 0 || y >= Y || x < 0 || x >= X)
    {
        return;
    }

    if (count == 0)
    {
        for (var i = 0; i < 4; i++)
        {
            PathIland(y + dy[i], x + dx[i], i, start, count + 1);
        }

        return;
    }


    if (board[y, x] == 0)
    {
        PathIland(y + dy[dir], x + dx[dir], dir, start, count + 1);
        return;
    }

    if (count <= 2) return;

    if (board[y, x] != start)
    {
        edgeList.Enqueue((start, board[y, x], count), count);
    }
}

int FindParent(int x)
{
    if (parent[x] == x) return x;
    return parent[x] = FindParent(parent[x]);
}

void Union(int x, int y)
{
    x = FindParent(x);
    y = FindParent(y);

    if (x < y)
    {
        parent[y] = x;
    }
    else
    {
        parent[x] = y;
    }
}