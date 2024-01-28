var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());
var TrainPassengerArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var prefixSum = new int[N + 1];
prefixSum[0] = 0;
for (var i = 1; i <= N; i++)
{
    prefixSum[i] = TrainPassengerArray[i - 1];
    prefixSum[i] += prefixSum[i - 1];
}
var MaxTrain = int.Parse(sr.ReadLine());
var dp = new int[4, N + 1];


for (var i = 1; i <= 3; i++)
{
    for (var j = i * MaxTrain; j <= N; j++)
    {
        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j - MaxTrain] + prefixSum[j] - prefixSum[j - MaxTrain]);
    }
}

sw.WriteLine(dp[3, N]);
sw.Close();
sr.Close();