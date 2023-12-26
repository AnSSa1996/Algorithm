var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());               // 별의 갯수

var starList = new List<(float y, float x)>();     // 별의 좌표를 저장할 리스트
for (int i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), float.Parse);
    var x = inputs[0];
    var y = inputs[1];
    starList.Add((y, x));
}

var starParent = new int[N]; // 별의 부모
for (int i = 0; i < N; i++)
{
    starParent[i] = i;
}

var priorityQueue = new PriorityQueue<(int current, int next, double distance), double>(); // 별의 좌표와 거리를 저장할 우선순위 큐

for(var i = 0; i < N; i++)
{
    for(var j = i + 1; j < N; j++)
    {
        var currentStar = i;
        var nextStar = j;
        
        var x1 = starList[currentStar].x;
        var y1 = starList[currentStar].y;
        var x2 = starList[nextStar].x;
        var y2 = starList[nextStar].y;
        
        var distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        priorityQueue.Enqueue((currentStar, nextStar, distance), distance);
    }
}

var result = 0.0;
var count = 0;
while(priorityQueue.Count > 0)
{
    var (currentStar, nextStar, distance) = priorityQueue.Dequeue();
    if (Find(currentStar) != Find(nextStar))
    {
        Union(currentStar, nextStar);
        result += distance;
        count++;
    }
    
    if (count == N - 1)
    {
        break;
    }
}

result = Math.Round(result, 3);
sw.WriteLine($"{result:0.00}");

int Find(int target)
{
    if (starParent[target] == target)
    {
        return target;
    }
    else
    {
        return Find(starParent[target]);
    }
}

void Union(int x, int y)
{
    var xParent = Find(x);
    var yParent = Find(y);

    if (xParent == yParent)
    {
        return;
    }

    if (xParent < yParent)
    {
        starParent[xParent] = yParent;
    }
    else if (xParent > yParent)
    {
        starParent[yParent] = xParent;
    }
}


sr.Close();
sw.Close();