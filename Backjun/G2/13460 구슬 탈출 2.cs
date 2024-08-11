var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y, X];
var redBeadY = 0;
var redBeadX = 0;
var blueBeadY = 0;
var blueBeadX = 0;
for (var y = 0; y < Y; y++)
{
    var line = sr.ReadLine();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = '.';

        if (line[x] == 'R')
        {
            redBeadY = y;
            redBeadX = x;
            continue;
        }

        if (line[x] == 'B')
        {
            blueBeadY = y;
            blueBeadX = x;
            continue;
        }

        if (line[x] == '#')
        {
            board[y, x] = '#';
            continue;
        }

        if (line[x] == 'O')
        {
            board[y, x] = 'O';
        }
    }
}

var dx = new int[] { 0, 0, 1, -1 }; // 남, 북, 동, 서
var dy = new int[] { 1, -1, 0, 0 }; // 남, 북, 동, 서

var visited = new bool[Y, X, Y, X];
visited[redBeadY, redBeadX, blueBeadY, blueBeadX] = true;
var queue = new Queue<(int redY, int redX, int blueY, int blueX, int count)>();
queue.Enqueue((redBeadY, redBeadX, blueBeadY, blueBeadX, 0));

var result = -1;

while (queue.Count > 0)
{
    var (redY, redX, blueY, blueX, count) = queue.Dequeue();
    if (count >= 10)
    {
        break;
    }

    for (var i = 0; i < 4; i++)
    {
        var nextRedY = redY;
        var nextRedX = redX;
        var nextBlueY = blueY;
        var nextBlueX = blueX;
        var redMoveCount = 0;
        var blueMoveCount = 0;
        while (nextBlueY + dy[i] >= 0 && nextBlueY + dy[i] < Y && nextBlueX + dx[i] >= 0 && nextBlueX + dx[i] < X && board[nextBlueY + dy[i], nextBlueX + dx[i]] != '#' && board[nextBlueY, nextBlueX] != 'O')
        {
            nextBlueY += dy[i];
            nextBlueX += dx[i];
            blueMoveCount++;
            if (board[nextBlueY, nextBlueX] == 'O')
            {
                break;
            }
        }

        while (nextRedY + dy[i] >= 0 && nextRedY + dy[i] < Y && nextRedX + dx[i] >= 0 && nextRedX + dx[i] < X && board[nextRedY + dy[i], nextRedX + dx[i]] != '#' && board[nextRedY, nextRedX] != 'O')
        {
            nextRedY += dy[i];
            nextRedX += dx[i];
            redMoveCount++;
            if (board[nextRedY, nextRedX] == 'O')
            {
                break;
            }
        }

        if (board[nextBlueY, nextBlueX] == 'O')
        {
            continue;
        }

        if (board[nextRedY, nextRedX] == 'O')
        {
            result = count + 1;
            break;
        }

        if (nextRedY == nextBlueY && nextRedX == nextBlueX)
        {
            if (redMoveCount > blueMoveCount)
            {
                nextRedY -= dy[i];
                nextRedX -= dx[i];
            }
            else
            {
                nextBlueY -= dy[i];
                nextBlueX -= dx[i];
            }
        }

        if (visited[nextRedY, nextRedX, nextBlueY, nextBlueX])
        {
            continue;
        }

        visited[nextRedY, nextRedX, nextBlueY, nextBlueX] = true;
        queue.Enqueue((nextRedY, nextRedX, nextBlueY, nextBlueX, count + 1));
    }
    
    if (result != -1)
    {
        break;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();