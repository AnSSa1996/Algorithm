var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var rankArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var graph = new int[N + 1, N + 1];
    var indegree = new int[N + 1];

    for (var i = 0; i < N; i++)
    {
        for (var j = i + 1; j < N; j++)
        {
            graph[rankArray[i], rankArray[j]] = 1;
            indegree[rankArray[j]]++;
        }
    }
    
    var M = int.Parse(sr.ReadLine());
    
    for (var m = 0; m < M; m++)
    {
        var change = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var a = change[0];
        var b = change[1];
        if (graph[a, b] == 1)
        {
            graph[a, b] = 0;
            graph[b, a] = 1;
            indegree[a]++;
            indegree[b]--;
        }
        else
        {
            graph[a, b] = 1;
            graph[b, a] = 0;
            indegree[a]--;
            indegree[b]++;
        }
    }
    
    var result = new List<int>();
    var queue = new Queue<int>();

    for (var i = 1; i <= N; i++)
    {
        if (indegree[i] == 0)
            queue.Enqueue(i);
    }
    
    
    var isPossible = true;
    var isAmbiguous = false;
    
    for (var i = 0; i < N; i++)
    {
        if (queue.Count == 0)
        {
            isPossible = false;
            break;
        }

        if (queue.Count >= 2)
        {
            isAmbiguous = true;
        }

        var now = queue.Dequeue();
        result.Add(now);

        for (var j = 1; j <= N; j++)
        {
            if (graph[now, j] == 1)
            {
                indegree[j]--;
                if (indegree[j] == 0)
                    queue.Enqueue(j);
            }
        }
    }
    
    if (!isPossible)
    {
        sw.WriteLine("IMPOSSIBLE");
    }
    else if (isAmbiguous)
    {
        sw.WriteLine("?");
    }
    else
    {
        sw.WriteLine(string.Join(" ", result));
    }
    
}

sr.Close();
sw.Close();