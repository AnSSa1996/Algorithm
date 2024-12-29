var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var X = long.Parse(sr.ReadLine());
var N = int.Parse(sr.ReadLine());

var result = 0L;

for(var n = 0; n < N; n++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var value = inputs[0];
    var count = inputs[1];
    result += value * count;
}

sw.WriteLine(X == result ? "Yes" : "No");

sr.Close();
sw.Close();
