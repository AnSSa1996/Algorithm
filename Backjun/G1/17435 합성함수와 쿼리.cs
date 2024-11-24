var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var log = 18;
var M = long.Parse(sr.ReadLine());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

var f = new long[M + 1];
for (var i = 1; i <= M; i++)
{
    f[i] = inputs[i - 1];
}

var dp = new long[M + 1, log + 1];

for (var i = 0; i <= M; i++)
{
    dp[i, 0] = f[i];
}

for(var i = 1; i <= log; i++)
{
    for(var j = 1; j <= M; j++)
    {
        dp[j, i] = dp[dp[j, i - 1], i - 1];
    }
}

var Q = int.Parse(sr.ReadLine());

for(var q = 0; q < Q; q++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

    var n = inputs[0];
    var x = inputs[1];

    for(var i = 0; i <= log; i++)
    {
        if((n & (1 << i)) > 0)
        {
            x = dp[x, i];
        }
    }

    sw.WriteLine(x);
}


sr.Close();
sw.Close();