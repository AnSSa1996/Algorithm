using System.Numerics;
using System.Runtime.CompilerServices;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var board = new int[N, N];
var virusList = new List<(int y, int x)>();
var zeroCount = 0;
for (var y = 0; y < N; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        board[y, x] = inputs[x];
        if (inputs[x] == 0 || inputs[x] == 2) zeroCount++;
        if (inputs[x] == 2)
        {
            virusList.Add((y, x));
            board[y, x] = 0;
        }
    }
}

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };
var totalVirusLength = virusList.Count;
var comb = MakeComb(totalVirusLength, M);
var result = int.MaxValue;

while (comb != null)
{
    BFS(comb);
    comb = Successor(comb, totalVirusLength, M);
}

void BFS(int[] virusArray)
{
    var q = new Queue<(int y, int x, int depth)>();
    var visited = new bool[N, N];

    foreach (var virusIndex in virusArray)
    {
        var virus = virusList[virusIndex];
        q.Enqueue((virus.y, virus.x, 0));
        visited[virus.y, virus.x] = true;
    }

    var count = 0;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var y = current.y;
        var x = current.x;
        var depth = current.depth;
        count++;
        if (depth >= result) return;
        if (count == zeroCount)
        {
            result = Math.Min(result, depth);
            return;
        }

        for (var d = 0; d < 4; d++)
        {
            var nextY = y + dy[d];
            var nextX = x + dx[d];
            if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N) continue;
            if (visited[nextY, nextX]) continue;
            if (board[nextY, nextX] == 1) continue;
            visited[nextY, nextX] = true;
            q.Enqueue((nextY, nextX, depth + 1));
        }
    }
}

if (result == int.MaxValue) sw.WriteLine(-1);
else sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();

static int[] MakeComb(int n, int k)
{
    int[] result = new int[k];
    for (int i = 0; i < k; i++)
        result[i] = i;
    return result;
}

static void ShowComb(int[] comb)
{
    int n = comb.Length;
    for (int i = 0; i < n; ++i)
        Console.Write(comb[i] + " ");
    Console.WriteLine("");
}

static bool IsLast(int[] comb, int n, int k)
{
    // is comb(8,3) like [5,6,7] ?
    if (comb[0] == n - k)
        return true;
    else
        return false;
}

static int[] Successor(int[] comb, int n, int k)
{
    if (IsLast(comb, n, k) == true)
        return null;

    //int i;
    int[] result = new int[k]; // make copy
    for (int i = 0; i < k; ++i)
        result[i] = comb[i];

    int idx = k - 1;
    while (idx > 0 && result[idx] == n - k + idx)
        --idx;

    ++result[idx];

    for (int j = idx; j < k - 1; ++j)
        result[j + 1] = result[j] + 1;

    return result;
}

static int[] Element(BigInteger m, int n, int k)
{
    // compute element [m] using the combinadic
    BigInteger maxM = Choose(n, k) - 1;

    if (m > maxM)
        throw new Exception("m value is too large in Element");

    int[] ans = new int[k];

    int a = n;
    int b = k;
    BigInteger x = maxM - m; // x is the "dual" of m

    for (int i = 0; i < k; ++i)
    {
        ans[i] = LargestV(a, b, x); // see helper below    
        x = x - Choose(ans[i], b);
        a = ans[i];
        b = b - 1;
    }

    for (int i = 0; i < k; ++i)
        ans[i] = (n - 1) - ans[i];

    return ans;
}

static int LargestV(int a, int b, BigInteger x)
{
    int v = a - 1;
    while (Choose(v, b) > x)
        --v;
    return v;
}

static BigInteger Choose(int n, int k)
{
    // number combinations
    if (n < 0 || k < 0)
        throw new Exception("Negative argument in Choose()");
    if (n < k) return 0; // special
    if (n == k) return 1; // short-circuit

    int delta, iMax;

    if (k < n - k) // ex: Choose(100,3)
    {
        delta = n - k;
        iMax = k;
    }
    else // ex: Choose(100,97)
    {
        delta = k;
        iMax = n - k;
    }

    BigInteger ans = delta + 1;
    for (int i = 2; i <= iMax; ++i)
        ans = (ans * (delta + i)) / i;

    return ans;
}