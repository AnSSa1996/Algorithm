using System.Text;

var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());

var MaxPriorityQueue = new PriorityQueue<int, int>();
var MinPriorityQueue = new PriorityQueue<int, int>();

var sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
    var num = int.Parse(sr.ReadLine());
    if (MaxPriorityQueue.Count == MinPriorityQueue.Count)
    {
        MaxPriorityQueue.Enqueue(num, -num);
    }
    else
    {
        MinPriorityQueue.Enqueue(num, num);
    }

    if (MaxPriorityQueue.Count > 0 && MinPriorityQueue.Count > 0)
    {
        var max = MaxPriorityQueue.Peek();
        var min = MinPriorityQueue.Peek();
        if (max > min)
        {
            MaxPriorityQueue.Dequeue();
            MinPriorityQueue.Dequeue();
            MaxPriorityQueue.Enqueue(min, -min);
            MinPriorityQueue.Enqueue(max, max);
        }
    }

    sb.AppendLine(MaxPriorityQueue.Peek().ToString());
}

sw.Write(sb.ToString());
sw.Close();
sr.Close();
