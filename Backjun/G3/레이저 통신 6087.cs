var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var W = inputs[0];      // 가로
var H = inputs[1];      // 세로
var map = new char[H, W];

var startPoint = (-1, -1);
var endPoint = (-1, -1);
for (var i = 0; i < H; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < W; j++)
    {
        map[i, j] = line[j];
        if (line[j] == 'C')
        {
            if (startPoint.Item1 == -1)
            {
                startPoint = (i, j);
            }
            else
            {
                endPoint = (i, j);
            }
        }
    }
}

var dx = new int[] { 0, 0, -1, 1 };
var dy = new int[] { -1, 1, 0, 0 };

var endY = endPoint.Item1;
var endX = endPoint.Item2;
var visited = new bool[H, W, 4];
var pq = new PriorityQueue<(int y, int x, int dir, int cost), int>();

var startY = startPoint.Item1;
var startX = startPoint.Item2;
for (var d = 0; d < 4; d++)
{
    var nextY = startY + dy[d];
    var nextX = startX + dx[d];
    if (nextY < 0 || nextY >= H || nextX < 0 || nextX >= W || map[nextY, nextX] == '*') continue;
    pq.Enqueue((nextY, nextX, d, 0), 0);
    visited[nextY, nextX, d] = true;
}

var result = 0;

while (pq.Count > 0)
{
    var (y, x, dir, cost) = pq.Dequeue();
    visited[y, x, dir] = true;
    if (y == endY && x == endX)
    {
        result = cost;
        break;
    }

    if (y == 4 && x == 12)
    {
        var a = 1;
    }
    
    for(var d = 0; d < 4; d++)
    {
        var nextY = y + dy[d];
        var nextX = x + dx[d];
        if (nextY < 0 || nextY >= H || nextX < 0 || nextX >= W || map[nextY, nextX] == '*') continue;
        if (visited[nextY, nextX, d]) continue;
        if (dir == d)
        {
            pq.Enqueue((nextY, nextX, d, cost), cost);
        }
        else
        {
            pq.Enqueue((nextY, nextX, d, cost + 1), cost + 1);
        }
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();