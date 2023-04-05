var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var ans = sr.ReadLine();
var upStr = sr.ReadLine();
var downStr = sr.ReadLine();

var dp = new int[upStr.Length, ans.Length, 2];

for (var i = 0; i < upStr.Length; i++)
{
    if (upStr[i] == ans[0])
        dp[i, 0, 0] = 1;
    if (downStr[i] == ans[0])
        dp[i, 0, 1] = 1;
}

for (var i = 0; i < upStr.Length; i++)
{
    for (var j = 1; j < ans.Length; j++)
    {
        if (upStr[i] == ans[j])
        {
            for (var s = 0; s < i; s++) dp[i, j, 0] += dp[s, j - 1, 1];
        }

        if (downStr[i] == ans[j])
        {
            for (var s = 0; s < i; s++) dp[i, j, 1] += dp[s, j - 1, 0];
        }
    }
}

var result = 0;

for (var i = 0; i < upStr.Length; i++)
{
    result += dp[i, ans.Length - 1, 0] + dp[i, ans.Length - 1, 1];
}

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();