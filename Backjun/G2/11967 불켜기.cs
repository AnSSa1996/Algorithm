var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];


var lightDict = new Dictionary<(int x, int y), List<(int x, int y)>>();

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = inputs[0];
    var y = inputs[1];
    var a = inputs[2];
    var b = inputs[3];

    if (lightDict.ContainsKey((x, y)) == false)
    {
        lightDict[(x, y)] = new List<(int x, int y)>();
        lightDict[(x, y)].Add((a, b));
    }
    else
    {
        lightDict[(x, y)].Add((a, b));
    }
}

var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };

var canVisitHashSet = new HashSet<(int x, int y)>();
var lightHashSet = new HashSet<(int x, int y)>();
var visited = new bool[N + 1, N + 1];
var count = 1;
var queue = new Queue<(int x, int y)>();
queue.Enqueue((1, 1));
canVisitHashSet.Add((1, 1));
lightHashSet.Add((1, 1));

while (queue.Count > 0)
{
    var (x, y) = queue.Dequeue();
    if (visited[x, y]) continue;
    visited[x, y] = true;
    for (var d = 0; d < 4; d++)
    {
        var ny = y + dy[d];
        var nx = x + dx[d];
        if (ny < 1 || ny > N || nx < 1 || nx > N) continue;
        canVisitHashSet.Add((nx, ny));
        if (lightHashSet.Contains((nx, ny)) == false) continue;
        queue.Enqueue((nx, ny));
    }

    if (lightDict.ContainsKey((x, y)) == false) continue;
    foreach (var light in lightDict[(x, y)])
    {
        if (lightHashSet.Add((light.x, light.y)) == false) continue;
        count++;
        if (canVisitHashSet.Contains((light.x, light.y)) == false) continue;
        queue.Enqueue((light.x, light.y));
    }
}

sw.WriteLine(count);
sw.Flush();
sw.Close();