var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var n = int.Parse(sr.ReadLine());
var INF = 200000;
var balls = new List<(int Size, int Color, int Index)>();

for (int i = 0; i < n; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var color = inputs[0];
    var size = inputs[1];
    balls.Add((size, color, i));
}

// 공을 크기 순으로 정렬
balls.Sort();

var colorCount = new int[INF + 1];
var total = 0L;
var j = 0;
var ans = new long[n];

for (var i = 0; i < n; i++)
{
    while (j < n && balls[j].Size < balls[i].Size)
    {
        colorCount[balls[j].Color] += balls[j].Size;
        total += balls[j].Size;
        j++;
    }

    ans[balls[i].Index] = total - colorCount[balls[i].Color];
}

foreach (var result in ans)
{
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();