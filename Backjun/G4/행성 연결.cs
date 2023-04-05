var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var parent = Enumerable.Range(0, N + 1).ToArray();
var pq = new PriorityQueue<(int cost, int left, int right), int>();
for (var y = 0; y < N; y++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = y + 1; x < N; x++)
    {
        var cost = inputs[x];
        pq.Enqueue((cost, y, x), cost);
    }
}

var reuslt = N - 1;
long answer = 0;

int FindParent(int x)
{
    return x == parent[x] ? x : FindParent(parent[x]);
}

bool Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);
    if (left == right) return false;

    if (left < right)
    {
        parent[right] = left;
    }
    else
    {
        parent[left] = right;
    }

    reuslt--;
    return true;
}

while (true)
{
    if (reuslt == 0) break;
    var current = pq.Dequeue();
    var cost = current.cost;
    var left = current.left;
    var right = current.right;
    var check = Union(left, right);
    if (check) answer += cost;
}

sw.WriteLine(answer);

sw.Flush();
sw.Close();
sr.Close();