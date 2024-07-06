var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());


var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var lst = new List<int>();

for (var i = 0; i < N; i++)
{
    if (lst.Count == 0 || lst[^1] < nums[i])
    {
        lst.Add(nums[i]);
    }
    else
    {
        var idx = lst.BinarySearch(nums[i]);
        if (idx < 0)
        {
            idx = ~idx;
        }
        lst[idx] = nums[i];
    }
}

var cut = N - lst.Count;
sw.WriteLine(cut);

sw.Flush();
sw.Close();
sr.Close();