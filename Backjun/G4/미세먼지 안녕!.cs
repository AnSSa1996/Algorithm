using System.Runtime.InteropServices.ObjectiveC;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());


var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var T = inputs[2];

var dx = new int[4] { 0, 0, 1, -1 };
var dy = new int[4] { 1, -1, 0, 0 };

var board = new int[Y, X];
var upAir_Y = 0;
var upAir_X = 0;
var downAir_Y = 0;
var downAir_X = 0;
var upAirCheck = false;

var nextValue = 0;

for (var y = 0; y < Y; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
        if (inputs[x] == -1 && upAirCheck == false)
        {
            upAir_Y = y;
            upAir_X = x;
            upAirCheck = true;
        }
        else if (inputs[x] == -1 && upAirCheck == true)
        {
            downAir_Y = y;
            downAir_X = x;
        }
    }
}

while (T > 0)
{
    T--;
    Diff();
    nextValue = 0;
    Air(upAir_Y, upAir_X, nextValue, eDirection.RIGHT);
    Air(upAir_Y, X - 1, nextValue, eDirection.UP);
    Air(0, X - 1, nextValue, eDirection.LEFT);
    Air(0, 0, nextValue, eDirection.DOWN);

    nextValue = 0;
    Air(downAir_Y, downAir_X, nextValue, eDirection.RIGHT);
    Air(downAir_Y, X - 1, nextValue, eDirection.DOWN);
    Air(Y - 1, X - 1, nextValue, eDirection.LEFT);
    Air(Y - 1, 0, nextValue, eDirection.UP);
}

var result = 0;

for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        if (board[y, x] <= 0) continue;
        result += board[y, x];
    }
}

sw.WriteLine(result);

void Diff()
{
    var newBoard = new int[Y, X];

    for (var y = 0; y < Y; y++)
    {
        for (var x = 0; x < X; x++)
        {
            newBoard[y, x] += board[y, x];
            if (board[y, x] == 0) continue;
            var amount = board[y, x] / 5;
            if (amount == 0) continue;
            var count = 0;
            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dx[d];
                var nextY = y + dy[d];
                if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) continue;
                if (board[nextY, nextX] == -1) continue;
                count++;
                newBoard[nextY, nextX] += amount;
            }

            newBoard[y, x] -= amount * count;
        }
    }

    board = newBoard;
}

void Air(int y, int x, int prevValue, eDirection direction, int count = 0)
{
    if (board[y, x] == -1 && count != 0)
    {
        return;
    }

    var nextY = y;
    var nextX = x;
    switch (direction)
    {
        case eDirection.UP:
            nextY -= 1;
            break;
        case eDirection.RIGHT:
            nextX += 1;
            break;
        case eDirection.DOWN:
            nextY += 1;
            break;
        case eDirection.LEFT:
            nextX -= 1;
            break;
    }

    nextValue = prevValue;
    if (count != 0)
    {
        nextValue = board[y, x];
        board[y, x] = prevValue;
    }

    if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y) return;
    Air(nextY, nextX, nextValue, direction, count + 1);
}

sw.Flush();
sw.Close();
sr.Close();

enum eDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT,
}