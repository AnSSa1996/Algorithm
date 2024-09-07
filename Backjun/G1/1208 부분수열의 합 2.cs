var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());


var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var N = inputs[0];
var SUM = inputs[1];

var nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

var mid = N / 2;
var leftNums = new long[mid];
var rightNums = new long[N - mid];

for (var i = 0; i < mid; i++)
{
    leftNums[i] = nums[i];
}

for (var i = mid; i < N; i++)
{
    rightNums[i - mid] = nums[i];
}

var leftSumDict = new Dictionary<long, long>();
var rightSumDict = new Dictionary<long, long>();

GetSum(leftNums, leftSumDict);
GetSum(rightNums, rightSumDict);
long result = 0;
foreach (var leftSum in leftSumDict)
{
    var diff = SUM - leftSum.Key;
    if (rightSumDict.ContainsKey(diff))
    {
        result += leftSum.Value * rightSumDict[diff];
    }
}

if (SUM == 0)
{
    result--;
}

sw.WriteLine(result);
sr.Close();
sw.Close();

void GetSum(long[] nums, Dictionary<long, long> sumDict)
{
    var length = nums.Length;
    for (var i = 0; i < (1 << length); i++)
    {
        long sum = 0;
        for (var j = 0; j < length; j++)
        {
            if ((i & (1 << j)) != 0)
            {
                sum += nums[j];
            }
        }

        if (sumDict.ContainsKey(sum))
        {
            sumDict[sum]++;
        }
        else
        {
            sumDict[sum] = 1;
        }
    }
}