var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var segmentTree = new Node[N * 4];
for (var i = 0; i < N * 4; i++)
{
    segmentTree[i] = new Node(long.MaxValue, 0);
}

Init(1, 1, N);

var M = int.Parse(sr.ReadLine());


for (var m = 0; m < M; m++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];


    if (a == 2)
    {
        if (b > c)
        {
            (b, c) = (c, b);
        }

        var node = Query(1, 1, N, b, c);
        sw.WriteLine(node.Value);
    }
    else
    {
        Update(1, 1, N, b, c);
    }
}

sr.Close();
sw.Close();

void Init(long node, long start, long end)
{
    if (start == end)
    {
        segmentTree[node] = new Node(nums[start - 1], start);
        return;
    }

    var mid = (start + end) / 2;
    Init(node * 2, start, mid);
    Init(node * 2 + 1, mid + 1, end);
    segmentTree[node] = Min(segmentTree[node * 2], segmentTree[node * 2 + 1]);
}


void Update(long node, long start, long end, long index, long value)
{
    if (index < start || index > end)
        return;

    if (start == end)
    {
        nums[index - 1] = value;
        segmentTree[node] = new Node(value, index);
        return;
    }

    var mid = (start + end) / 2;
    Update(node * 2, start, mid, index, value);
    Update(node * 2 + 1, mid + 1, end, index, value);
    segmentTree[node] = Min(segmentTree[node * 2], segmentTree[node * 2 + 1]);
}

Node Query(long node, long start, long end, long left, long right)
{
    if (left > end || right < start)
        return new Node(long.MaxValue, 0);

    if (left <= start && end <= right)
        return segmentTree[node];

    var mid = (start + end) / 2;
    return Min(Query(node * 2, start, mid, left, right), Query(node * 2 + 1, mid + 1, end, left, right));
}

Node Min(Node a, Node b)
{
    return a.Value < b.Value ? a : b;
}

public class Node
{
    public long Value { get; set; }

    public Node(long value, long index)
    {
        Value = value;
    }
}