var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

ulong mod = 1000000007L;

List<List<ulong>> MultiplyMatrix(List<List<ulong>> a, List<List<ulong>> b)
{
    var n = a.Count;
    var c = new List<List<ulong>>(n);
    for (var i = 0; i < n; i++)
    {
        c.Add(new List<ulong>(new ulong[n]));
        for (var j = 0; j < n; j++)
        {
            for (var k = 0; k < n; k++)
            {
                c[i][j] += a[i][k] * b[k][j];
                c[i][j] %= mod;
            }
        }
    }

    return c;
}

ulong n = ulong.Parse(sr.ReadLine());
if (n <= 1)
{
    Console.WriteLine(n);
    return;
}

var ans = new List<List<ulong>>
{
    new List<ulong> {1, 0},
    new List<ulong> {0, 1}
};

var a = new List<List<ulong>>
{
    new List<ulong> {1, 1},
    new List<ulong> {1, 0}
};

while (n > 0)
{
    if (n % 2 == 1)
    {
        ans = MultiplyMatrix(ans, a);
    }

    a = MultiplyMatrix(a, a);
    n /= 2;
}

sw.WriteLine(ans[0][1]);
sw.Close();
sr.Close();