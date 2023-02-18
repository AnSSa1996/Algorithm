var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var M = inputs[0];
var N = inputs[1];
var L = inputs[2];

var squadArray = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
Array.Sort(squadArray);
var animalList = new List<(long x, long y)>();
for (var n = 0; n < N; n++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    animalList.Add((inputs[0], inputs[1]));
}

long count = 0;
long length = squadArray.Length;
foreach (var animal in animalList)
{
    var x = animal.x;
    var y = animal.y;
    if (y > L) continue;
    long start = 0;
    var end = length - 1;

    var shortest = x + y - L;
    var longest = x - y + L;
    while (start <= end)
    {
        var mid = (start + end) / 2;

        if (squadArray[mid] >= shortest && squadArray[mid] <= longest)
        {
            count++;
            break;
        }

        if (squadArray[mid] < longest) start = mid + 1;
        else
        {
            end = mid - 1;
        }
    }
}

sw.WriteLine(count);

sw.Flush();
sw.Close();
sr.Close();