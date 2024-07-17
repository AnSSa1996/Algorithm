var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var railList = new List<(int start, int end)>();
for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    
    if(start > end)
    {
        (start, end) = (end, start);
    }
    railList.Add((start, end));
}

var length = int.Parse(sr.ReadLine());

railList.Sort((a, b) => a.end.CompareTo(b.end));

var count = 0;
var pq = new PriorityQueue<int, int>();

foreach (var rail in railList)
{
    var (start, end) = rail;
    var minStart = end - length;
    
    pq.Enqueue(start, start);
    while (pq.Count > 0 && pq.Peek() < minStart)
    {
        pq.Dequeue();
    }
    
    count = Math.Max(count, pq.Count);
}

sw.WriteLine(count);

sw.Flush();
sw.Close();
sr.Close();