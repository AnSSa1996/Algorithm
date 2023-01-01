var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var length = nums.Length;
var dp = new int[N, N];
for (var i = 0; i < length; i++)
{
    for (var start = 0; start < length - i; start++)
    {
        var end = start + i;
        if (start == end)
            dp[start, end] = 1;
        else if (nums[start] == nums[end])
        {
            if (start + 1 == end) dp[start, end] = 1;
            if (dp[start + 1, end - 1] == 1) dp[start, end] = 1;
        }
    }
}

var M = int.Parse(sr.ReadLine());
for (var i = 0; i < M; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0] - 1;
    var right = inputs[1] - 1;
    sw.WriteLine(dp[left, right] == 1 ? 1 : 0);
}

sw.Close();
sr.Close();