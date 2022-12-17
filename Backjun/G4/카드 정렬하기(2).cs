var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var pq = new PriorityQueue<int, int>();

for (var i = 0; i < N; i++)
{
    var num = int.Parse(sr.ReadLine());
    pq.Enqueue(num, num);
}

var total = 0;

while (pq.Count > 1)
{
    var A = pq.Dequeue();
    var B = pq.Dequeue();

    var sum = A + B;
    total += sum;
    pq.Enqueue(sum, sum);
}

sw.WriteLine(total);

sw.Flush();
sw.Close();
sr.Close();