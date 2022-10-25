using System.Runtime.InteropServices;
using System.Xml.XPath;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
var K = int.Parse(sr.ReadLine());
var dp = new int[K + 1, T + 1];
dp[0, 0] = 1;

for (int i = 1; i <= K; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var cost = inputs[0];
    var count = inputs[1];

    for (int v = 0; v <= T; v++)
    {
        dp[i, v] = dp[i - 1, v];
        for (int c = 1; c <= count; c++)
        {
            if (v - cost * c >= 0)
                dp[i, v] += dp[i - 1, v - cost * c];
            else
                break;
        }
    }
}

sw.WriteLine(dp[K,T]);


sw.Flush();
sw.Close();
sr.Close();