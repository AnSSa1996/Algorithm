using System.Numerics;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    sr.ReadLine();
    var N = long.Parse(sr.ReadLine());
    var sum = BigInteger.Zero;

    for (var i = 0; i < N; i++)
    {
        sum += BigInteger.Parse(sr.ReadLine());
    }

    var remainder = sum % N;
    sw.WriteLine(remainder == 0 ? "YES" : "NO");
}

sr.Close();
sw.Close();