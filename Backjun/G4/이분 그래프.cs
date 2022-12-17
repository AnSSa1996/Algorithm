StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


var T = int.Parse(sr.ReadLine());
var check = false;

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var V = inputs[0];
    var E = inputs[1];
    var visited = new int[V + 1];
    var lines = new List<List<int>>();
    for (var i = 0; i <= V; i++) lines.Add(new List<int>());
    for (var i = 0; i < E; i++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var left = inputs[0];
        var right = inputs[1];
        lines[left].Add(right);
        lines[right].Add(left);
    }

    var result = false;
    for (var i = 1; i <= V; i++)
    {
        if (visited[i] != 0) continue;
        result = BFS(i);
        if (result == false) break;
    }

    sw.WriteLine(result ? "YES" : "NO");

    bool BFS(int start)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        visited[start] = 1;
        while (q.Count > 0)
        {
            var pos = q.Dequeue();
            foreach (var next in lines[pos])
            {
                if (visited[next] == 0)
                {
                    q.Enqueue(next);
                    visited[next] = -visited[pos];
                }
                else if (visited[next] == visited[pos])
                {
                    return false;
                }
            }
        }

        return true;
    }
}


sw.Close();
sr.Close();