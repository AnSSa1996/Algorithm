using System.Numerics;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var N = inputs[0];
var M = inputs[1];
var K = inputs[2];

var nums = new BigInteger[N + 1];
var segTree = new BigInteger[4 * N];

for (var i = 1; i <= N; i++)
{
    nums[i] = BigInteger.Parse(sr.ReadLine());
}

BuildTree(1,1,N);

for (var i = 0; i < M + K; i++)
{
    var query = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    if (query[0] == 1)
    {
        var diff = query[2] - nums[query[1]];
        nums[query[1]] = query[2];
        UpdateTree(1, 1, N, query[1], diff);
    }
    else
    {
        sw.WriteLine(Query(1, 1, N, query[1], query[2]));
    }
}


sr.Close();
sw.Close();

void BuildTree(long node, long start, long end)
{
    if (start == end)
    {
        segTree[node] = nums[start];
        return;
    }

    var mid = (start + end) / 2;
    BuildTree(node * 2, start, mid);
    BuildTree(node * 2 + 1, mid + 1, end);
    segTree[node] = segTree[node * 2] + segTree[node * 2 + 1];
}

void UpdateTree(long node, long start, long end, long index, BigInteger diff)
{
    if (index < start || index > end) return;
    segTree[node] += diff;
    if (start == end) return;
    var mid = (start + end) / 2;
    UpdateTree(node * 2, start, mid, index, diff);
    UpdateTree(node * 2 + 1, mid + 1, end, index, diff);
}

BigInteger Query(long node, long start, long end, long left, long right)
{
    if (left > end || right < start) return 0;
    if (left <= start && end <= right) return segTree[node];
    var mid = (start + end) / 2;
    return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
}