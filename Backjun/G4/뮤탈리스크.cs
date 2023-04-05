var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);


var A = 0;
var B = 0;
var C = 0;
for (var i = 0; i < N; i++)
{
    if (i == 0) A = inputs[0];
    if (i == 1) B = inputs[1];
    if (i == 2) C = inputs[2];
}

var dp = new int[61, 61, 61];
var board = new int[6, 3] { { 1, 3, 9 }, { 1, 9, 3 }, { 3, 1, 9 }, { 3, 9, 1 }, { 9, 3, 1 }, { 9, 1, 3 } };
var result = int.MaxValue;

void DFS(int a, int b, int c, int depth)
{
    if (a >= A && b >= B && c >= C)
    {
        result = Math.Min(result, depth);
    }

    for (var i = 0; i < 6; i++)
    {
        var nextA = a + board[i, 0];
        var nextB = b + board[i, 1];
        var nextC = c + board[i, 2];

        if (nextA >= 60) nextA = 60;
        if (nextB >= 60) nextB = 60;
        if (nextC >= 60) nextC = 60;
        if (dp[nextA, nextB, nextC] == 0) dp[nextA, nextB, nextC] = 10000;
        if (dp[nextA, nextB, nextC] <= depth + 1) continue;
        dp[nextA, nextB, nextC] = depth + 1;
        DFS(nextA, nextB, nextC, depth + 1);
    }
}

DFS(0, 0, 0, 0);

sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();