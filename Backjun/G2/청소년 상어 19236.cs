var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var dx = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };
var dy = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };

var map = new Fish[4, 4];

for (var y = 0; y < 4; y++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < 8; x += 2)
    {
        var order = inputs[x];
        var dir = inputs[x + 1] - 1;
        map[y, x / 2] = new Fish(order, dir, true);
    }
}

var answer = 0;

void MoveFish(Fish[,] map, int sharkX, int sharkY)
{
    for (var i = 1; i <= 16; i++)
    {
        var currentX = -1;
        var currentY = -1;

        for (var y = 0; y < 4; y++)
        {
            for (var x = 0; x < 4; x++)
            {
                if (map[y, x].order == i && map[y, x].isAlive)
                {
                    currentX = x;
                    currentY = y;
                    break;
                }
            }

            if (currentX != -1)
            {
                break;
            }
        }

        if (currentX == -1)
        {
            continue;
        }

        var currentFish = map[currentY, currentX];

        for (var j = 0; j < 8; j++)
        {
            var nextDir = (currentFish.dir + j) % 8;
            var nextX = currentX + dx[nextDir];
            var nextY = currentY + dy[nextDir];

            if (nextX < 0 || nextX >= 4 || nextY < 0 || nextY >= 4)
            {
                continue;
            }

            if (nextX == sharkX && nextY == sharkY)
            {
                continue;
            }

            currentFish.dir = nextDir;
            var nextFish = map[nextY, nextX];
            map[currentY, currentX] = nextFish;
            map[nextY, nextX] = currentFish;
            break;
        }
    }
}


void DFS(Fish[,] map, int sharkX, int sharkY, int sum)
{
    answer = Math.Max(answer, sum);
    var currentFish = map[sharkY, sharkX];
    var currentDir = currentFish.dir;

    var copyMap = new Fish[4, 4];
    for (var y = 0; y < 4; y++)
    {
        for (var x = 0; x < 4; x++)
        {
            copyMap[y, x] = new Fish(map[y, x].order, map[y, x].dir, map[y, x].isAlive);
        }
    }

    copyMap[sharkY, sharkX] = new Fish(currentFish.order, currentFish.dir, false);
    MoveFish(copyMap, sharkX, sharkY);

    for (var i = 1; i <= 3; i++)
    {
        var nextX = sharkX + dx[currentDir] * i;
        var nextY = sharkY + dy[currentDir] * i;

        if (nextX < 0 || nextX >= 4 || nextY < 0 || nextY >= 4)
        {
            break;
        }

        if (copyMap[nextY, nextX].isAlive)
        {
            DFS(copyMap, nextX, nextY, sum + copyMap[nextY, nextX].order);
        }
    }
}

DFS(map, 0, 0, map[0, 0].order);

sw.WriteLine(answer);
sw.Close();
sr.Close();

public class Fish
{
    public int order;
    public int dir;
    public bool isAlive;

    public Fish(int order, int dir, bool isAlive)
    {
        this.order = order;
        this.dir = dir;
        this.isAlive = isAlive;
    }
}