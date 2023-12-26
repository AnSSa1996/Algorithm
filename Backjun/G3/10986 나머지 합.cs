var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), long.Parse);
var n = inputs[0];
var m = inputs[1];
var nums = Array.ConvertAll(sr.ReadLine().Split(' '), long.Parse);

var prefixSum = new long[n + 1];
var remainders = new long[m + 1];

for (var i = 1; i <= n; i++)
{
    prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
    prefixSum[i] %= m;
    var remainder = prefixSum[i] % m;
    remainders[remainder]++;
}

var result = remainders[0];

for (var i = 0; i < m; i++)
{
    if (remainders[i] > 1)
        result += (remainders[i] * (remainders[i] - 1)) / 2;
}

sw.WriteLine(result);
sr.Close();
sw.Close();