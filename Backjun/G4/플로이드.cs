using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;
using Microsoft.VisualBasic;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
StringBuilder sb = new StringBuilder();

var N = int.Parse(sr.ReadLine());
var board = new int[N + 1, N + 1];

var INF = 100000000;

for (var y = 1; y <= N; y++)
{
    for (var x = 1; x <= N; x++)
    {
        board[y, x] = INF;
    }
}

var M = int.Parse(sr.ReadLine());
for (var i = 0; i < M; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    var cost = inputs[2];
    if (board[start, end] > cost) board[start, end] = cost;
}


for (var visit = 1; visit <= N; visit++)
{
    for (var start = 1; start <= N; start++)
    {
        for (var end = 1; end <= N; end++)
        {
            if (start == end)
            {
                board[start, end] = 0;
                continue;
            }

            if (board[start, visit] + board[visit, end] < board[start, end])
                board[start, end] = board[start, visit] + board[visit, end];
        }
    }
}

for (var y = 1; y <= N; y++)
{
    for (var x = 1; x <= N; x++)
    {
        if (board[y, x] != INF) sb.Append($"{board[y, x]} ");
        else sb.Append($"0 ");
    }

    sb.AppendLine();
}

sb.Remove(sb.Length - 1, 1);
sw.Write(sb);

sw.Flush();
sr.Close();
sw.Close();