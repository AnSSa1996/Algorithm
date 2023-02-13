var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var caseCount = 0;
while (true)
{
    caseCount++;
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var M = inputs[1];
    if (N == 0 && M == 0) break;
    var failCheck = new bool[N + 1];
    var parent = Enumerable.Range(0, N + 1).ToArray();
    for (var m = 0; m < M; m++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var left = inputs[0];
        var right = inputs[1];
        Union(left, right);
    }

    var count = 0;
    for (var n = 1; n <= N; n++)
    {
        if (n != FindParent(n)) continue;
        if (failCheck[n]) continue;
        count++;
    }

    if (count == 0) sw.WriteLine($"Case {caseCount}: No trees.");
    else if (count == 1) sw.WriteLine($"Case {caseCount}: There is one tree.");
    else sw.WriteLine($"Case {caseCount}: A forest of {count} trees.");


    int FindParent(int x)
    {
        return x == parent[x] ? x : parent[x] = FindParent(parent[x]);
    }

    void Union(int left, int right)
    {
        if (left == right) return;
        left = FindParent(left);
        right = FindParent(right);
        if (left == right)
        {
            failCheck[left] = true;
            failCheck[right] = true;
        }

        if (failCheck[left] || failCheck[right])
        {
            failCheck[left] = true;
            failCheck[right] = true;
        }

        if (left < right) parent[right] = left;
        if (right < left) parent[left] = right;
    }
}


sw.Flush();
sw.Close();
sr.Close();