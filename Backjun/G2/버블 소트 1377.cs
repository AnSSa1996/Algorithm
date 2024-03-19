var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());
var nums = new List<(int num, int order)>();

for (var i = 0; i < N; i++)
{
    var num = int.Parse(sr.ReadLine());
    nums.Add((num, i));
}

var sortedNum = nums.OrderBy(x => x.num).ToList();

var result = new List<int>();

for (var i = 0; i < N; i++)
{
    var order = sortedNum[i].order - i;
    result.Add(order);
}

var max = result.Max();
sw.WriteLine(max + 1);
sw.Close();
sr.Close();