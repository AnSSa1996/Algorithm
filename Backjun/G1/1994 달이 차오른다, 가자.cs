var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var board = new char[Y, X];
var curY = 0;
var curX = 0;
for (var y = 0; y < Y; y++)
{
    var str = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = str[x];
        if (board[y, x] == '0')
        {
            curY = y;
            curX = x;
        }
    }
}

var keyDict = new Dictionary<char, int>();
var doorDict = new Dictionary<char, int>();

for (var index = 0; index < 6; index++)
{
    keyDict.Add((char)('a' + index), 1 << index);
    doorDict.Add((char)('A' + index), 1 << index);
}

var dy = new int[] { 0, 0, 1, -1 };
var dx = new int[] { 1, -1, 0, 0 };

var queue = new Queue<(int y, int x, int key, int count)>();
var visited = new bool[Y, X, 1 << 6];
var currentKey = 0;
if (board[curY, curX] >= 'a' && board[curY, curX] <= 'f')
{
    currentKey |= keyDict[board[curY, curX]];
}

queue.Enqueue((curY, curX, currentKey, 0));
visited[curY, curX, currentKey] = true;
var result = -1;
while (queue.Count > 0)
{
    var (y, x, key, count) = queue.Dequeue();
    if (board[y, x] == '1')
    {
        result = count;
        break;
    }

    for (var d = 0; d < 4; d++)
    {
        var nextY = y + dy[d];
        var nextX = x + dx[d];
        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X)
        {
            continue;
        }

        if (board[nextY, nextX] == '#')
        {
            continue;
        }
        
        if (visited[nextY, nextX, key])
        {
            continue;
        }
        
        var nextKey = key;
        var nextCount = count;
        
        if (board[nextY, nextX] >= 'A' && board[nextY, nextX] <= 'F')
        {
            if ((key & doorDict[board[nextY, nextX]]) == 0)
            {
                continue;
            }
        }
        
        if (board[nextY, nextX] >= 'a' && board[nextY, nextX] <= 'f')
        {
            nextKey |= keyDict[board[nextY, nextX]];
        }
        
        visited[nextY, nextX, nextKey] = true;
        queue.Enqueue((nextY, nextX, nextKey, nextCount + 1));
    }
}

sw.WriteLine(result);

sr.Close();
sw.Close();