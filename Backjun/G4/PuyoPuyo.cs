StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var board = new char[12, 6];

for (var y = 0; y < 12; y++)
{
    var inputs = sr.ReadLine();
    for (var x = 0; x < 6; x++)
    {
        board[y, x] = inputs[x];
    }
}

var total = 0;
while (true)
{
    var dx = new int[4] { 1, -1, 0, 0 };
    var dy = new int[4] { 0, 0, 1, -1 };
    var visited = new bool[12, 6];
    var count = 0;
    for (var y = 0; y < 12; y++)
    {
        for (var x = 0; x < 6; x++)
        {
            if (visited[y, x]) continue;
            if (board[y, x] == '.') continue;
            count += BFS(y, x);
        }
    }

    if (count == 0)
    {
        sw.WriteLine(total);
        break;
    }

    total++;
    Down();

    int BFS(int y, int x)
    {
        var deleteQueue = new Queue<(int y, int x)>();
        var q = new Queue<(int y, int x)>();
        q.Enqueue((y, x));
        deleteQueue.Enqueue((y, x));
        var deleteCount = 1;
        var c = board[y, x];
        visited[y, x] = true;
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var current_Y = current.y;
            var current_X = current.x;
            visited[current_Y, current_X] = true;
            for (var d = 0; d < 4; d++)
            {
                var nextY = current_Y + dy[d];
                var nextX = current_X + dx[d];
                if (nextY < 0 || nextY >= 12 || nextX < 0 || nextX >= 6) continue;
                if (visited[nextY, nextX]) continue;
                if (board[nextY, nextX] != c) continue;
                visited[nextY, nextX] = true;
                q.Enqueue((nextY, nextX));
                deleteQueue.Enqueue((nextY, nextX));
                deleteCount++;
            }
        }

        if (deleteCount < 4) return 0;
        while (deleteQueue.Count > 0)
        {
            var current = deleteQueue.Dequeue();
            board[current.y, current.x] = '.';
        }

        return 1;
    }

    void Down()
    {
        for (var x = 0; x < 6; x++)
        {
            Queue<char> q = new Queue<char>();
            for (var y = 11; y >= 0; y--)
            {
                if (board[y, x] == '.') continue;
                q.Enqueue(board[y, x]);
            }

            for (var y = 11; y >= 0; y--)
            {
                board[y, x] = q.Count > 0 ? q.Dequeue() : '.';
            }
        }
    }
}

sr.Close();
sw.Close();