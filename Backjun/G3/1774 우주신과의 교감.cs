var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];          // 우주신들의 개수
var M = inputs[1];          // 이미 연결된 신들과의 통로 개수

var parent = new int[N + 1];   // 연결된 우주신들의 부모 노드
for (var i = 1; i <= N; i++)
{
    parent[i] = i;
}

var gods = new List<(int x, int y)>(); // 우주신들의 좌표
for (var i = 1; i <= N; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    gods.Add((inputs[0], inputs[1]));
}
var edges = new PriorityQueue<(int x, int y, double distance), double>();   // 통로 정보

for (var i = 0; i < N - 1; i++)
{
    for (var j = i + 1; j < N; j++)
    {
        var x1 = gods[i].x;
        var y1 = gods[i].y;
        var x2 = gods[j].x;
        var y2 = gods[j].y;
        var distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        edges.Enqueue((i + 1, j + 1, distance), distance);
    }
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = inputs[0];
    var y = inputs[1];
    Union(x, y);
}

var answer = 0d;
while (edges.Count > 0)
{
    var edge = edges.Dequeue();
    var x = edge.x;
    var y = edge.y;
    var distance = edge.distance;
    if (Find(x) != Find(y))
    {
        Union(x, y);
        answer += distance;
    }
}

void Union(int x, int y)
{
    x = Find(x);
    y = Find(y);
    if (x != y)
    {
        parent[y] = x;
    }
}

int Find(int x)
{
    if (x == parent[x])
    {
        return x;
    }
    else
    {
        return parent[x] = Find(parent[x]);
    }
}

var result = Math.Round(answer, 2);
sw.WriteLine($"{result:0.00}");

sw.Close();
sr.Close();