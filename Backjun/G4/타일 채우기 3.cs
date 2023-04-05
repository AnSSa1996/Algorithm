using System.Numerics;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = long.Parse(sr.ReadLine());
long[,] dp = new long[N + 2, 2];
dp[0, 0] = 0;
dp[1, 0] = 2;
dp[2, 0] = 7;
dp[2, 1] = 1;
for (int i = 3; i <= N; i++)
{
    dp[i, 1] = (dp[i - 3, 0] + dp[i - 1, 1]) % 1000000007;
    dp[i, 0] = (2 * dp[i, 1] + 2 * dp[i - 1, 0] + 3 * dp[i - 2, 0]) % 1000000007;
}

sw.WriteLine(dp[N, 0]);

sr.Close();
sw.Close();