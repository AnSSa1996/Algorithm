using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Xml.XPath;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var K = inputs[1];

var board = new List<List<(int next, int distance)>>();
for (int i = 0; i <= N; i++)
{
    board.Add(new List<(int next, int distance)>());
}

for (var i = 0; i < N - 1; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var X = inputs[0];
    var Y = inputs[1];
    var distance = inputs[2];
    board[X].Add((Y, distance));
    board[Y].Add((X, distance));
}

var visited = new bool[N + 1];
var result = 0;
for (int i = 0; i < K; i++)
{
    visited = new bool[N + 1];
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    visited[start] = true;
    DFS(start, end, 0);
    sw.WriteLine(result);
}

void DFS(int current, int target, int elapsedDistance)
{
    if (current == target)
    {
        result = elapsedDistance;
        return;
    }

    foreach (var next in board[current])
    {
        var nextNode = next.next;
        var nextDistance = next.distance;
        if (visited[nextNode]) continue;
        visited[nextNode] = true;
        DFS(nextNode, target, elapsedDistance + nextDistance);
    }
}

sw.Flush();
sw.Close();
sr.Close();