var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];

var board = new char[Y,X];
for (var i = 0; i < Y; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < X; j++)
    {
        board[i,j] = line[j];
    }
}

var N = int.Parse(sr.ReadLine());
var heightArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

for (var i = 0; i < N; i++)
{
    var height = Y - heightArray[i];
    if (i % 2 == 0)
    {
        LeftStick(height);
    }
    else
    {
        RightStick(height);
    }
    CheckGravity();
}

PrintBoard();
sr.Close();
sw.Close();


void LeftStick(int y)
{
    for(var x = 0; x < X; x++)
    {
        if(board[y,x] == 'x')
        {
            board[y,x] = '.';
            break;
        }
    }
}

void RightStick(int y)
{
    for(var x = X-1; x >= 0; x--)
    {
        if(board[y,x] == 'x')
        {
            board[y,x] = '.';
            break;
        }
    }
}

void CheckGravity()
{
    var visited = new bool[Y,X];
    var cluster = new List<(int y, int x)>();
    
    for(var y = 0; y < Y; y++)
    {
        for(var x = 0; x < X; x++)
        {
            if(board[y,x] == 'x' && visited[y,x] == false)
            {
                cluster.Clear();
                if (CheckCluster(y, x, visited, cluster) == false) continue;
                DropCluster(cluster);
                visited = new bool[Y, X];
            }
        }
    }
}

bool CheckCluster(int y, int x, bool[,] visited, List<(int y, int x)> cluster)
{
    var isFloating = true;
    var queue = new Queue<(int y, int x)>();
    queue.Enqueue((y,x));
    var dy = new int[] { 0, 0, 1, -1 };
    var dx = new int[] { 1, -1, 0, 0 };
    
    while(queue.Count > 0)
    {
        var current = queue.Dequeue();
        var currentX = current.x;
        var currentY = current.y;
        if (visited[currentY, currentX] == true)
        {
            continue;
        }

        if (currentY == Y - 1)
        {
            isFloating = false;
        }
        
        visited[currentY, currentX] = true;
        cluster.Add((currentY, currentX));
        
        for (var i = 0; i < 4; i++)
        {
            var nextY = currentY + dy[i];
            var nextX = currentX + dx[i];
            if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X)
            {
                continue;
            }

            if (visited[nextY, nextX] == false && board[nextY, nextX] == 'x')
            {
                queue.Enqueue((nextY, nextX));
            }
        }
    }
    
    return isFloating;
}

void DropCluster(List<(int y, int x)> cluster)
{
    var minDrop = int.MaxValue;
    foreach(var (y, x) in cluster)
    {
        var drop = 0;
        
        while (y + drop + 1 < Y && board[y + drop + 1, x] == '.')
        {
            drop++;
        }

        if (cluster.Exists(c => c.y == y + drop + 1 && c.x == x))
        {
            continue;
        }
        
        minDrop = Math.Min(minDrop, drop);
    }

    cluster.Sort((a, b) => b.y - a.y);
    
    foreach(var (y, x) in cluster)
    {
        board[y, x] = '.';
        board[y + minDrop, x] = 'x';
    }
}

void PrintBoard()
{
    for (var i = 0; i < Y; i++)
    {
        for (var j = 0; j < X; j++)
        {
            Console.Write(board[i,j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}