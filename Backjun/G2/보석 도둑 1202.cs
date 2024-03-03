var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

var N = inputs[0];      // 보석의 정보
var K = inputs[1];      // 가방의 정보

var jewWeightPriorityQueue = new PriorityQueue<(long weight, long value), long>();
for (var i = 0; i < N; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var weight = inputs[0];
    var value = inputs[1];
    jewWeightPriorityQueue.Enqueue((weight, value), weight); // 무게가 가장 작은 순으로 정렬
}


var bagList = new List<long>();
for (var i = 0; i < K; i++)
{
    bagList.Add(long.Parse(sr.ReadLine()));
}

bagList.Sort();

long result = 0;
var jewValuePriorityQueue = new PriorityQueue<(long weight, long value), long>();

for (var i = 0; i < K; i++)
{
    var bag = bagList[i];
    while (jewWeightPriorityQueue.Count > 0 && jewWeightPriorityQueue.Peek().weight <= bag)
    {
        var current = jewWeightPriorityQueue.Dequeue();
        jewValuePriorityQueue.Enqueue((current.weight, current.value), -current.value);
    }

    if (jewValuePriorityQueue.Count == 0) continue;
    var currentJew = jewValuePriorityQueue.Dequeue();
    result += currentJew.value;
}

sw.WriteLine(result);
sw.Close();
sr.Close();