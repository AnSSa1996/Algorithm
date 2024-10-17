var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var N = inputs[0];
var M = inputs[1];

var segmentTree = new long[4 * N];

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];


    if (a == 0)
    {
        if (b > c)
        {
            (b, c) = (c, b);
        }

        sw.WriteLine(Query(1, 1, N, b, c));
    }
    else
    {
        Update(1, 1, N, b, c);
    }
}

sr.Close();
sw.Close();


void Update(long node, long start, long end, long index, long value)
{
    if (index < start || index > end)
        return;

    if (start == end)
    {
        segmentTree[node] = value;
        return;
    }

    var mid = (start + end) / 2;
    Update(node * 2, start, mid, index, value);
    Update(node * 2 + 1, mid + 1, end, index, value);

    segmentTree[node] = segmentTree[node * 2] + segmentTree[node * 2 + 1];
}

long Query(long node, long start, long end, long left, long right)
{
    if (left > end || right < start)
        return 0;

    if (left <= start && end <= right)
        return segmentTree[node];

    var mid = (start + end) / 2;
    return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
}