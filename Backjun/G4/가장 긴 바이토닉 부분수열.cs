using Microsoft.VisualBasic;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var increaseDp = new int[N];
var decreaseDp = new int[N];
var dp = new int[N];

for (var i = 0; i < N; i++)
{
    var increaseMax = 1;
    for (var j = 0; j < i; j++)
    {
        if (nums[j] < nums[i])
            increaseMax = Math.Max(increaseMax, increaseDp[j] + 1);
    }

    increaseDp[i] = increaseMax;
}

for (var i = N - 1; i >= 0; i--)
{
    var decreaseMax = 1;
    for (var j = N - 1; j > i; j--)
    {
        if (nums[j] < nums[i])
            decreaseMax = Math.Max(decreaseMax, decreaseDp[j] + 1);
    }

    decreaseDp[i] = decreaseMax;
}

for (var i = 0; i < N; i++)
{
    dp[i] = increaseDp[i] + decreaseDp[i] - 1;
}

sw.WriteLine(dp.Max());

sw.Flush();
sr.Close();
sw.Close();