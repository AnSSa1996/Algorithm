var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new int[Y, X];
var dp = new int[Y, X];
for (var y = 0; y < Y; y++)
{
    var str = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = str[x] - '0';
    }
}

var max = 0;
for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        if (y == 0 || x == 0)
        {
            dp[y, x] = board[y, x];
        }
        else if (board[y, x] == 0)
        {
            dp[y, x] = 0;
        }
        else
        {
            dp[y, x] = Math.Min(dp[y - 1, x], Math.Min(dp[y, x - 1], dp[y - 1, x - 1])) + 1;
        }

        max = Math.Max(dp[y, x], max);
    }
}

sw.WriteLine(max * max);

sw.Close();
sr.Close();