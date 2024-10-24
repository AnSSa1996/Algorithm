var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y, X];
var redPos = new Position(0, 0);
var bluePos = new Position(0, 0);
var holePos = new Position(0, 0);

for (var y = 0; y < Y; y++)
{
    var input = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = input[x];

        if (input[x] == 'R')
        {
            redPos = new Position(y, x);
        }

        if (input[x] == 'B')
        {
            bluePos = new Position(y, x);
        }

        if (input[x] == 'O')
        {
            holePos = new Position(y, x);
        }
    }
}

var result = 0;
var queue = new Queue<(Position red, Position blue, int count)>();
queue.Enqueue((redPos, bluePos, 0));
var visited = new bool[Y, X, Y, X];

var dy = new int[] { -1, 1, 0, 0 };
var dx = new int[] { 0, 0, -1, 1 };

while (queue.Count > 0)
{
    var (red, blue, count) = queue.Dequeue();
    if (count > 10)
    {
        break;
    }

    if (red.y == holePos.y && red.x == holePos.x)
    {
        result = 1;
        break;
    }

    for (var i = 0; i < 4; i++)
    {
        var nextRed = new Position(red.y, red.x);
        var nextBlue = new Position(blue.y, blue.x);
        var redMoveCount = 0;
        var blueMoveCount = 0;

        while (board[nextRed.y + dy[i], nextRed.x + dx[i]] != '#' && board[nextRed.y, nextRed.x] != 'O')
        {
            nextRed.y += dy[i];
            nextRed.x += dx[i];
            redMoveCount++;
        }

        while (board[nextBlue.y + dy[i], nextBlue.x + dx[i]] != '#' && board[nextBlue.y, nextBlue.x] != 'O')
        {
            nextBlue.y += dy[i];
            nextBlue.x += dx[i];
            blueMoveCount++;
        }

        if (nextBlue.y == holePos.y && nextBlue.x == holePos.x)
        {
            continue;
        }

        if (nextRed.y == nextBlue.y && nextRed.x == nextBlue.x)
        {
            if (redMoveCount > blueMoveCount)
            {
                nextRed.y -= dy[i];
                nextRed.x -= dx[i];
            }
            else
            {
                nextBlue.y -= dy[i];
                nextBlue.x -= dx[i];
            }
        }

        if (visited[nextRed.y, nextRed.x, nextBlue.y, nextBlue.x])
        {
            continue;
        }

        visited[nextRed.y, nextRed.x, nextBlue.y, nextBlue.x] = true;
        queue.Enqueue((nextRed, nextBlue, count + 1));
    }
}

sw.WriteLine(result);
sr.Close();
sw.Close();

public class Position
{
    public int y;
    public int x;

    public Position(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}