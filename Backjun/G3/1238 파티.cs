var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var INF = 1000000000;
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var X = inputs[2];

var board = new int[N + 1, N + 1];
for (var i = 1; i <= N; i++)
{
    for (var j = 1; j <= N; j++)
    {
        board[i, j] = (i == j) ? 0 : INF;
    }
}

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var cost = inputs[2];
    board[left, right] = cost;
}

for(var k = 1; k <= N; k++)
{
    for(var i = 1; i <= N; i++)
    {
        for(var j = 1; j <= N; j++)
        {
            if (board[i, k] != INF && board[k, j] != INF && board[i, j] > board[i, k] + board[k, j])
            {
                board[i, j] = board[i, k] + board[k, j];
            }
        }
    }
}

var max = 0;
for(var i = 1; i <= N; i++)
{
    if (i == X) continue;
    if (board[i, X] == INF || board[X, i] == INF) continue;
    var cost = board[i, X] + board[X, i];
    if (max < cost) max = cost;
}

sw.WriteLine(max);

sr.Close();
sw.Close();