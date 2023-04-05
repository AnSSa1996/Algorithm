StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var dict = new Dictionary<int, List<int>>();

for (var i = 1; i <= N; i++)
{
    if (inputs[i - 1] == -1) continue;
    if (!dict.ContainsKey(inputs[i - 1])) dict[inputs[i - 1]] = new List<int>();
    dict[inputs[i - 1]].Add(i);
}

var dp = new int[N + 1];

void DFS(int start)
{
    var visited = new bool[N + 1];
    var queue = new Queue<int>();
    queue.Enqueue(start);

    while (queue.Count > 0)
    {
        var next = queue.Dequeue();
        if (visited[next]) continue;
        visited[next] = true;
        if (dict.ContainsKey(next) == false) continue;
        foreach (var nextVisit in dict[next])
        {
            if (visited[nextVisit]) continue;
            queue.Enqueue(nextVisit);
            dp[nextVisit] += dp[next];
        }
    }
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    dp[inputs[0]] += inputs[1];
}

DFS(1);

sw.WriteLine(string.Join(" ", dp[1..]));

sr.Close();
sw.Close();