var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var board = new int[10, 10];

for (var y = 0; y < 10; y++)
{
    var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < 10; x++)
    {
        board[y, x] = line[x];
    }
}

var result = 1000000;

void DFS(int one, int two, int three, int four, int five, int currentX, int currentY)
{
    if (one > 5 || two > 5 || three > 5 || four > 5 || five > 5) return;
    if (one + two + three + four + five >= result) return;
    var total = one + two + three + four + five;
    if (currentY >= 10)
    {
        if (total < result)
        {
            result = total;
        }
        return;
    }
    
    if (currentX >= 10)
    {
        DFS(one, two, three, four, five, 0, currentY + 1);
        return;
    }

    if (board[currentY, currentX] == 1)
    {
        for (var interval = 0; interval < 5; interval++)
        {
            if (currentX + interval >= 10 || currentY + interval >= 10) break;
            if (BoardCheck(currentY, currentX, interval))
            {
                BoardChange(currentY, currentX, interval, 0);
                if (interval == 0)
                {
                    DFS(one + 1, two, three, four, five, currentX + 1, currentY);
                }
                else if (interval == 1)
                {
                    DFS(one, two + 1, three, four, five, currentX + 2, currentY);
                }
                else if (interval == 2)
                {
                    DFS(one, two, three + 1, four, five, currentX + 3, currentY);
                }
                else if (interval == 3)
                {
                    DFS(one, two, three, four + 1, five, currentX + 4, currentY);
                }
                else if (interval == 4)
                {
                    DFS(one, two, three, four, five + 1, currentX + 5, currentY);
                }
                BoardChange(currentY, currentX, interval, 1);
            }
        }
    }
    else
    {
        DFS(one, two, three, four, five, currentX + 1, currentY);
    }
}

bool BoardCheck(int startY, int startX, int interval)
{
    var isOk = true;
    for (var y = startY; y <= startY + interval; y++)
    {
        for (var x = startX; x <= startX + interval; x++)
        {
            if (board[y, x] == 0)
            {
                isOk = false;
                break;
            }
        }

        if (!isOk) break;
    }

    return isOk;
}

void BoardChange(int startY, int startX, int interval, int value)
{
    for (var y = startY; y <= startY + interval; y++)
    {
        for (var x = startX; x <= startX + interval; x++)
        {
            board[y, x] = value;
        }
    }
}

DFS(0, 0, 0, 0, 0, 0, 0);
sw.WriteLine(result == 1000000 ? -1 : result);
sw.Close();
sr.Close();