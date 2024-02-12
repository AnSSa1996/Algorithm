using System.Text;

var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var n = inputs[0];      // 집하장의 개수
var m = inputs[1];      // 집하장 간의 경로의 개수

var map = new int[n + 1, n + 1];
var resultMap = new int[n + 1, n + 1];

for (var i = 1; i <= n; i++)
{
    for (var j = 1; j <= n; j++)
    {
        if (i == j)
        {
            map[i, j] = 0;
        }
        else
        {
            map[i, j] = 1000000000;
        }
    }
}

for (var i = 0; i < m; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];
    map[a, b] = c;
    map[b, a] = c;
    
    resultMap[a, b] = b;
    resultMap[b, a] = a;
}

for (var k = 1; k <= n; k++)
{
    for (var i = 1; i <= n; i++)
    {
        for (var j = 1; j <= n; j++)
        {
            if (map[i, j] > map[i, k] + map[k, j])
            {
                map[i, j] = map[i, k] + map[k, j];
                resultMap[i, j] = resultMap[i, k];
            }
        }
    }
}

var sb = new StringBuilder();
for (var i = 1; i <= n; i++)
{
    for (var j = 1; j <= n; j++)
    {
        if (i == j)
        {
            sb.Append("- ");
            continue;
        }
        sb.Append(resultMap[i, j] + " ");
    }
    sb.AppendLine();
}

sw.Write(sb);
sw.Close();
sr.Close();