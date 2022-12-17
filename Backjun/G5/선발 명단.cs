var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var board = new int[11, 11];
    for (var i = 0; i < 11; i++)
    {
        var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (var j = 0; j < 11; j++)
        {
            board[i, j] = input[j];
        }
    }

    var visited = new bool[11];
    var max = 0;

    DFS(0, 0);

    sw.WriteLine(max);

    void DFS(int current, int result)
    {
        if (current == 11)
        {
            max = Math.Max(max, result);
            return;
        }

        for (var v = 0; v < 11; v++)
        {
            if (visited[v]) continue;
            if (board[current, v] == 0) continue;

            visited[v] = true;
            DFS(current + 1, result + board[current, v]);
            visited[v] = false;
        }
    }
}

sr.Close();
sw.Close();