var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var K = inputs[2]; // 벽을 부술 수 있는 횟수

var board = new int[Y, X];

for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().ToCharArray(), c => c - '0');
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
    }
}

var visited = new bool[Y, X, K + 1, 2];

var queue = new Queue<(int y, int x, int k, bool day, int count)>();
queue.Enqueue((0, 0, K, true, 1));
visited[0, 0, K, 1] = true;

var dy = new int[] { -1, 1, 0, 0, 0 };
var dx = new int[] { 0, 0, -1, 1, 0 };

long answer = -1;

while (queue.Count > 0)
{
    var (y, x, k, day, count) = queue.Dequeue();
    if (y == Y - 1 && x == X - 1)
    {
        answer = count;
        break;
    }

    for (var d = 0; d < 5; d++)
    {
        var nextY = y + dy[d];
        var nextX = x + dx[d];

        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X)
        {
            continue;
        }

        if (board[nextY, nextX] == 0 || (nextY == y && nextX == x))
        {
            if (visited[nextY, nextX, k, day == true ? 0 : 1]) continue;
            visited[nextY, nextX, k, day == true ? 0 : 1] = true;
            queue.Enqueue((nextY, nextX, k, day != true, count + 1));
        }
        else
        {
            if (day == false) continue;
            if (k == 0) continue;
            if (visited[nextY, nextX, k - 1, day == true ? 0 : 1]) continue;
            visited[nextY, nextX, k - 1, day == true ? 0 : 1] = true;
            queue.Enqueue((nextY, nextX, k - 1, day != true, count + 1));
        }
    }
}

sw.WriteLine(answer);
sr.Close();
sw.Close();