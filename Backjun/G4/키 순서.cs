StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var dp = new int[N + 1, N + 1];

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    dp[left, right] = 1;
}


for (var pass = 1; pass <= N; pass++)
{
    for (var start = 1; start <= N; start++)
    {
        for (var end = 1; end <= N; end++)
        {
            if (dp[start, end] == 1) continue;
            if (dp[start, pass] == 0) continue;
            if (dp[pass, end] == 0) continue;
            dp[start, end] = 1;
        }
    }
}

var result = 0;

for (var i = 1; i <= N; i++)
{
    var count = 0;
    for (var j = 1; j <= N; j++)
    {
        count += dp[i, j] + dp[j, i];
    }

    if (count == N - 1) result++;
}

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();