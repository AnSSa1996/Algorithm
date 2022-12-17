StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var dp = new int[31];
dp[2] = 3;

for (int i = 4; i <= 31; i += 2)
{
    dp[i] = dp[2] * dp[i - 2];
    for (int j = 4; j <= i; j += 2)
        dp[i] += 2 * dp[i - j];
    dp[i] += 2;
}

sw.WriteLine(dp[N]);

sw.Close();
sr.Close();