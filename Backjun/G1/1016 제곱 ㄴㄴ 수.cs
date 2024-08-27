var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var start = inputs[0];
var end = inputs[1];
var squareLength = end - start + 1;
var notSquare = new bool[squareLength];
CheckSquare(start, end);

var count = 0;

for (long i = 0; i < squareLength; i++)
{
    if (!notSquare[i])
    {
        count++;
    }
}

sw.WriteLine(count);

sr.Close();
sw.Close();

void CheckSquare(long start, long end)
{
    for (long i = 2; i * i <= end; i++)
    {
        var square = i * i;
        var firstMultiple = start % square == 0 ? start : start + (square - (start % square));
        
        for (long j = firstMultiple; j <= end; j += square)
        {
            notSquare[j - start] = true;
        }
    }
}