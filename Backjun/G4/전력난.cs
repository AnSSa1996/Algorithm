var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

while (true)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var M = inputs[0];
    var N = inputs[1];
    if (M == 0 && N == 0) break;

    var board = new List<List<(int next, int distance)>>();
    var parent = Enumerable.Range(0, M).ToArray();
    long total = 0;
    for (var m = 0; m < M; m++)
    {
        board.Add(new List<(int next, int distance)>());
    }

    var pq = new PriorityQueue<(int left, int right, int distance), int>();
    for (var index = 0; index < N; index++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var left = inputs[0];
        var right = inputs[1];
        var distance = inputs[2];
        pq.Enqueue((left, right, distance), distance);
        total += inputs[2];
    }

    long result = 0;
    var count = 0;

    int FindParent(int x)
    {
        return x == parent[x] ? x : FindParent(parent[x]);
    }

    bool Union(int x, int y)
    {
        x = FindParent(x);
        y = FindParent(y);
        if (x == y) return false;
        if (x < y) parent[y] = x;
        else parent[x] = y;
        return true;
    }

    while (pq.Count > 0)
    {
        var current = pq.Dequeue();
        var left = current.left;
        var right = current.right;
        var distance = current.distance;
        if (Union(left, right) == false) continue;
        result += distance;
    }

    sw.WriteLine(total - result);
}

sw.Flush();
sw.Close();
sr.Close();