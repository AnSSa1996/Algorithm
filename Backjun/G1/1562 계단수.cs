var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var mod = 1000000000;
var ALL = (1 << 10) - 1;
var dp = new int[N + 1, 10, 1024];
for (var i = 1; i < 10; i++)
{
    dp[1, i, 1 << i] = 1;
}

for (var i = 2; i <= N; i++)
{
    for (var last = 0; last < 10; last++)
    {
        for (var used = 0; used <= ALL; used++)
        {
            var nextUsed = used | (1 << last);
            if (last > 0)
            {
                dp[i, last, nextUsed] += dp[i - 1, last - 1, used];
            }
            
            if (last < 9)
            {
                dp[i, last, nextUsed] += dp[i - 1, last + 1, used];
            }
            
            dp[i, last, nextUsed] %= mod;
        }
    }
}

var result = 0;
for (var i = 0; i < 10; i++)
{
    result += dp[N, i, ALL];
    result %= mod;
}

sw.WriteLine(result);

sr.Close();
sw.Close();