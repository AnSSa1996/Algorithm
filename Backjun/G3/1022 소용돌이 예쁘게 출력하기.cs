using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var y1 = inputs[0];
var x1 = inputs[1];
var y2 = inputs[2];
var x2 = inputs[3];

var max = Math.Max(Math.Max(Math.Abs(y1), Math.Abs(y2)), Math.Max(Math.Abs(x1), Math.Abs(x2)));

var maxY = y2 - y1 + 1;
var maxX = x2 - x1 + 1;
var board = new int[maxY, maxX];

var count = 0;
var dx = new int[4] { 0, -1, 0, 1 };
var dy = new int[4] { -1, 0, 1, 0 };

var currentX = 0;
var currentY = 0;
var currentValue = 1;
var maxValue = 0;
if (currentY >= y1 && currentY <= y2 && currentX >= x1 && currentX <= x2)
{
    board[currentY - y1, currentX - x1] = currentValue;
}

while (count <= max)
{
    for (var d = 0; d < 4; d++)
    {
        for (var next = 0; next < count * 2; next++)
        {
            currentX += dx[d];
            currentY += dy[d];
            currentValue += 1;
            if (currentY >= y1 && currentY <= y2 && currentX >= x1 && currentX <= x2)
            {
                board[currentY - y1, currentX - x1] = currentValue;
                maxValue = currentValue;
            }
        }
    }

    count++;
    currentY++;
    currentX++;
}

var maxlen = maxValue.ToString().Length;
var sb = new StringBuilder();
for (var y = 0; y < maxY; y++)
{
    for (var x = 0; x < maxX; x++)
    {
        sb.Append($"{board[y, x]}".PadLeft(maxlen));
        if (x != maxX - 1) sb.Append(' ');
    }

    sb.AppendLine();
}

sw.Write(sb);

sw.Flush();
sw.Close();
sr.Close();