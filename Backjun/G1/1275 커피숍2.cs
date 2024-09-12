var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var Q = inputs[1];
var nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var segmentTree = new SegmentTree[4 * N];

for (var i = 0; i < segmentTree.Length; i++)
{
    segmentTree[i] = new SegmentTree();
}

Init(1, 0, N - 1);

for (var i = 0; i < Q; i++)
{
    var question = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = question[0];
    var y = question[1];
    var a = question[2];
    var b = question[3];
    
    if (x > y)
    {
        (x, y) = (y, x);
    }
    
    sw.WriteLine(Query(1, 0, N - 1, x - 1, y - 1));
    var diff = b - nums[a - 1];
    Update(1, 0, N - 1, a - 1, diff);
}


sr.Close();
sw.Close();

long Init(int node, int start, int end)
{
    if (start == end)
    {
        return segmentTree[node].Sum = nums[start];
    }

    var mid = (start + end) / 2;
    var leftSum = Init(node * 2, start, mid);
    var rightSum = Init(node * 2 + 1, mid + 1, end);

    return segmentTree[node].Sum = leftSum + rightSum;
}

long Query(int node, int start, int end, int left, int right)
{
    if (left > end || right < start)
    {
        return 0;
    }

    if (left <= start && end <= right)
    {
        return segmentTree[node].Sum;
    }

    var mid = (start + end) / 2;
    var leftSum = Query(node * 2, start, mid, left, right);
    var rightSum = Query(node * 2 + 1, mid + 1, end, left, right);

    return leftSum + rightSum;
}

void Update(int node, int start, int end, int index, long diff)
{
    if (index < start || index > end)
    {
        return;
    }

    segmentTree[node].Sum += diff;

    if (start == end)
    {
        nums[index] += diff;
        return;
    }

    var mid = (start + end) / 2;
    Update(node * 2, start, mid, index, diff);
    Update(node * 2 + 1, mid + 1, end, index, diff);
}

class SegmentTree
{
    public long Sum;
}