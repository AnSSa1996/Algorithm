var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var C = inputs[1];

var weights = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

var left = weights.Take(N / 2).ToList();
var right = weights.Skip(N / 2).ToList();

var leftList = new List<long>();
var rightList = new List<long>();

GetSubSet(left, 0, left.Count, 0, ref leftList);
GetSubSet(right, 0, right.Count, 0, ref rightList);

leftList.Sort();
rightList.Sort();

var count = 0;
for (var leftIndex = 0; leftIndex < leftList.Count; leftIndex++)
{
    var target = C - leftList[leftIndex];
    var currentCount = UpperBound(rightList, target);
    count += currentCount;
}

sw.WriteLine(count);
sr.Close();
sw.Close();

void GetSubSet(List<long> list, int left, int right, long sum, ref List<long> result)
{
    if (left == right)
    {
        result.Add(sum);
        return;
    }

    GetSubSet(list, left + 1, right, sum + list[left], ref result); // 포함
    GetSubSet(list, left + 1, right, sum, ref result);                  // 미포함
}

int UpperBound(List<long> list, long key)
{
    var low = 0;
    var high = list.Count;
    while (low < high) {
        var mid = (low + high) / 2;
        if (list[mid] <= key) low = mid + 1;
        else high = mid;
    }
    return low;
}