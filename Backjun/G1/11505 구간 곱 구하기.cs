var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

long div = 1000000007;
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var K = inputs[2];
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

for (var i = 0; i < M + K; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];
    if (a == 1)
    {
        Update(1, 1, N, b, c);
    }
    else
    {
        sw.WriteLine(Query(1, 1, N, b, c));
    }
}

sr.Close();
sw.Close();

void Init(long node, long start, long end)
{
    if (start == end)
    {
        segmentTree[node].Value = nums[start] % div;
        return;
    }

    var mid = (start + end) / 2;
    Init(node * 2, start, mid);
    Init(node * 2 + 1, mid + 1, end);
    segmentTree[node].Value = segmentTree[node * 2].Value * segmentTree[node * 2 + 1].Value % div;
}

void Update(long node, long start, long end, long index, long value)
{
    if (index < start || index > end)
    {
        return;
    }

    if (start == end)
    {
        segmentTree[node].Value = value;
        return;
    }

    var mid = (start + end) / 2;
    Update(node * 2, start, mid, index, value);
    Update(node * 2 + 1, mid + 1, end, index, value);
    segmentTree[node].Value = segmentTree[node * 2].Value * segmentTree[node * 2 + 1].Value % div;
}

long Query(long node, long start, long end, long left, long right)
{
    if (left > end || right < start)
    {
        return 1;
    }

    if (left <= start && end <= right)
    {
        return segmentTree[node].Value;
    }

    var mid = (start + end) / 2;
    var leftValue = Query(node * 2, start, mid, left, right);
    var rightValue = Query(node * 2 + 1, mid + 1, end, left, right);
    var result = leftValue * rightValue % div;
    return result;
}

public class SegmentTree
{
    public long Value;
}