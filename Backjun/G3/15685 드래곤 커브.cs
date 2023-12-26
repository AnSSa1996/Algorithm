var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var board = new int[101, 101];

var dx = new int[4] { 1, 0, -1, 0 };
var dy = new int[4] { 0, -1, 0, 1 };

for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = inputs[0];
    var y = inputs[1];
    var d = inputs[2];
    var g = inputs[3];

    var curve = DragonCurve(d, g);
    board[x, y] = 1;
    foreach (var next in curve)
    {
        x += dx[next];
        y += dy[next];
        board[x, y] = 1;
    }
}

List<int> DragonCurve(int d, int G)
{
    var result = new List<int>();
    result.Add(d);
    while (G > 0)
    {
        var temp = result.ToList();
        temp.Reverse();
        result.AddRange(temp.Select(current => (current + 1) % 4));
        G--;
    }

    return result;
}

var count = 0;
for (var x = 0; x < 100; x++)
{
    for (var y = 0; y < 100; y++)
    {
        if (board[x, y] == 0) continue;
        if (board[x, y + 1] == 0) continue;
        if (board[x + 1, y] == 0) continue;
        if (board[x + 1, y + 1] == 0) continue;
        count++;
    }
}

sw.WriteLine(count);
sw.Close();
sr.Close();