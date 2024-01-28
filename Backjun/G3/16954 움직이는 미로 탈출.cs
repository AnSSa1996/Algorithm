var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var firstBoard = new bool[8, 8];

for (var i = 0; i < 8; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < 8; j++)
    {
        firstBoard[i, j] = line[j] == '#';
    }
}

var boardArray = new List<bool[,]>();
boardArray.Add(firstBoard);

for (var i = 0; i <= 8; i++)
{
    boardArray.Add(MoveBoard(boardArray[i]));
}

bool[,] MoveBoard(bool[,] board)
{
    var newBoard = new bool[8, 8];
    for (var y = 0; y < 8; y++)
    {
        for (var x = 0; x < 8; x++)
        {
            var nextY = y + 1;
            var nextX = x;
            if (nextY < 8 && board[y, x])
            {
                newBoard[nextY, nextX] = true;
            }
        }
    }

    return newBoard;
}

var queue = new Queue<(int y, int x, int moveCount)>();
queue.Enqueue((7, 0, 0));
var result = 0;
while (queue.Count > 0)
{
    var (y, x, moveCount) = queue.Dequeue();
    if (y == 0 && x == 7)
    {
        result = 1;
        break;
    }

    var board = boardArray[moveCount];
    var nextBoard = boardArray[moveCount + 1];
    var nextMoveCount = moveCount + 1;
    if (nextMoveCount > 7) nextMoveCount = 7;
    var nextY = y;
    var nextX = x;
    if (y > 0 && board[y - 1, x] == false && nextBoard[y - 1, x] == false)
    {
        nextY = y - 1;
        nextX = x;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }

    if (y < 7 && board[y + 1, x] == false && nextBoard[y + 1, x] == false)
    {
        nextY = y + 1;
        nextX = x;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }

    if (x > 0 && board[y, x - 1] == false && nextBoard[y, x - 1] == false)
    {
        nextY = y;
        nextX = x - 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }

    if (x < 7 && board[y, x + 1] == false && nextBoard[y, x + 1] == false)
    {
        nextY = y;
        nextX = x + 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }

    if (y > 0 && x > 0 && board[y - 1, x - 1] == false && nextBoard[y - 1, x - 1] == false)
    {
        nextY = y - 1;
        nextX = x - 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }
    
    if (y > 0 && x < 7 && board[y - 1, x + 1] == false && nextBoard[y - 1, x + 1] == false)
    {
        nextY = y - 1;
        nextX = x + 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }
    
    if (y < 7 && x > 0 && board[y + 1, x - 1] == false && nextBoard[y + 1, x - 1] == false)
    {
        nextY = y + 1;
        nextX = x - 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }
    
    if (y < 7 && x < 7 && board[y + 1, x + 1] == false && nextBoard[y + 1, x + 1] == false)
    {
        nextY = y + 1;
        nextX = x + 1;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }

    if (board[y, x] == false && nextBoard[y, x] == false)
    {
        nextY = y;
        nextX = x;
        queue.Enqueue((nextY, nextX, nextMoveCount));
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();