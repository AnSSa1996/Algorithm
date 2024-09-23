var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = long.Parse(sr.ReadLine());
var result = EulerPie(N);
sw.WriteLine(result);

sr.Close();
sw.Close();

long EulerPie(long n)
{
    var result = n;
    for (long i = 2; i * i <= n; i++)
    {
        if (n % i == 0)
        {
            result -= result / i;
            while (n % i == 0)
            {
                n /= i;
            }
        }
    }

    if (n > 1)
    {
        result -= result / n;
    }

    return result;
}