StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

double Inclination(double x1, double y1, double x2, double y2)
{
    return (y2 - y1) / (x2 - x1);
}

int N = int.Parse(sr.ReadLine());
int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var maxCount = 0;
for (int index = 0; index < N; index++)
{
    var currentHeight = inputs[index];
    var leftSlope = double.MaxValue;
    var leftCount = 0;
    for (int left = index - 1; left >= 0; left--)
    {
        var leftHieght = inputs[left];
        var curSlope = Inclination(index, currentHeight, left, leftHieght);
        if (curSlope < leftSlope)
        {
            leftCount++;
            leftSlope = curSlope;
        }
    }

    var rightSlope = -double.MaxValue;
    var rightCount = 0;
    for (int right = index + 1; right < N; right++)
    {
        var rightHeight = inputs[right];
        var curSlope = Inclination(index, currentHeight, right, rightHeight);
        if (curSlope > rightSlope)
        {
            rightCount++;
            rightSlope = curSlope;
        }
    }

    var sumCount = leftCount + rightCount;
    maxCount = Math.Max(maxCount, sumCount);
}

sw.WriteLine(maxCount);

sw.Flush();
sw.Close();
sr.Close();