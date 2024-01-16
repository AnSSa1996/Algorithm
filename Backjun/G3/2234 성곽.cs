var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var M = inputs[0];      // 가로
var N = inputs[1];      // 세로

var west = 1;
var north = 2;
var east = 4;
var south = 8;

var map = new Point[N, M];
for (var i = 0; i < N; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < M; j++)
    {
        map[i, j] = new Point(
            (inputs[j] & west) != west,
            (inputs[j] & north) != north,
            (inputs[j] & east) != east,
            (inputs[j] & south) != south
        );
    }
}

var visited = new bool[N, M];
var roomCount = 0;
var max = 0;
for(var y = 0; y<N; y++)
{
    for(var x = 0; x<M; x++)
    {
        if (visited[y, x])
        {
            continue;
        }
        roomCount++;
        var count = CountRoom(y, x, visited);
        if (count > max) max = count;
    }
}


int CountRoom(int startY, int startX, bool[,] countVisited)
{
    var queue = new Queue<(int y, int x)>();
    queue.Enqueue((startY, startX));
    countVisited[startY, startX] = true;
    
    var count = 1;

    while (queue.Count > 0)
    {
        var (y, x) = queue.Dequeue();

        if (map[y, x].canGoWest && x - 1 >= 0 && countVisited[y, x - 1] == false)
        {
            queue.Enqueue((y, x - 1));
            countVisited[y, x - 1] = true;
            count++;
        }

        if (map[y, x].canGoNorth && y - 1 >= 0 && countVisited[y - 1, x] == false)
        {
            queue.Enqueue((y - 1, x));
            countVisited[y - 1, x] = true;
            count++;
        }

        if (map[y, x].canGoEast && x + 1 < M && countVisited[y, x + 1] == false)
        {
            queue.Enqueue((y, x + 1));
            countVisited[y, x + 1] = true;
            count++;
        }

        if (map[y, x].canGoSouth && y + 1 < N && countVisited[y + 1, x] == false)
        {
            queue.Enqueue((y + 1, x));
            countVisited[y + 1, x] = true;
            count++;
        }
    }

    return count;
}

var secondMax = 0;
for(var y = 0; y<N; y++)
{
    for(var x = 0; x<M; x++)
    {
        var mapPoint = map[y, x];
        if (mapPoint.canGoWest == false)
        {
            mapPoint.canGoWest = true;
            var count = CountRoom(y, x, new bool[N, M]);
            if (count > secondMax) secondMax = count;
            mapPoint.canGoWest = false;
        }
        
        if (mapPoint.canGoNorth == false)
        {
            mapPoint.canGoNorth = true;
            var count = CountRoom(y, x, new bool[N, M]);
            if (count > secondMax) secondMax = count;
            mapPoint.canGoNorth = false;
        }
        
        if (mapPoint.canGoEast == false)
        {
            mapPoint.canGoEast = true;
            var count = CountRoom(y, x, new bool[N, M]);
            if (count > secondMax) secondMax = count;
            mapPoint.canGoEast = false;
        }
        
        if (mapPoint.canGoSouth == false)
        {
            mapPoint.canGoSouth = true;
            var count = CountRoom(y, x, new bool[N, M]);
            if (count > secondMax) secondMax = count;
            mapPoint.canGoSouth = false;
        }
    }
}

sw.WriteLine(roomCount);
sw.WriteLine(max);
sw.WriteLine(secondMax);
sw.Close();
sr.Close();

public class Point
{
    public bool canGoWest = false;
    public bool canGoNorth = false;
    public bool canGoEast = false;
    public bool canGoSouth = false;

    public Point(bool canGoWest, bool canGoNorth, bool canGoEast, bool canGoSouth)
    {
        this.canGoWest = canGoWest;
        this.canGoNorth = canGoNorth;
        this.canGoEast = canGoEast;
        this.canGoSouth = canGoSouth;
    }
}