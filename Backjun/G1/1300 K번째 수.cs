var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var k = int.Parse(sr.ReadLine());

var left = 1;
var right = k;

while (left <= right)
{
    var mid = (left + right) / 2;
    var cnt = 0;
    for (var i = 1; i <= N; i++)
    {
        cnt += Math.Min(mid / i, N);
    }

    if (cnt < k)
    {
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

sw.WriteLine(left);

sr.Close();
sw.Close();