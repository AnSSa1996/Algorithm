var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var n = inputs[0];      // 사건의 개수
var k = inputs[1];      // 사건의 전후 관계의 개수

var graph = new int[n + 1, n + 1];

for(var i = 0; i < k; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    graph[a, b] = -1;
    graph[b, a] = 1;
}

for (var pass = 1; pass <= n; pass++)
{
    for(var start = 1; start <= n; start++)
    {
        for(var end = 1; end <= n; end++)
        {
            if (graph[start, end] == 0)
            {
                if (graph[start, pass] == 1 && graph[pass, end] == 1)
                    graph[start, end] = 1;
                if (graph[start, pass] == -1 && graph[pass, end] == -1)
                    graph[start, end] = -1;
            }
        }
    }
}

var s = int.Parse(sr.ReadLine());
for(var i = 0; i < s; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    sw.WriteLine(graph[a, b]);
}

sw.Close();
sr.Close();