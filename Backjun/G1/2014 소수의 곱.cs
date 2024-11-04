var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var K = inputs[0];
var N = inputs[1];

var nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

var pq = new PriorityQueue<long, long>();

foreach (var num in nums)
{
    pq.Enqueue(num, num);
}

var last = 0L;

for (var i = 0; i < N; i++)
{
    var num = pq.Dequeue();
    last = num;
    foreach (var n in nums)
    {
        var next = num * n;
        pq.Enqueue(next, next);
        if (num % n == 0)
        {
            break;
        }
    }
}

sw.WriteLine(last);
sr.Close();
sw.Close();