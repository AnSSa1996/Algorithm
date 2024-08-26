var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var Y = inputs[0];
var X = inputs[1];
var M = inputs[2];

var sharkList = new List<Shark>();

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    sharkList.Add(new Shark(inputs[0], inputs[1], inputs[2], inputs[3], inputs[4]));
}

var result = 0;

for (var x = 1; x <= X; x++)
{
    SharkSelect(x);
    SharkMoveAll();
    SharkRemove();
}

sw.WriteLine(result);

sr.Close();
sw.Close();

void SharkSelect(int x)
{
    var shark = sharkList.Where(s => s.x == x).MinBy(s => s.y);
    if (shark == null)
    {
        return;
    }
    result += shark.size;
    sharkList.Remove(shark);
}

void SharkMoveAll()
{
    foreach (var shark in sharkList)
    {
        SharkMove(shark);
    }
}

void SharkMove(Shark shark)
{
    var move = shark.speed;
    var direction = shark.direction;
    var y = shark.y;
    var x = shark.x;

    while (move > 0)
    {
        if(direction == 1)
        {
            var next = y - move;
            if (next >= 1)
            {
                y = next;
                move = 0;
            }
            else
            {
                move -= y - 1;
                y = 1;
                direction = 2;
            }
        }
        else if (direction == 2)
        {
            var next = y + move;
            if (next <= Y)
            {
                y = next;
                move = 0;
            }
            else
            {
                move -= Y - y;
                y = Y;
                direction = 1;
            }
        }
        else if (direction == 3)
        {
            var next = x + move;
            if (next <= X)
            {
                x = next;
                move = 0;
            }
            else
            {
                move -= X - x;
                x = X;
                direction = 4;
            }
        }
        else if (direction == 4)
        {
            var next = x - move;
            if (next >= 1)
            {
                x = next;
                move = 0;
            }
            else
            {
                move -= x - 1;
                x = 1;
                direction = 3;
            }
        }
    }
    
    shark.y = y;
    shark.x = x;
    shark.direction = direction;
}

void SharkRemove()
{
    var removeList = new List<Shark>();
    var sharkMap = new Dictionary<(int, int), Shark>();
    
    foreach (var shark in sharkList)
    {
        if (sharkMap.ContainsKey((shark.y, shark.x)))
        {
            if (sharkMap[(shark.y, shark.x)].size < shark.size)
            {
                removeList.Add(sharkMap[(shark.y, shark.x)]);
                sharkMap[(shark.y, shark.x)] = shark;
            }
            else
            {
                removeList.Add(shark);
            }
        }
        else
        {
            sharkMap[(shark.y, shark.x)] = shark;
        }
    }
    
    foreach (var shark in removeList)
    {
        sharkList.Remove(shark);
    }
}

class Shark
{
    public int y;
    public int x;
    public int speed;
    public int direction;
    public int size;
    
    public Shark(int y, int x, int speed, int direction, int size)
    {
        this.y = y;
        this.x = x;
        this.speed = speed;
        this.direction = direction;
        this.size = size;
    }
}