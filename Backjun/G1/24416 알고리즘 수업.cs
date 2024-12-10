var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var recursiveCount = 0;
var n = int.Parse(sr.ReadLine());

// 재귀
Fibo(n);

// DP
var dpCount = 0;
var f = new int[n + 1];
f[0] = 0;
f[1] = 1;
f[2] = 1;
for(var i = 3; i <= n; i++)
{
    dpCount++;
    f[i] = f[i - 1] + f[i - 2];
}

sw.WriteLine($"{recursiveCount} {dpCount}");


sr.Close();
sw.Close();

int Fibo(int n)
{
    if (n == 1 || n == 2)
    {
        recursiveCount++;
        return 1;
    }
    else
    {
        return Fibo(n - 1) + Fibo(n - 2);
    }
}