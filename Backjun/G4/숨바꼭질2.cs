var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var start = inputs[0];
var end = inputs[1];
var vistied = new int[100001];
BFS();

void BFS()
{
    var q = new Queue<(int pos, int depth)>();
    q.Enqueue((start, 0));
    var count = 0;
    var answer = 0;
    var min = int.MaxValue;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var pos = current.pos;
        var depth = current.depth;
        if (depth > min) continue;
        if (pos == end)
        {
            answer = depth;
            count++;
            continue;
        }

        var next = pos + 1;
        if (next <= 100000 && (vistied[next] == 0 || vistied[next] == depth + 1))
        {
            vistied[next] = depth + 1;
            q.Enqueue((next, depth + 1));
        }

        var prev = pos - 1;
        if (prev >= 0 && (vistied[prev] == 0 || vistied[prev] == depth + 1))
        {
            vistied[prev] = depth + 1;
            q.Enqueue((prev, depth + 1));
        }

        var multiply = pos * 2;
        if (multiply <= 100000 && (vistied[multiply] == 0 || vistied[multiply] == depth + 1))
        {
            vistied[multiply] = depth + 1;
            q.Enqueue((multiply, depth + 1));
        }
    }

    sw.WriteLine(answer);
    sw.WriteLine(count);
}

sr.Close();
sw.Close();