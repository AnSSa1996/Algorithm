using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];          // 가수의 수
var M = inputs[1];          // 보조 PD의 수

var graph = new List<int>[N + 1];
var indegree = new int[N + 1];

for (var i = 1; i <= N; i++)
{
    graph[i] = new List<int>();
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var nums = inputs[0]; // 보조 PD가 담당한 가수의 수
    var prev = inputs[1]; // 이전 가수의 번호

    for (var j = 2; j <= nums; j++)
    {
        var current = inputs[j]; // 현재 가수의 번호
        graph[prev].Add(current);
        indegree[current]++;
        prev = current;
    }
}

var result = new List<int>();
var queue = new Queue<int>();

for (var i = 1; i <= N; i++)
{
    if (indegree[i] == 0)
    {
        queue.Enqueue(i);
    }
}

while (queue.Count > 0)
{
    var current = queue.Dequeue();
    if (result.Contains(current))
    {
        continue;
    }
    result.Add(current);

    foreach (var next in graph[current])
    {
        indegree[next]--;
        if (indegree[next] == 0)
        {
            queue.Enqueue(next);
        }
    }
}

var stringBuilder = new StringBuilder();
if (result.Count == N)
{
    foreach (var item in result)
    {
        stringBuilder.Append($"{item}\n");
    }
}
else
{
    stringBuilder.Append("0");
}

sw.Write(stringBuilder.ToString());

sr.Close();
sw.Close();