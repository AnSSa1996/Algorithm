var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var paper = new int[N, N];

var white = 0;
var black = 0;

for (var y = 0; y < N; y++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var x = 0; x < N; x++)
    {
        paper[y, x] = inputs[x];
    }
}

CutPaper(0, 0, N);

sw.WriteLine(white);
sw.WriteLine(black);

sw.Close();
sr.Close();

void CutPaper(int row, int col, int size)
{
    var color = paper[row, col];
    var isSame = true;

    for (var y = row; y < row + size; y++)
    {
        for (var x = col; x < col + size; x++)
        {
            if (paper[y, x] != color)
            {
                isSame = false;
                break;
            }
        }
        
        if (!isSame)
        {
            break;
        }
    }


    if (isSame)
    {
        if (color == 0)
        {
            white++;
        }
        else
        {
            black++;
        }
        
        return;
    }
    
    var newSize = size / 2;
    CutPaper(row, col, newSize);
    CutPaper(row, col + newSize, newSize);
    CutPaper(row + newSize, col, newSize);
    CutPaper(row + newSize, col + newSize, newSize);
}