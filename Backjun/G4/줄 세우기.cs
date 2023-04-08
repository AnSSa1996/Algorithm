var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var students = new int[N + 1];
var board = new List<List<int>>();
for (var i = 0; i <= N; i++)
{
    board.Add(new List<int>());
}

for (var i = 1; i <= N; i++)
{
    students[i] = 0;
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    board[a].Add(b);
    students[b]++;
}

var queue = new Queue<int>();
for (var i = 1; i <= N; i++)
{
    if (students[i] == 0) queue.Enqueue(i);
}

var result = new List<int>();

while (queue.Count > 0)
{
    var current = queue.Dequeue();
    result.Add(current);

    foreach (var next in board[current])
    {
        students[next]--;
        if (students[next] == 0) queue.Enqueue(next);
    }
}

sw.WriteLine(string.Join(' ', result));

sr.Close();
sw.Close();