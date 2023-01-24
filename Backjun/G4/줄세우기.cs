StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var L = int.Parse(sr.ReadLine());
var nums = new List<int>();
for (var l = 0; l < L; l++)
{
    nums.Add(int.Parse(sr.ReadLine()));
}

var dp = new int[L];
for (var i = 0; i < L; i++)
{
    for (var j = 0; j < i; j++)
    {
        if (nums[i] > nums[j])
        {
            dp[i] = Math.Max(dp[i], dp[j]);
        }
    }

    dp[i] += 1;
}

sw.WriteLine(L - dp.Max());

sw.Flush();
sw.Close();
sr.Close();