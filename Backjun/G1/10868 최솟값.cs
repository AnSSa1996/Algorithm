var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var nums = new long[N + 1];

for (var i = 1; i <= N; i++)
{
    nums[i] = long.Parse(sr.ReadLine());
}

var segmentTree = new SegmentTree[N * 4];
for (var i = 0; i < N * 4; i++)
{
    segmentTree[i] = new SegmentTree();
}

Init(1, 1, N);

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    sw.WriteLine(Query(1, 1, N, left, right));
}

sr.Close();
sw.Close();

void Init(int node, int start, int end)
{
    if (start == end)
    {
        segmentTree[node].MinValue = nums[start];
        return;
    }

    var mid = (start + end) / 2;
    Init(node * 2, start, mid);
    Init(node * 2 + 1, mid + 1, end);
    segmentTree[node].MinValue = Math.Min(segmentTree[node * 2].MinValue, segmentTree[node * 2 + 1].MinValue);
}

long Query(int node, int start, int end, int left, int right)
{
    if (left > end || right < start)
    {
        return long.MaxValue;
    }

    if (left <= start && end <= right)
    {
        return segmentTree[node].MinValue;
    }

    var mid = (start + end) / 2;
    return Math.Min(Query(node * 2, start, mid, left, right), Query(node * 2 + 1, mid + 1, end, left, right));
}

public class SegmentTree
{
    public long MinValue = long.MaxValue;
}