namespace sangBJ0128;

class Program
{
    static void Main(string[] args)
    {
        var sw = new StreamWriter(Console.OpenStandardOutput());
        var sr = new StreamReader(Console.OpenStandardInput());

        var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        var N = inputs[0]; // 세로
        var M = inputs[1]; // 가로
        var K = inputs[2]; // 이동 횟수

        var dx = new int[] { 0, 0, -1, 1 };
        var dy = new int[] { -1, 1, 0, 0 };

        var dice = new Dice(1, N, M, 0, 0, 1, 6, 4, 3, 5, 2);
        var map = new int[N, M];
        for (var i = 0; i < N; i++)
        {
            var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (var j = 0; j < M; j++)
            {
                map[i, j] = line[j];
            }
        }

        var result = 0;

        for (var k = 0; k < K; k++)
        {
            var direction = dice.Direction;
            dice.Move(direction);
            var current = map[dice.posY, dice.posX];
            dice.Roll(current);
            result += MoveDice(dice);
        }

        sw.WriteLine(result);
        sw.Close();
        sr.Close();

        int MoveDice(Dice dice)
        {
            var posY = dice.posY;
            var posX = dice.posX;
            var current = map[posY, posX];
            var queue = new Queue<(int y, int x)>();
            var visited = new bool[N, M];
            queue.Enqueue((posY, posX));
            visited[posY, posX] = true;
            var count = 0;
            while (queue.Count > 0)
            {
                var (y, x) = queue.Dequeue();
                count++;
                for (var d = 0; d < 4; d++)
                {
                    var nextY = y + dy[d];
                    var nextX = x + dx[d];
                    if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= M) continue;
                    if (map[nextY, nextX] != current) continue;
                    if (visited[nextY, nextX]) continue;
                    visited[nextY, nextX] = true;
                    queue.Enqueue((nextY, nextX));
                }
            }

            return count * current;
        }
    }
}

public class Dice
{
    public int Direction { get; set; }
    public int N { get; set; }
    public int M { get; set; }
    public int posY { get; set; }
    public int posX { get; set; }
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }
    public int Front { get; set; }
    public int Back { get; set; }

    public Dice(int direction, int n, int m, int posY, int posX, int top, int bottom, int left, int right, int front, int back)
    {
        Direction = direction;
        N = n;
        M = m;
        this.posY = posY;
        this.posX = posX;
        Top = top;
        Bottom = bottom;
        Left = left;
        Right = right;
        Front = front;
        Back = back;
    }

    public void Move(int direction)
    {
        Direction = direction;
        switch (direction)
        {
            case 1:
                MoveRight();
                break;
            case 2:
                MoveDown();
                break;
            case 3:
                MoveLeft();
                break;
            case 4:
                MoveUp();
                break;
        }
    }

    public void Roll(int current)
    {
        if (Bottom == current) return;
        if (Bottom > current) RollRight();
        else RollLeft();
    }

    private void RollRight()
    {
        Direction = Direction == 4 ? 1 : Direction + 1;
    }

    private void RollLeft()
    {
        Direction = Direction == 1 ? 4 : Direction - 1;
    }


    private void MoveRight()
    {
        Direction = 1;
        var nextPosX = posX + 1;
        if (nextPosX >= M)
        {
            MoveLeft();
            return;
        }

        posX = nextPosX;
        var temp = Top;
        Top = Left;
        Left = Bottom;
        Bottom = Right;
        Right = temp;
    }


    private void MoveDown()
    {
        Direction = 2;
        var nextPosY = posY + 1;
        if (nextPosY >= N)
        {
            MoveUp();
            return;
        }

        posY = nextPosY;
        var temp = Top;
        Top = Back;
        Back = Bottom;
        Bottom = Front;
        Front = temp;
    }


    private void MoveLeft()
    {
        Direction = 3;
        var nextPosX = posX - 1;
        if (nextPosX < 0)
        {
            MoveRight();
            return;
        }

        posX = nextPosX;
        var temp = Top;
        Top = Right;
        Right = Bottom;
        Bottom = Left;
        Left = temp;
    }

    private void MoveUp()
    {
        Direction = 4;
        var nextPosY = posY - 1;
        if (nextPosY < 0)
        {
            MoveDown();
            return;
        }

        posY = nextPosY;
        var temp = Top;
        Top = Front;
        Front = Bottom;
        Bottom = Back;
        Back = temp;
    }
}