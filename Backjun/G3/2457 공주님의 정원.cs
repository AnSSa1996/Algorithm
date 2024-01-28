var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());        // 꽃들의 개수

var flowers = new List<Flower>();
for (var i = 0; i < N; i++)
{
    var input = sr.ReadLine().Split();
    var startMonth = int.Parse(input[0]);
    var startDay = int.Parse(input[1]);
    var endMonth = int.Parse(input[2]);
    var endDay = int.Parse(input[3]);
    
    var start = startMonth * 100 + startDay;
    var end = endMonth * 100 + endDay;
    
    flowers.Add(new Flower(start, end));
}

flowers.Sort((a, b) => a.StartDay.CompareTo(b.StartDay));
var currentDay = 301;
var result = 0;

while (currentDay < 1201)
{
    var temp = currentDay;
    foreach (var flower in flowers)
    {
        if (flower.StartDay <= currentDay && temp < flower.EndDay)
        {
            temp = flower.EndDay;
        }
    }

    if (temp == currentDay)
    {
        result = 0;
        break;
    }
    currentDay = temp;
    result++;
}

sw.WriteLine(result);
sw.Close();
sr.Close();

class Flower
{
    public int StartDay { get; set; }
    public int EndDay { get; set; }
    
    public Flower(int startDay, int endDay)
    {
        StartDay = startDay;
        EndDay = endDay;
    }
}