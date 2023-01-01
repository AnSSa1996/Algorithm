var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var distance = Enumerable.Repeat(-1, N + 1).ToArray();

var board = new List<List<(int target, int weight)>>();
for (var i = 0; i <= N; i++)
{
    board.Add(new List<(int target, int weight)>());
}

for (var i = 0; i < N - 1; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var weight = inputs[2];

    board[left].Add((right, weight));
    board[right].Add((left, weight));
}

void DFS(int current, int weight)
{
    foreach (var next in board[current])
    {
        var t = next.target;
        var w = next.weight;

        if (distance[t] != -1) continue;
        distance[t] = weight + w;
        DFS(t, weight + w);
    }
}

distance[1] = 0;
DFS(1, 0);
var max = distance.Max();
var start = Array.IndexOf(distance, max);
distance = Enumerable.Repeat(-1, N + 1).ToArray();
distance[start] = 0;
DFS(start, 0);
sw.WriteLine(distance.Max());


sw.Close();
sr.Close();