var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var increaseDp = new int[N];

for (var i = 0; i < N; i++)
{
    for (var j = 0; j < i; j++)
    {
        if (nums[j] < nums[i] && increaseDp[j] > increaseDp[i])
        {
            increaseDp[i] = increaseDp[j];
        }
    }

    increaseDp[i]++;
}

var max = increaseDp.Max();
sw.WriteLine(max);
var result = new List<int>();
for (var index = increaseDp.Length - 1; index >= 0; index--)
{
    if (increaseDp[index] != max) continue;
    result.Add(nums[index]);
    max--;
}

result.Reverse();

sw.WriteLine(string.Join(' ', result));

sw.Close();
sr.Close();