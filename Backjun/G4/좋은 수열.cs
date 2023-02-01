using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
var sb = new StringBuilder();

var N = int.Parse(sr.ReadLine());
var board = new int[N];
DFS(0);

void DFS(int count)
{
    if (count == N)
    {
        PrintBoard();
        return;
    }

    for (var num = 1; num <= 3; num++)
    {
        var current = board[count];
        var check = Check(count, num);
        board[count] = current;
        if (check)
        {
            board[count] = num;
            DFS(count + 1);
            board[count] = current;
        }
    }
}

bool Check(int index, int num)
{
    board[index] = num;
    for (var count = 1; count <= (index + 1) / 2; count++)
    {
        var check = 0;
        var startFirstIndex = index - (count - 1);
        var startSecondIndex = index - (2 * count - 1);
        for (var i = 0; i < count; i++)
        {
            if (board[startFirstIndex + i] == board[startSecondIndex + i])
            {
                check++;
                continue;
            }

            break;
        }

        if (check == count) return false;
    }

    return true;
}

void PrintBoard()
{
    for (var i = 0; i < N; i++)
    {
        sb.Append(board[i]);
    }

    sw.WriteLine(sb);
    sw.Close();
    sr.Close();
    Environment.Exit(0);
}

sw.Flush();
sw.Close();
sr.Close();