var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var max = int.MinValue;
var Y = 0;
var X = 0;
for (var y = 0; y < 9; y++)
{
    var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < 9; x++)
    {
        var num = nums[x];
        if (num > max)
        {
            max = num;
            Y = y;
            X = x;
        }
    }
}

sw.WriteLine(max);
sw.WriteLine($"{Y + 1} {X + 1}");
sr.Close();
sw.Close();