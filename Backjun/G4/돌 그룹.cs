var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var A = inputs[0];
var B = inputs[1];
var C = inputs[2];

var max = A + B + C;
var visited = new bool[max + 1, max + 1];
var check = false;
BFS();

void BFS()
{
    var q = new Queue<(int a, int b)>();
    q.Enqueue((A, B));
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var a = current.a;
        var b = current.b;
        var c = max - a - b;

        if (a < 0 || b < 0 || c < 0) continue;

        if (a == b && b == c)
        {
            check = true;
            break;
        }

        var x = 0;
        var y = 0;
        var z = 0;
        if (Solution(a, b, out int x1, out int y1))
        {
            z = max - x1 - y1;
            x = Math.Min(Math.Min(x1, y1), z);
            y = Math.Max(Math.Max(x1, y1), z);
            if (visited[x, y] == false)
            {
                visited[x, y] = true;
                q.Enqueue((x, y));
            }
        }

        if (Solution(a, c, out int x2, out int y2))
        {
            z = max - x2 - y2;
            x = Math.Min(Math.Min(x2, y2), z);
            y = Math.Max(Math.Max(x2, y2), z);
            if (visited[x, y] == false)
            {
                visited[x, y] = true;
                q.Enqueue((x, y));
            }
        }

        if (Solution(b, c, out int x3, out int y3))
        {
            z = max - x3 - y3;
            x = Math.Min(Math.Min(x3, y3), z);
            y = Math.Max(Math.Max(x3, y3), z);
            if (visited[x, y] == false)
            {
                visited[x, y] = true;
                q.Enqueue((x, y));
            }
        }
    }

    bool Solution(int left, int right, out int nextLeft, out int nextRight)
    {
        nextLeft = -1;
        nextRight = -1;

        if (left == right)
        {
            return false;
        }

        if (left > right)
        {
            nextLeft = left - right;
            nextRight = right + right;
        }

        if (left < right)
        {
            nextLeft = left + left;
            nextRight = right - left;
        }


        return true;
    }

    sw.WriteLine(check ? 1 : 0);
}

sw.Flush();
sw.Close();
sr.Close();