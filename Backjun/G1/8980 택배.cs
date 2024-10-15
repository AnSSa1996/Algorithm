var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var C = inputs[1];
var M = int.Parse(sr.ReadLine());

var deliveryList = new List<(int start, int end, int box)>();
for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    var box = inputs[2];
    
    deliveryList.Add((start, end, box));
}


deliveryList.Sort((a, b) =>
{
    if (a.end == b.end)
    {
        return a.start.CompareTo(b.start);
    }
    return a.end.CompareTo(b.end);
});

var total = 0;
var delivery = new int[N + 1];
for (var i = 0; i < M; i++)
{
    var start = deliveryList[i].start;
    var end = deliveryList[i].end;
    var box = deliveryList[i].box;

    var max = 0;
    for (var j = start; j < end; j++)
    {
        max = Math.Max(max, delivery[j]);
    }

    var remain = Math.Min(C - max, box);
    for (var j = start; j < end; j++)
    {
        delivery[j] += remain;
    }
    
    total += remain;
}

sw.WriteLine(total);
sr.Close();
sw.Close();