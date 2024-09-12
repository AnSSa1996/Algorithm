var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var N = int.Parse(sr.ReadLine());
var board = new int[N, N];
var BishopSet = new HashSet<(int y, int x)>();
for (var y = 0; y < N; y++)
{
    var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        board[y, x] = line[x];
    }
}

var white = SetBishop(0, 0, 0);
var black = SetBishop(0, 1, 0);
sw.WriteLine(white + black);

sr.Close();
sw.Close();


int SetBishop(int y, int x, int count)
{
    // 가로로 끝까지 갔을 때
    if (x >= N)
    {
        return SetBishop(y + 1, (x + 1) % 2, count);
    }

    // 세로로 끝까지 갔을 때
    if (y >= N)
    {
        return count;
    }

    var max = count;

    // 비숍을 놓을 수 있는 경우
    if (board[y, x] == 1 && CheckBishop(y, x))
    {
        BishopSet.Add((y, x));
        max = Math.Max(max, SetBishop(y, x + 2, count + 1));
        BishopSet.Remove((y, x));
    }

    return Math.Max(max, SetBishop(y, x + 2, count));
}

bool CheckBishop(int y, int x)
{
    foreach (var bishopPair in BishopSet)
    {
        var (by, bx) = bishopPair;
        if (Math.Abs(by - y) == Math.Abs(bx - x))
        {
            return false;
        }
    }

    return true;
}