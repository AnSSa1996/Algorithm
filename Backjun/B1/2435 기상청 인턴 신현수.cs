var inputs = Console.ReadLine().Split();
var n = int.Parse(inputs[0]);
var k = int.Parse(inputs[1]);

var input = Console.ReadLine().Split();

var temperature = new int[n + 1];
temperature[0] = 0;
for (var i = 1; i <= n; i++)
{
    temperature[i] = int.Parse(input[i - 1]);
}

var max = int.MinValue;
for (var i = k; i <= n; i++)
{
    var tem = 0;
    for (var j = i - k + 1; j <= i; j++)
    {
        tem += temperature[j];
    }
    
    max = Math.Max(max, tem);
}
Console.WriteLine(max);