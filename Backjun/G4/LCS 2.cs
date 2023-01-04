using System.Runtime.InteropServices.ComTypes;
using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var upStr = sr.ReadLine();
var downStr = sr.ReadLine();

var upCount = upStr.Length;
var downCount = downStr.Length;
var dp = new int[upCount + 1, downCount + 1];

for (var i = 1; i <= upCount; i++)
{
    for (var j = 1; j <= downCount; j++)
    {
        if (upStr[i - 1] == downStr[j - 1])
        {
            dp[i, j] = dp[i - 1, j - 1] + 1;
        }
        else
        {
            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
        }
    }
}

var answer = new StringBuilder();

var up = upCount;
var down = downCount;

while (up > 0 && down > 0)
{
    if (dp[up, down - 1] == dp[up, down])
    {
        down -= 1;
    }
    else if (dp[up - 1, down] == dp[up, down])
    {
        up -= 1;
    }
    else
    {
        answer.Append(upStr[up - 1]);
        up -= 1;
        down -= 1;
    }
}

var result = new string(answer.ToString().Reverse().ToArray());
sw.WriteLine(result.Length);
sw.WriteLine(result);

sw.Close();
sr.Close();