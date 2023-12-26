var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var board = new int[N, M];
for (var i = 0; i < N; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < M; j++)
    {
        board[i, j] = input[j];
    }
}

var dx = new int[4] { 1, -1, 0, 0 };
var dy = new int[4] { 0, 0, 1, -1 };

var result = 0;
var dp = new int[N, M];
for (var i = 0; i < N; i++)
{
    for (var j = 0; j < M; j++)
    {
        dp[i, j] = -1;
    }
}

int DFS(int y, int x)
{
    if (y == N - 1 && x == M - 1) return 1;
    if (dp[y, x] != -1) return dp[y, x];

    var way = 0;
    for (var d = 0; d < 4; d++)
    {
        var nx = x + dx[d];
        var ny = y + dy[d];

        if (nx < 0 || nx >= M || ny < 0 || ny >= N) continue;
        var next = board[ny, nx];
        if (next >= board[y, x]) continue;
        way += DFS(ny, nx);
    }

    dp[y, x] = way;

    return dp[y, x];
}

sw.WriteLine(DFS(0, 0));

sr.Close();
sw.Close();