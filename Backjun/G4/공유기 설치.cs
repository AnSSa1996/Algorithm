using System.Text;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var C = inputs[1];
var maxDistance = 0;

var homePosList = new List<int>();
for (var i = 0; i < N; i++) homePosList.Add(int.Parse(sr.ReadLine()));
homePosList.Sort();
var start = 1;
var end = homePosList.Max();
while (start <= end)
{
    var mid = (start + end) / 2;
    var count = 1;
    var currentPos = homePosList[0];
    for (var i = 1; i < N; i++)
    {
        if (homePosList[i] - currentPos >= mid)
        {
            currentPos = homePosList[i];
            count++;
        }
    }

    if (count >= C)
    {
        start = mid + 1;
    }
    else
    {
        end = mid - 1;
    }
}

sw.WriteLine(end);

sw.Flush();
sr.Close();
sw.Close();
