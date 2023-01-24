StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
BFS();

void BFS()
{
    var visitedHashSet = new HashSet<(int pos, int clip)>();
    var q = new Queue<(int pos, int clipboard, int depth)>();
    q.Enqueue((1, 0, 0));
    var result = 0;

    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var pos = current.pos;
        var clipboard = current.clipboard;
        var depth = current.depth;
        if (N == pos)
        {
            result = depth;
            break;
        }

        if (visitedHashSet.Contains((pos, clipboard))) continue;
        visitedHashSet.Add((pos, clipboard));
        var nextClipboard = pos;
        q.Enqueue((pos, nextClipboard, depth + 1));
        q.Enqueue((pos + clipboard, clipboard, depth + 1));
        q.Enqueue((pos - 1, clipboard, depth + 1));
    }

    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();