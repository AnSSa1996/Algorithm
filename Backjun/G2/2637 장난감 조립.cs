var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var M = int.Parse(sr.ReadLine());

var graph = new List<(int part, int cost)>[N + 1];
var need = new int[N + 1];
var answer = new int[N + 1];
answer[N] = 1;

for (var i = 1; i <= N; i++)
{
    graph[i] = new List<(int part, int cost)>();
}

for (var i = 0; i < M; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var part = input[0];
    var target = input[1];
    var cost = input[2];

    graph[part].Add((target, cost));
    need[target]++;
}

var q = new Queue<int>();
q.Enqueue(N);

while (q.Count > 0)
{
    var now = q.Dequeue();

    foreach (var (part, cost) in graph[now])
    {
        need[part]--;
        answer[part] += answer[now] * cost;

        if (need[part] == 0)
        {
            q.Enqueue(part);
        }
        
    }
}

for (var i = 1; i <= N; i++)
{
    if (graph[i].Count == 0)
    {
        sw.WriteLine($"{i} {answer[i]}");
    }
}

sw.Flush();
sw.Close();
sr.Close();