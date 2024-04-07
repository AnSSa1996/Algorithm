using System.Text;

var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
long N = inputs[0];      // a의 갯수
long M = inputs[1];      // z의 갯수
long K = inputs[2];      // k번째 수

var dp = new long[N + 1, M + 1];

for(var i = 0; i <= N; i++)
{
    dp[i, 0] = 1;
}

for (var i = 0; i <= M; i++)
{
    dp[0, i] = 1;
}

for (var i = 1; i <= N; i++)
{
    for (var j = 1; j <= M; j++)
    {
        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
        dp[i, j] = Math.Min(dp[i, j], (long)1e18);
    }
}

var can = dp[N, M];
if (K > can)
{
    sw.WriteLine(-1);
    sw.Close();
    sr.Close();
    return;
}
var result = new StringBuilder();

while (N > 0 && M > 0)
{
    var order = dp[N - 1, M];
    
    if (K <= order)
    {
        result.Append('a');
        N--;
    }
    else
    {
        result.Append('z');
        M--;
        K -= order;
    }
}

while (N-- > 0)
{
    result.Append('a');
}

while (M-- > 0)
{
    result.Append('z');
}

sw.WriteLine(result);
sw.Close();
sr.Close();