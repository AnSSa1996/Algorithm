using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var segmentTree = Array.Empty<int>();
var nums = Array.Empty<int>();

while (true)
{
    if (sr.EndOfStream) break;
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0]; // 수열의 크기
    var K = inputs[1]; // K번째 수

    segmentTree = new int[N * 4];
    nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    InitSegmentTree(1, 0, N - 1);
    var stringBuilder = new StringBuilder();

    for (var i = 0; i < K; i++)
    {
        var charInputs = sr.ReadLine().Split();
        var order = charInputs[0];
        var left = int.Parse(charInputs[1]);
        var right = int.Parse(charInputs[2]);

        if (order == "C")
        {
            Change(1, 0, N - 1, left - 1, right);
        }
        else
        {
            var result = Query(1, 0, N - 1, left - 1, right - 1);
            if (result > 0)
                stringBuilder.Append("+");
            else if (result < 0)
                stringBuilder.Append("-");
            else
                stringBuilder.Append("0");
        }
    }
    
    sw.WriteLine(stringBuilder.ToString());
    sw.Flush();
}


sr.Close();
sw.Close();


void InitSegmentTree(int node, int start, int end)
{
    if (start == end)
    {
        var num = GetNum(nums[start]);
        segmentTree[node] = num;
        return;
    }

    var mid = (start + end) / 2;
    InitSegmentTree(node * 2, start, mid);
    InitSegmentTree(node * 2 + 1, mid + 1, end);
    segmentTree[node] = Calculate(segmentTree[node * 2], segmentTree[node * 2 + 1]);
}


int GetNum(int num)
{
    if (num > 0)
        return 1;
    else if (num < 0)
        return -1;
    else
        return 0;
}

int Calculate(int left, int right)
{
    return left * right;
}

int Query(int node, int start, int end, int left, int right)
{
    if (left > end || right < start)
        return 1;

    if (left <= start && end <= right)
    {
        return segmentTree[node];
    }

    var mid = (start + end) / 2;
    var leftNode = Query(node * 2, start, mid, left, right);
    var rightNode = Query(node * 2 + 1, mid + 1, end, left, right);
    return Calculate(leftNode, rightNode);
}

void Change(int node, int start, int end, int index, int num)
{
    if (index < start || index > end)
        return;

    if (start == end)
    {
        segmentTree[node] = GetNum(num);
        return;
    }

    var mid = (start + end) / 2;
    Change(node * 2, start, mid, index, num);
    Change(node * 2 + 1, mid + 1, end, index, num);
    segmentTree[node] = Calculate(segmentTree[node * 2], segmentTree[node * 2 + 1]);
}