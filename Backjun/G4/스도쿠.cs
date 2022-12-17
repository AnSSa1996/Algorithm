using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;
using Microsoft.VisualBasic;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
StringBuilder sb = new StringBuilder();

var board = new int[9, 9];
var check = false;
List<(int Y, int X)> blank = new List<(int Y, int X)>();
for (var y = 0; y < 9; y++)
{
    var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < 9; x++)
    {
        board[y, x] = nums[x];
        if (nums[x] == 0) blank.Add((y, x));
    }
}

bool CheckRow(int row, int num)
{
    for (var x = 0; x < 9; x++)
    {
        if (board[row, x] == num) return false;
    }

    return true;
}

bool CheckColumn(int column, int num)
{
    for (var y = 0; y < 9; y++)
    {
        if (board[y, column] == num) return false;
    }

    return true;
}

bool CheckBox(int currentY, int currentX, int num)
{
    var Y = (currentY / 3) * 3;
    var X = (currentX / 3) * 3;

    for (var y = Y; y < Y + 3; y++)
    {
        for (var x = X; x < X + 3; x++)
        {
            if (board[y, x] == num) return false;
        }
    }

    return true;
}

void DFS(int currentBlank)
{
    if (check) return;
    if (currentBlank == blank.Count())
    {
        check = true;
        for (var Y = 0; Y < 9; Y++)
        {
            for (var X = 0; X < 9; X++)
            {
                sb.Append($"{board[Y, X]} ");
            }

            sb.AppendLine();
        }

        return;
    }

    var current = blank[currentBlank];
    var y = current.Y;
    var x = current.X;

    for (var num = 1; num <= 9; num++)
    {
        if (CheckRow(y, num) == false) continue;
        if (CheckColumn(x, num) == false) continue;
        if (CheckBox(y, x, num) == false) continue;

        board[y, x] = num;
        DFS(currentBlank + 1);
        if (check) return;
        board[y, x] = 0;
    }
}

DFS(0);
sb.Remove(sb.Length - 1, 1);
sw.Write(sb);

sw.Flush();
sr.Close();
sw.Close();