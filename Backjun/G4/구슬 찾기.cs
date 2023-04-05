var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var board = new int[N + 1, N + 1];
var half = N / 2;

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];

    board[left, right] = 1;
}

for (var visited = 1; visited <= N; visited++)
{
    for (var left = 1; left <= N; left++)
    {
        for (var right = 1; right <= N; right++)
        {
            if (left == right) continue;
            if (board[left, visited] == 1 && board[visited, right] == 1) board[left, right] = 1;
        }
    }
}

var answer = 0;

for (var left = 1; left <= N; left++)
{
    var bigCount = 0;
    var smallCount = 0;
    for (var right = 1; right <= N; right++)
    {
        if (left == right) continue;
        else if (board[left, right] == 1) bigCount += 1;
        else if (board[right, left] == 1) smallCount += 1;
    }

    if (bigCount > half || smallCount > half) answer++;
}

sw.WriteLine(answer);

sw.Flush();
sw.Close();
sr.Close();