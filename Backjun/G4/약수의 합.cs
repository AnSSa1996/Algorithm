var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var M = 1000000;
var dp = new long[M + 1];

for (var i = 1; i <= M; i++)
{
    var j = 1;
    while (i * j <= M)
    {
        dp[i * j] += i;
        j += 1;
    }
}

for (var i = 1; i <= M; i++)
{
    dp[i] += dp[i - 1];
}

for (var n = 0; n < N; n++)
{
    var input = int.Parse(sr.ReadLine());
    sw.WriteLine(dp[input]);
}

sw.Flush();
sw.Close();
sr.Close();