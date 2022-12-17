var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var dp = new int[N + 1];
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

for (var i = 0; i < N; i++)
{
    for (var j = 0; j <= i; j++)
    {
        if (j == 0) dp[i] = Math.Max(dp[i], Math.Abs(nums[i] - nums[j]));
        else dp[i] = Math.Max(dp[i], dp[j - 1] + Math.Abs(nums[i] - nums[j]));
    }
}

sw.WriteLine(dp.Max());

sw.Flush();
sw.Close();
sr.Close();