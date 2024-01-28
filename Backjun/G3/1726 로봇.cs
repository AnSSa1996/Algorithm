var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var M = inputs[0]; // 세로
var N = inputs[1]; // 가로

var map = new int[M + 1, N + 1]; // 맵
var dp = new int[M + 1, N + 1, 5]; // dp

for (var i = 1; i <= M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 1; j <= N; j++)
    {
        map[i, j] = inputs[j - 1];
    }
}

for (var i = 1; i <= M; i++)
{
    for (var j = 1; j <= N; j++)
    {
        for (var k = 1; k <= 4; k++)
        {
            dp[i, j, k] = 100000000;
        }
    }
}

inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var startPoint = new Point(inputs[1], inputs[0], inputs[2]);
inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var endPoint = new Point(inputs[1], inputs[0], inputs[2]);

var queue = new Queue<(Point, int count)>();
queue.Enqueue((startPoint, 0));
dp[startPoint.Y, startPoint.X, startPoint.Dir] = 0;

while (queue.Count > 0)
{
    var (currentPoint, count) = queue.Dequeue();
    
    // Go
    for (var next = 1; next <= 3; next++)
    {
        var nextPoint = Move(currentPoint.X, currentPoint.Y, currentPoint.Dir, next);
        if (map[nextPoint.y, nextPoint.x] == 1) break;
        if (nextPoint.x == currentPoint.X && nextPoint.y == currentPoint.Y) continue;
        if (dp[nextPoint.y, nextPoint.x, currentPoint.Dir] < count + 1) continue;
        dp[nextPoint.y, nextPoint.x, currentPoint.Dir] = count + 1;
        queue.Enqueue((new Point(nextPoint.x, nextPoint.y, currentPoint.Dir), count + 1));
    }

    // Turn Left
    var leftDir = TurnLeft(currentPoint.Dir);
    if (dp[currentPoint.Y, currentPoint.X, leftDir] > count + 1)
    {
        dp[currentPoint.Y, currentPoint.X, leftDir] = count + 1;
        queue.Enqueue((new Point(currentPoint.X, currentPoint.Y, leftDir), count + 1));
    }

    // Turn Right
    var rightDir = TurnRight(currentPoint.Dir);
    if (dp[currentPoint.Y, currentPoint.X, rightDir] > count + 1)
    {
        dp[currentPoint.Y, currentPoint.X, rightDir] = count + 1;
        queue.Enqueue((new Point(currentPoint.X, currentPoint.Y, rightDir), count + 1));
    }
}

sw.WriteLine(dp[endPoint.Y, endPoint.X, endPoint.Dir]);

int TurnLeft(int dir)
{
    var result = 0;
    switch (dir)
    {
        case 1:             // 동
            result = 4;     // 북
            break;
        case 2:             // 서
            result = 3;     // 남
            break;
        case 3:             // 남
            result = 1;     // 동
            break;
        case 4:             // 북
            result = 2;     // 서
            break;
    }

    return result;
}

int TurnRight(int dir)
{
    var result = 0;
    switch (dir)
    {
        case 1:                 // 동
            result = 3;         // 남
            break;
        case 2:                 // 서
            result = 4;         // 북
            break;
        case 3:                 // 남
            result = 2;         // 서
            break;
        case 4:                 // 북
            result = 1;         // 동
            break;
    }

    return result;
}

(int x, int y) Move(int x, int y, int dir, int next)
{
    var result = (x, y);
    switch (dir)
    {
        case 1:
            result.x += next;
            break;
        case 2:
            result.x -= next;
            break;
        case 3:
            result.y += next;
            break;
        case 4:
            result.y -= next;
            break;
    }

    if (result.x < 1 || result.x > N || result.y < 1 || result.y > M)
    {
        result = (x, y);
    }

    return result;
}


sw.Close();
sr.Close();


class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Dir { get; set; }

    public Point(int x, int y, int dir)
    {
        X = x;
        Y = y;
        Dir = dir;
    }
}