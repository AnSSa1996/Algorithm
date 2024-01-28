var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];
var M = inputs[1];

var map = new char[N, M];
for (var i = 0; i < N; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < M; j++)
    {
        map[i, j] = line[j];
    }
}

var parent = new int[N * M];
for (var i = 0; i < N * M; i++)
{
    parent[i] = i;
}

var visited = new bool[N, M];
for (var y = 0; y < N; y++)
{
    for (var x = 0; x < M; x++)
    {
        if (visited[y, x]) continue;
        visited[y, x] = true;
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue((y, x));
        while (queue.Count > 0)
        {
            var (currentY, currentX) = queue.Dequeue();
            var nextY = 0;
            var nextX = 0;
            if (map[currentY, currentX] == 'D')
            {
                nextY = currentY + 1;
                nextX = currentX;
            }
            else if (map[currentY, currentX] == 'U')
            {
                nextY = currentY - 1;
                nextX = currentX;
            }
            else if (map[currentY, currentX] == 'R')
            {
                nextY = currentY;
                nextX = currentX + 1;
            }
            else if (map[currentY, currentX] == 'L')
            {
                nextY = currentY;
                nextX = currentX - 1;
            }

            if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= M) continue;
            if (visited[nextY, nextX])
            {
                Union(currentY * M + currentX, nextY * M + nextX);
                continue;
            }

            visited[nextY, nextX] = true;
            Union(currentY * M + currentX, nextY * M + nextX);
            queue.Enqueue((nextY, nextX));
        }
    }
}

void Union(int a, int b)
{
    a = Find(a);
    b = Find(b);
    if (a == b) return;
    if (a > b) (a, b) = (b, a);
    parent[b] = a;
}

int Find(int a)
{
    if (parent[a] == a) return a;
    return parent[a] = Find(parent[a]);
}

var answer = 0;
for (var i = 0; i < N * M; i++)
{
    if (parent[i] == i) answer++;
}

sw.WriteLine(answer);
sw.Close();
sr.Close();