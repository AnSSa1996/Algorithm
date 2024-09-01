var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var W = new int[N, N];
var D = new Dictionary<(int, int), int>();
var MAX = 1000000000;
var ALL = (1 << N) - 1;

for (var i = 0; i < N; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < N; j++)
    {
        W[i, j] = input[j];
    }
}

sw.WriteLine(TMP(1, 0));

int TMP(int visited, int n)
{
    if (visited == ALL)
    {
        return W[n, 0] == 0 ? MAX : W[n, 0];
    }
    
    if (D.ContainsKey((visited, n)))
    {
        return D[(visited, n)];
    }

    var minCost = MAX;
    for (var i = 0; i < N; i++)
    {
        var next = 1 << i;
        if ((visited & next) != 0 || W[n, i] == 0) continue;

        var nextMask = visited | next;
        var cost = TMP(nextMask, i) + W[n, i];
        minCost = Math.Min(minCost, cost);
    }
    
    D[(visited, n)] = minCost;
    return D[(visited, n)];
}

sr.Close();
sw.Close();