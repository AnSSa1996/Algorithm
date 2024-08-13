var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var board = new int[N, N];
var max = 0;
for (var y = 0; y < N; y++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        board[y, x] = inputs[x];
        max = Math.Max(max, board[y, x]);
    }
}

var dirs = new[] { MoveUp, MoveDown, MoveLeft, MoveRight };

void DFS(int depth)
{
    if (depth == 5)
    {
        for (var y = 0; y < N; y++)
        {
            for (var x = 0; x < N; x++)
            {
                max = Math.Max(max, board[y, x]);
            }
        }
        return;
    }
    
    var temp = new int[N, N];
    Array.Copy(board, temp, N * N);
    for (var i = 0; i < 4; i++)
    {
        dirs[i](board);
        DFS(depth + 1);
        Array.Copy(temp, board, N * N);
    }
}

DFS(0);
sw.WriteLine(max);
sr.Close();
sw.Close();


void MoveDown(int[,] board)
{
    var combined = new bool[N, N];
    for (var y = 0; y < N; y++)
    {
        for (var x = N - 2; x >= 0; x--)
        {
            if (board[x, y] == 0) continue;
            var targetX = x;
            while (targetX < N - 1 && board[targetX + 1, y] == 0)
            {
                targetX++;
            }
            if (targetX < N - 1 && board[targetX + 1, y] == board[x, y] && !combined[targetX + 1, y])
            {
                board[targetX + 1, y] *= 2;
                board[x, y] = 0;
                combined[targetX + 1, y] = true;
            }
            else if (targetX != x)
            {
                board[targetX, y] = board[x, y];
                board[x, y] = 0;
            }
        }
    }
}

void MoveUp(int[,] board)
{
    var combined = new bool[N, N];
    for (var y = 0; y < N; y++)
    {
        for (var x = 1; x < N; x++)
        {
            if (board[x, y] == 0) continue;
            var targetX = x;
            while (targetX > 0 && board[targetX - 1, y] == 0)
            {
                targetX--;
            }
            if (targetX > 0 && board[targetX - 1, y] == board[x, y] && !combined[targetX - 1, y])
            {
                board[targetX - 1, y] *= 2;
                board[x, y] = 0;
                combined[targetX - 1, y] = true;
            }
            else if (targetX != x)
            {
                board[targetX, y] = board[x, y];
                board[x, y] = 0;
            }
        }
    }
}

void MoveRight(int[,] board)
{
    var combined = new bool[N, N];
    for (var y = 0; y < N; y++)
    {
        for (var x = N - 2; x >= 0; x--)
        {
            if (board[y, x] == 0) continue;
            var targetX = x;
            while (targetX < N - 1 && board[y, targetX + 1] == 0)
            {
                targetX++;
            }
            if (targetX < N - 1 && board[y, targetX + 1] == board[y, x] && !combined[y, targetX + 1])
            {
                board[y, targetX + 1] *= 2;
                board[y, x] = 0;
                combined[y, targetX + 1] = true;
            }
            else if (targetX != x)
            {
                board[y, targetX] = board[y, x];
                board[y, x] = 0;
            }
        }
    }
}

void MoveLeft(int[,] board)
{
    var combined = new bool[N, N];
    for (var y = 0; y < N; y++)
    {
        for (var x = 1; x < N; x++)
        {
            if (board[y, x] == 0) continue;
            var targetX = x;
            while (targetX > 0 && board[y, targetX - 1] == 0)
            {
                targetX--;
            }
            if (targetX > 0 && board[y, targetX - 1] == board[y, x] && !combined[y, targetX - 1])
            {
                board[y, targetX - 1] *= 2;
                board[y, x] = 0;
                combined[y, targetX - 1] = true;
            }
            else if (targetX != x)
            {
                board[y, targetX] = board[y, x];
                board[y, x] = 0;
            }
        }
    }
}