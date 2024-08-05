var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var positionArray = new int[N + 1];
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

for (var i = 0; i < N; i++)
{
    positionArray[nums[i]] = i + 1;
}

var max = 1;
var current = 1;

for(var i = 2; i <= N; i++)
{
    if(positionArray[i - 1] < positionArray[i])
    {
        current++;
    }
    else
    {
        current = 1;
    }
    max = Math.Max(max, current);
}

sw.WriteLine(N - max);
sw.Flush();
sw.Close();