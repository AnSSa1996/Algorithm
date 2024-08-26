var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var nums = new long[N];
for (var i = 0; i < N; i++)
{
    nums[i] = long.Parse(sr.ReadLine());
}

var tree = Enumerable.Range(0, N * 4).Select(x => new SegmentTree()).ToArray();
TreeInit(1, 0, N - 1);

for(var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0] - 1;
    var end = inputs[1] - 1;
    
    var result = Query(1, 0, N - 1, start, end);
    sw.WriteLine($"{result.MinValue} {result.MaxValue}");
}

sr.Close();
sw.Close();

void TreeInit(int node, int start, int end)
{
    if (start == end)
    {
        tree[node].MaxValue = nums[start];
        tree[node].MinValue = nums[start];
        return;
    }

    var mid = (start + end) / 2;
    var left = node * 2;
    var right = node * 2 + 1;
    
    TreeInit(left, start, mid);
    TreeInit(right, mid + 1, end);
    
    tree[node].MaxValue = Math.Max(tree[left].MaxValue, tree[right].MaxValue);
    tree[node].MinValue = Math.Min(tree[left].MinValue, tree[right].MinValue);
}

SegmentTree Query(int node, int start, int end, int left, int right)
{
    if (left > end || right < start)
    {
        return new SegmentTree();
    }

    if (left <= start && end <= right)
    {
        return tree[node];
    }

    var mid = (start + end) / 2;
    var leftNode = Query(node * 2, start, mid, left, right);
    var rightNode = Query(node * 2 + 1, mid + 1, end, left, right);

    return new SegmentTree
    {
        MaxValue = Math.Max(leftNode.MaxValue, rightNode.MaxValue),
        MinValue = Math.Min(leftNode.MinValue, rightNode.MinValue)
    };
}


public class SegmentTree
{
    public long MaxValue { get; set; } = long.MinValue;
    public long MinValue { get; set; } = long.MaxValue;
}