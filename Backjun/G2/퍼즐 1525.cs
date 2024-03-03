var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var currentArray = 0;
var puzzleHash = new HashSet<int>();
var targetHash = 123456789;

for (var i = 0; i < 3; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < 3; j++)
    {
        if (input[j] == 0)
        {
            input[j] = 9;
        }
        currentArray = currentArray * 10 + input[j];
    }
}

var max = -1;

var q = new Queue<(int current, int depth)>();
q.Enqueue((currentArray, 0));
puzzleHash.Add(currentArray);
var dx = new int[] { 0, 0, 1, -1 };
var dy = new int[] { 1, -1, 0, 0 };

while (q.Count > 0)
{
    var (current, depth) = q.Dequeue();
    if (current == targetHash)
    {
        max = depth;
        break;
    }
    
    var zeroIndex = current.ToString().IndexOf('9');
    var cx = zeroIndex / 3;
    var cy = zeroIndex % 3;

    for (var d = 0; d < 4; d++)
    {
        var nx = cx + dx[d];
        var ny = cy + dy[d];
        if (nx < 0 || nx >= 3 || ny < 0 || ny >= 3)
        {
            continue;
        }
        
        var next = current.ToString().ToCharArray();
        (next[cx * 3 + cy], next[nx * 3 + ny]) = (next[nx * 3 + ny], next[cx * 3 + cy]);
        var nextInt = int.Parse(new string(next));
        if (puzzleHash.Add(nextInt) == false)
        {
            continue;
        }

        q.Enqueue((nextInt, depth + 1));
    }
}

sw.WriteLine(max);
sw.Close();
sr.Close();