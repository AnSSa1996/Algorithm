using System.ComponentModel;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var n = int.Parse(sr.ReadLine());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var a = inputs[0];
var b = inputs[1];
var m = int.Parse(sr.ReadLine());
var dp = new int[n + 1, n + 1, n + 1];

var lst = new List<int>();
for (int i = 0; i < m; i++)
{
    lst.Add(int.Parse(sr.ReadLine()));
}

int Go(int x, int door1, int door2)
{
    if (x == m) return 0;

    var val = lst[x];
    dp[val, door1, door2] = Math.Min(Math.Abs(val - door1) + Go(x + 1, val, door2),
        Math.Abs(val - door2) + Go(x + 1, door1, val));
    return dp[val, door1, door2];
}

sw.WriteLine(Go(0, a, b));

sw.Flush();
sw.Close();
sr.Close();