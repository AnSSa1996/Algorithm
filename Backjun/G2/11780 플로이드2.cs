var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine()); // 도시의 갯수
var M = int.Parse(sr.ReadLine()); // 버스의 갯수
var INF = 1000000000;

var dist = new int[N + 1, N + 1];
var path = new int[N + 1, N + 1];
for (var i = 1; i <= N; i++)
{
    for (var j = 1; j <= N; j++)
    {
        if (i == j)
        {
            dist[i, j] = 0;
            continue;
        }
        dist[i, j] = INF;
    }
}

for (var i = 0; i < M; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = input[0];
    var b = input[1];
    var c = input[2];
    dist[a, b] = Math.Min(dist[a, b], c);
    path[a, b] = b;
}

for (var k = 1; k <= N; k++)
{
    for (var i = 1; i <= N; i++)
    {
        for (var j = 1; j <= N; j++)
        {
            if (dist[i, j] > dist[i, k] + dist[k, j])
            {
                dist[i, j] = dist[i, k] + dist[k, j];
                path[i, j] = path[i, k];
            }
        }
    }
}

for (var i = 1; i <= N; i++)
{
    for (var j = 1; j <= N; j++)
    {
        if (dist[i, j] == INF)
        {
            sw.Write(0 + " ");
        }
        else
        {
            sw.Write(dist[i, j] + " ");
        }
    }
    sw.WriteLine();
}


for (var i = 1; i <= N; i++)
{
    for (var j = 1; j <= N; j++)
    {
        if (dist[i, j] == INF || i == j)
        {
            sw.WriteLine(0);
        }
        else
        {
            var current = i;
            var pathList = new List<int>();
            pathList.Add(current);
            while (current != j)
            {
                pathList.Add(path[current, j]);
                current = path[current, j];
            }
            sw.Write(pathList.Count + " ");
            foreach (var item in pathList)
            {
                sw.Write(item + " ");
            }
            sw.WriteLine();
        }
    }
}


sw.Flush();
sw.Close();
sr.Close();