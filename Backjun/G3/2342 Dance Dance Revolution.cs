var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var DDR = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var length = DDR.Length;
var dp = new int[5, 5, length + 1];

var max = 100000000;

for (var i = 0; i < 5; i++)
{
    for (var j = 0; j < 5; j++)
    {
        for (var k = 0; k <= length; k++)
        {
            dp[i, j, k] = max;
        }
    }
}


dp[0, 0, 0] = 0;

for (var i = 0; i < length; i++)
{
    var num = DDR[i];
    if (num == 0) continue;
    for (var j = 0; j < 5; j++)
    {
        for (var k = 0; k < 5; k++)
        {
            if (j == num || k == num)
            {
                dp[j, k, i + 1] = Math.Min(dp[j, k, i + 1], dp[j, k, i] + 1);
            }
            else
            {
                var cost = GetCost(k, num);
                dp[j, num, i + 1] = Math.Min(dp[j, num, i + 1], dp[j, k, i] + cost);
                cost = GetCost(j, num);
                dp[num, k, i + 1] = Math.Min(dp[num, k, i + 1], dp[j, k, i] + cost);
            }
        }
    }
}

int GetCost(int a, int b)
{
    if (a == b)
    {
        return 1;
    }
    else if (a == 0)
    {
        return 2;
    }
    else if (Math.Abs(a - b) == 2)
    {
        return 4;
    }
    else
    {
        return 3;
    }
}

var answer = max;

for (var i = 0; i < 5; i++)
{
    for (var j = 0; j < 5; j++)
    {
        answer = Math.Min(answer, dp[i, j, length - 1]);
    }
}

sw.WriteLine(answer);
sw.Close();
sr.Close();