var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var M = int.Parse(sr.ReadLine());

var board = new int[N, N];

for (var m = 0; m < M; m++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0] - 1;
    var right = inputs[1] - 1;
    board[left, right] = 1;
}

for (var v = 0; v < N; v++)
{
    for (var s = 0; s < N; s++)
    {
        for (var e = 0; e < N; e++)
        {
            if (s == e) continue;
            if (board[s, v] + board[v, e] == 2) board[s, e] = 1;
        }
    }
}

for (var start = 0; start < N; start++)
{
    var count = 0;
    for (var end = 0; end < N; end++)
    {
        if (start == end) continue;
        if (board[start, end] == 0 && board[end, start] == 0) count++;
    }

    sw.WriteLine(count);
}


sw.Flush();
sw.Close();
sr.Close();