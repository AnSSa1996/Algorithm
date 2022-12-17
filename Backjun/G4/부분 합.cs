StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var N = inputs[0];
var S = inputs[1];

var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var length = N + 1;
var start = 0;
var end = 1;

long sum = nums[0];
while (end <= N)
{
    if (sum < S)
    {
        if (end == N) break;
        sum += nums[end];
        end++;
    }
    else
    {
        sum -= nums[start];
        length = Math.Min(length, end - start);
        if (length == 1) break;
        start++;
    }
}

sw.WriteLine(length == N + 1 ? 0 : length);

sw.Close();
sr.Close();