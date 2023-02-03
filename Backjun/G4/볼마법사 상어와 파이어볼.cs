using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var K = inputs[2];

var dy = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };
var dx = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };

var nextFireBall = new List<FireBall>();
for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var r = inputs[0];
    var c = inputs[1];
    var m = inputs[2];
    var s = inputs[3];
    var d = inputs[4];

    var fireBall = new FireBall(r, c, m, d, s);
    nextFireBall.Add(fireBall);
}

var board = new FireBall[N + 1, N + 1];
for (var k = 0; k < K; k++)
{
    board = new FireBall[N + 1, N + 1];
    var q = new Queue<FireBall>(nextFireBall);
    nextFireBall.Clear();

    // 이동
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var r = current.R;
        var c = current.C;
        var m = current.M;
        var s = current.S;
        var d = current.D;

        var nextY = (r + dy[d] * s) % N;
        if (nextY < 0) nextY = N + nextY;
        var nextX = (c + dx[d] * s) % N;
        if (nextX < 0) nextX = N + nextX;
        current.R = nextY;
        current.C = nextX;


        if (board[nextY, nextX] == null)
        {
            board[nextY, nextX] = current;
            continue;
        }

        board[nextY, nextX].M += m;
        board[nextY, nextX].S += s;
        board[nextY, nextX].Count += 1;
        board[nextY, nextX].direction.Add(d);
    }

    // 나누기
    for (var y = 0; y <= N; y++)
    {
        for (var x = 0; x <= N; x++)
        {
            if (board[y, x] == null) continue;
            if (board[y, x].Count == 1)
            {
                nextFireBall.Add(board[y, x]);
                continue;
            }

            var L = board[y, x].M / 5;
            if (L == 0) continue;
            var S = board[y, x].S / board[y, x].Count;

            var EvenCount = board[y, x].direction.Count(x => x % 2 == 0);
            var OddCount = board[y, x].direction.Count(x => x % 2 == 1);
            if (EvenCount == board[y, x].Count || OddCount == board[y, x].Count)
            {
                for (var d = 0; d <= 6; d += 2)
                {
                    var newFireBall = new FireBall(y, x, L, d, S);
                    nextFireBall.Add(newFireBall);
                }
            }
            else
            {
                for (var d = 1; d <= 7; d += 2)
                {
                    var newFireBall = new FireBall(y, x, L, d, S);
                    nextFireBall.Add(newFireBall);
                }
            }
        }
    }

    if (k == K - 1)
    {
        var result = 0;
        foreach (var fireBall in nextFireBall)
        {
            result += fireBall.M;
        }

        sw.WriteLine(result);
    }
}


sw.Flush();
sw.Close();
sr.Close();

public class FireBall
{
    public int R = 0;
    public int C = 0;
    public int M = 0;
    public int D = 0;
    public int S = 0;
    public int Count = 1;

    public List<int> direction = new List<int>();

    public FireBall(int r, int c, int m, int d, int s, int count = 1)
    {
        R = r;
        C = c;
        M = m;
        D = d;
        S = s;
        Count = count;

        direction.Add(D);
    }
}