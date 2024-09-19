var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var T = int.Parse(sr.ReadLine());

for (var i = 0; i < T; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var Y = inputs[0];
    var X = inputs[1];

    var board = new char[Y + 2, X + 2];
    var visited = new bool[Y + 2, X + 2];
    var visitDocuments = new HashSet<(int y, int x)>();
    var key = new Dictionary<char, bool>();

    for (var y = 0; y < Y + 2; y++)
    {
        for (var x = 0; x < X + 2; x++)
        {
            board[y, x] = '.';
        }
    }

    for (var y = 1; y < Y + 1; y++)
    {
        var line = sr.ReadLine();
        for (var x = 1; x < X + 1; x++)
        {
            board[y, x] = line[x - 1];
        }
    }

    var keys = sr.ReadLine();
    foreach (var k in keys)
    {
        key[k] = true;
    }

    var result = 0;
    BFS(board, visited, visitDocuments, key, Y, X, ref result);
    sw.WriteLine(result);
}

sr.Close();
sw.Close();


void BFS(char[,] board, bool[,] visited, HashSet<(int y, int x)> visitDocuments, Dictionary<char, bool> key, int Y, int X, ref int result)
{
    var dy = new int[] { -1, 1, 0, 0 };
    var dx = new int[] { 0, 0, -1, 1 };
    var queue = new Queue<(int y, int x)>();
    queue.Enqueue((0, 0));
    visited[0, 0] = true;

    while (queue.Count > 0)
    {
        var (y, x) = queue.Dequeue();

        for (var d = 0; d < 4; d++)
        {
            var nextY = y + dy[d];
            var nextX = x + dx[d];

            if (nextY < 0 || nextY >= Y + 2 || nextX < 0 || nextX >= X + 2) continue;
            if (board[nextY, nextX] == '*') continue;

            if (board[nextY, nextX] >= 'A' && board[nextY, nextX] <= 'Z')
            {
                if (key.ContainsKey(char.ToLower(board[nextY, nextX])) == false)
                {
                    continue;
                }
            }

            if (board[nextY, nextX] >= 'a' && board[nextY, nextX] <= 'z')
            {
                if (key.ContainsKey(board[nextY, nextX]) == false)
                {
                    key[board[nextY, nextX]] = true;
                    visited = new bool[Y + 2, X + 2];
                }
            }

            if (board[nextY, nextX] == '$' && visitDocuments.Contains((nextY, nextX)) == false)
            {
                visitDocuments.Add((nextY, nextX));
                result++;
            }

            if (visited[nextY, nextX]) continue;
            visited[nextY, nextX] = true;
            queue.Enqueue((nextY, nextX));
        }
    }
}