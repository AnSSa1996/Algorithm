using System.Runtime.CompilerServices;
using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var board = new int[9, 9];
var blankCount = 0;
var blank = new List<(int y, int x)>();
for (var y = 0; y < 9; y++)
{
    var inputs = sr.ReadLine().Select(x => x - '0').ToArray();
    for (var x = 0; x < 9; x++)
    {
        board[y, x] = inputs[x];
        if (inputs[x] == 0)
        {
            blankCount++;
            blank.Add((y, x));
        }
    }
}

var allCheck = false;
DFS(0);
void DFS(int count)
{
    if (allCheck) return;
    if (count == blankCount)
    {
        StringBuilder sb = new StringBuilder();
        for (var y = 0; y < 9; y++)
        {
            for (var x = 0; x < 9; x++)
            {
                sb.Append(board[y, x]);
            }

            sb.AppendLine();
        }

        sw.Write(sb);
        allCheck = true;
        return;
    }

    var currentBlank = blank[count];
    var Y = currentBlank.y;
    var X = currentBlank.x;
    for (var num = 1; num <= 9; num++)
    {
        if (AllCheck(Y, X, num) == false) continue;
        board[Y, X] = num;
        DFS(count + 1);
        board[Y, X] = 0;
    }
}

bool AllCheck(int Y, int X, int current)
{
    if (checkRow(Y, X, current) == false) return false;
    if (checkColumn(Y, X, current) == false) return false;
    if (checkBox(Y, X, current) == false) return false;
    return true;
}

bool checkRow(int Y, int X, int current)
{
    var check = true;
    for (var x = 0; x < 9; x++)
    {
        if (board[Y, x] != current) continue;
        check = false;
        break;
    }

    return check;
}

bool checkColumn(int Y, int X, int current)
{
    var check = true;
    for (var y = 0; y < 9; y++)
    {
        if (board[y, X] != current) continue;
        check = false;
        break;
    }

    return check;
}

bool checkBox(int Y, int X, int current)
{
    var check = true;
    var startY = (Y / 3)*3;
    var startX = (X / 3)*3;
    for (var y = startY; y < startY + 3; y++)
    {
        for (var x = startX; x < startX + 3; x++)
        {
            if (board[y, x] != current) continue;
            check = false;
            break;
        }
    }

    return check;
}

sw.Flush();
sw.Close();
sr.Close();