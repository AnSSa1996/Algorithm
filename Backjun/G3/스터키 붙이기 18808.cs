var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];      // 세로
var M = inputs[1];      // 가로
var K = inputs[2];      // 스티커 개수

var board = new int[N, M];
var result = 0;
for (var k = 0; k < K; k++)
{
    var sticker = new Sticker(0, 0);
    var stickerInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    sticker.Height = stickerInputs[0];
    sticker.Width = stickerInputs[1];
    sticker.Data = new int[sticker.Height, sticker.Width];
    for (var i = 0; i < sticker.Height; i++)
    {
        var stickerData = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (var j = 0; j < sticker.Width; j++)
        {
            sticker.Data[i, j] = stickerData[j];
        }
    }

    var canAttach = false;
    for (var rotate = 0; rotate < 4; rotate++)
    {
        for (var y = 0; y < N; y++)
        {
            for (var x = 0; x < M; x++)
            {
                if (y + sticker.Height > N || x + sticker.Width > M) continue;
                var attach = true;
                for (var i = 0; i < sticker.Height; i++)
                {
                    for (var j = 0; j < sticker.Width; j++)
                    {
                        if (sticker.Data[i, j] == 1 && board[y + i, x + j] == 1)
                        {
                            attach = false;
                            break;
                        }
                    }
                    if (attach == false) break;
                }
                
                if (attach)
                {
                    canAttach = true;
                    for (var i = 0; i < sticker.Height; i++)
                    {
                        for (var j = 0; j < sticker.Width; j++)
                        {
                            if (sticker.Data[i, j] == 1)
                            {
                                board[y + i, x + j] = 1;
                            }
                        }
                    }
                }

                if (canAttach)
                {
                    result += sticker.Count();
                    goto ATTACH;
                }
            }
        }
        
        sticker.Rotate();
    }

    ATTACH:
    continue;
}

sw.WriteLine(result);
sw.Close();
sr.Close();


public class Sticker
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int[,] Data { get; set; }
    
    public int Count()
    {
        var count = 0;
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                if (Data[i, j] == 1)
                {
                    count++;
                }
            }
        }
        return count;
    }
    
    public Sticker(int height, int width)
    {
        Height = height;
        Width = width;
        Data = new int[height, width];
    }
    
    public void Rotate()
    {
        var temp = new int[Width, Height];
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                temp[j, Height - i - 1] = Data[i, j];
            }
        }
        
        var t = Height;
        Height = Width;
        Width = t;
        Data = temp;
    }
}