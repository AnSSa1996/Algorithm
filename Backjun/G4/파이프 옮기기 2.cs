var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var board = new int[N, N];
for (var y = 0; y < N; y++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        board[y, x] = inputs[x];
    }
}

var dp = new long[N, N, 3];
dp[0, 1, 0] = 1;

for (var i = 2; i < N; i++)
{
    if (board[0, i] == 0) dp[0, i, 0] = dp[0, i - 1, 0];
}

for (var i = 1; i < N; i++)
{
    for (var j = 1; j < N; j++)
    {
        if (board[i, j] == 0)
        {
            dp[i, j, 0] = dp[i, j - 1, 0] + dp[i, j - 1, 1];
            dp[i, j, 2] = dp[i - 1, j, 2] + dp[i - 1, j, 1];
        }

        if (board[i, j] == 0 && board[i - 1, j] == 0 && board[i, j - 1] == 0)
        {
            dp[i, j, 1] = dp[i - 1, j - 1, 0] + dp[i - 1, j - 1, 1] + dp[i - 1, j - 1, 2];
        }
    }
}

long result = 0;
for (var i = 0; i < 3; i++) result += dp[N - 1, N - 1, i];

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();