var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var V = int.Parse(sr.ReadLine());            // 트리 정점의 갯수
var adjList = new List<(int, int)>[V + 1];      // 인접리스트
for (var i = 1; i <= V; i++) {
    adjList[i] = new List<(int, int)>();
}

for (var i = 0; i < V; i++) {
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var node = input[0];
    for (var j = 1; j < input.Length - 1; j += 2) {
        var child = input[j];
        var weight = input[j + 1];
        adjList[node].Add((child, weight));
    }
}

var max = 0;
int BFS(int start)
{
    var visited = new bool[V + 1];
    var queue = new Queue<(int current, int weight)>();
    queue.Enqueue((start, 0));
    visited[start] = true;

    max = 0;
    var maxIndex = 0;
    while (queue.Count > 0)
    {
        var (node, weight) = queue.Dequeue();
        foreach (var adj in adjList[node])
        {
            var (nextNode, nextWeight) = adj;
            if (visited[nextNode]) continue;
            queue.Enqueue((nextNode, weight + nextWeight));
            visited[nextNode] = true;
            if (max < weight + nextWeight)
            {
                max = weight + nextWeight;
                maxIndex = nextNode;
            }
        }
    }
    
    return maxIndex;
}

var first = BFS(1);
var second = BFS(first);
sw.WriteLine(max);
sw.Close();
sr.Close();