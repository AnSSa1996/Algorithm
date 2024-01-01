var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

var N = inputs[0];          // 앱의 개수
var M = inputs[1];          // 필요한 메모리

var memory = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var cost = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

var sum = cost.Sum();

var dp = new int[N + 1, sum + 1];
var minCost = int.MaxValue;

for (var i = 1; i <= N; i++)
{
    for (var j = 0; j <= sum; j++)
    {
        var currentMemory = memory[i - 1]; 
        var currentCost = cost[i - 1];

        if (j < currentCost)
        {
            dp[i, j] = dp[i - 1, j];
        }
        else
        {
            dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - currentCost] + currentMemory);
        }

        if (dp[i, j] >= M)
        {
            minCost = Math.Min(minCost, j);
        }
    }
}

sw.WriteLine(minCost);
sr.Close();
sw.Close();