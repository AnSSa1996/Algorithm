using System.Text;

var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var board = new int[Y, X];

var dy = new int[] { -1, 1, 0, 0 };
var dx = new int[] { 0, 0, -1, 1 };

for (var y = 0; y < Y; y++)
{
    inputs = sr.ReadLine().Select(x => x - '0').ToArray();
    for (var x = 0; x < X; x++)
    {
        board[y, x] = inputs[x];
    }
}

var resultBoard = new int[Y, X];
var groupBoard = new (int group, int count) [Y, X];

var group = 0;
for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        if (board[y, x] == 1) continue;
        if (groupBoard[y, x].group != 0) continue;
        group++;
        groupBoard[y, x].group = group;
        
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue((y, x));
        var groupList = new List<(int y, int x)>();
        groupList.Add((y, x));

        while (queue.Count > 0)
        {
            var (curY, curX) = queue.Dequeue();
            for (var i = 0; i < 4; i++)
            {
                var ny = curY + dy[i];
                var nx = curX + dx[i];
                if (ny < 0 || ny >= Y || nx < 0 || nx >= X)
                {
                    continue;
                }

                if (board[ny, nx] == 1) continue;
                if (groupBoard[ny, nx].group != 0) continue;
                groupBoard[ny, nx].group = group;
                queue.Enqueue((ny, nx));
                groupList.Add((ny, nx));
            }
        }

        foreach (var (ny, nx) in groupList)
        {
            groupBoard[ny, nx].count = groupList.Count;
        }
    }
}

for(var y = 0; y < Y; y++)
{
    for(var x = 0; x < X; x++)
    {
        if (board[y, x] != 1) continue;
        
        var sum = 1;
        var set = new HashSet<int>();
        for (var i = 0; i < 4; i++)
        {
            var ny = y + dy[i];
            var nx = x + dx[i];
            if (ny < 0 || ny >= Y || nx < 0 || nx >= X)
            {
                continue;
            }

            if (board[ny, nx] != 0) continue;

            if (set.Add(groupBoard[ny, nx].group) == false) continue;
            sum += groupBoard[ny, nx].count;
        }
        resultBoard[y, x] = sum % 10;
    }
}

var sb = new StringBuilder();
for (var y = 0; y < Y; y++)
{
    for (var x = 0; x < X; x++)
    {
        sb.Append(resultBoard[y, x]);
    }
    sb.AppendLine();
}

sw.Write(sb);
sw.Close();
sr.Close();