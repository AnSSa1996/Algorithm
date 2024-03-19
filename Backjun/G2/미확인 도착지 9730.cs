var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var M = inputs[1];
    var Target = inputs[2];
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var S = inputs[0];
    var G = inputs[1];
    var H = inputs[2];

    var graph = new int[N + 1, N + 1];

    for (var m = 0; m < M; m++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var start = inputs[0];
        var end = inputs[1];
        var weight = inputs[2];

        graph[start, end] = weight;
        graph[end, start] = weight;
    }
    
    var SDistance = Dijkstra(graph, S);
    var GDistance = Dijkstra(graph, G);
    var HDistance = Dijkstra(graph, H);
    
    var answer = new List<int>();
    
    for (var i = 0; i < Target; i++)
    {
        var destination = int.Parse(sr.ReadLine());
        var distance = SDistance[destination];
        if (distance == SDistance[G] + graph[G, H] + HDistance[destination] || distance == SDistance[H] + graph[H, G] + GDistance[destination])
        {
            answer.Add(destination);
        }
    }
    
    answer.Sort();
    sw.WriteLine(string.Join(" ", answer));
}

int[] Dijkstra(int[,] graph, int start)
{
    var N = graph.GetLength(0);
    var distance = new int[N];
    var visited = new bool[N];
    for (var i = 0; i < N; i++)
    {
        distance[i] = int.MaxValue;
    }

    distance[start] = 0;

    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(start, 0);
    visited[start] = true;

    while (pq.Count > 0)
    {
        var current = pq.Dequeue();
        visited[current] = true;

        for (var i = 0; i < N; i++)
        {
            if (graph[current, i] == 0)
            {
                continue;
            }

            if (visited[i])
            {
                continue;
            }

            if (distance[i] > distance[current] + graph[current, i])
            {
                distance[i] = distance[current] + graph[current, i];
                pq.Enqueue(i, distance[i]);
            }
        }
    }

    return distance;
}

sw.Close();
sr.Close();