using System.Runtime.Intrinsics.Arm;
using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var board = new List<List<int>>();
for (var i = 0; i <= N; i++) board.Add(new List<int>());
for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];

    // 오른쪽의 부모가 왼쪽
    board[right].Add(left);
}

var dp = new int[N + 1];

var resultLst = new List<int>();
var max = 1;
for (var index = 1; index <= N; index++)
{
    max = 1;
    DFS(index, 1);
    dp[index] = max;
    resultLst.Add(max);
}

void DFS(int current, int depth)
{
    if (board[current].Count() == 0)
    {
        max = Math.Max(max, depth);
        return;
    }

    foreach (var next in board[current])
    {
        if (dp[next] != 0)
        {
            max = Math.Max(max, depth + dp[next]);
            continue;
        }

        DFS(next, depth + 1);
    }
}

sw.WriteLine(string.Join(" ", resultLst));

sr.Close();
sw.Close();