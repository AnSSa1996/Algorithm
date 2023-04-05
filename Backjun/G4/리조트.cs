var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var INF = 1000000000;
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var day = inputs[0];
var holiday = inputs[1];
int[] holidays = new int[] { };
if (holiday > 0)
{
    holidays = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
}


var dp = new int[110, 50];
for (var i = 0; i < 110; i++)
{
    for (var j = 0; j < 50; j++)
    {
        dp[i, j] = INF;
    }
}

dp[0, 0] = 0;
for (var d = 0; d < day + 1; d++)
{
    for (var c = 0; c <= 40; c++)
    {
        if (dp[d, c] == INF) continue;
        var current = dp[d, c];
        var nextDay = d + 1;

        // 현재 휴일이라 넘어가도 될 때,
        if (holidays.Contains(nextDay))
        {
            dp[nextDay, c] = Math.Min(current, dp[nextDay, c]);
        }

        // 현재 쿠폰이 3장 이상 있을 때,
        if (c >= 3)
        {
            dp[nextDay, c - 3] = Math.Min(current, dp[nextDay, c - 3]);
        }

        // 1일권
        dp[nextDay, c] = Math.Min(current + 10000, dp[nextDay, c]);

        // 3일권
        for (var i = 1; i <= 3; i++)
        {
            dp[d + i, c + 1] = Math.Min(current + 25000, dp[d + i, c + 1]);
        }

        // 5일권
        for (var i = 1; i <= 5; i++)
        {
            dp[d + i, c + 2] = Math.Min(current + 37000, dp[d + i, c + 2]);
        }
    }
}

var result = INF;
for (var c = 0; c < 50; c++)
{
    result = Math.Min(result, dp[day, c]);
}
sw.WriteLine(result);

sr.Close();
sw.Close();