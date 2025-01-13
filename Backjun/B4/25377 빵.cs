var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var timeList = new List<int>();

for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];
    if (a > b) continue;
    timeList.Add(b);
}

if (timeList.Count == 0)
{
    sw.WriteLine(-1);
}
else
{
    timeList.Sort();
    sw.WriteLine(timeList[0]);
}


sw.Close();
sr.Close();