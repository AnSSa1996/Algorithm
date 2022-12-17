using System.Runtime.InteropServices;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var Q = inputs[1];
var node = new List<List<(int nextNode, int usado)>>();

for (var i = 0; i <= N; i++)
{
    node.Add(new List<(int nextNode, int usado)>());
}

for (var i = 1; i < N; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var usado = inputs[2];
    node[left].Add((right, usado));
    node[right].Add((left, usado));
}

for (var q = 0; q < Q; q++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var K = inputs[0];
    var V = inputs[1];

    int count = -1;
    var visited = new bool[N + 1];

    DFS(V, 1000000000);

    void DFS(int currentNode, int currentUsado)
    {
        visited[currentNode] = true;
        if (currentUsado >= K)
        {
            count++;
        }

        foreach (var next in node[currentNode])
        {
            var nextNode = next.nextNode;
            var nextUsado = next.usado;
            if (visited[nextNode]) continue;
            if (nextUsado < currentUsado)
            {
                DFS(nextNode, nextUsado);
            }
            else
            {
                DFS(nextNode, currentUsado);
            }
        }
    }

    sw.WriteLine(count);
}

sr.Close();
sw.Close();