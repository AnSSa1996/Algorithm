var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());   // 두 배열의 합

var N = int.Parse(sr.ReadLine());   // 배열의 크기
var A = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 배열 A

var M = int.Parse(sr.ReadLine());   // 배열의 크기
var B = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 배열 B

var subA = new List<long>();  
var subB = new List<long>();

for (int i = 0; i < N; i++)
{
    long sum = 0;
    for (int j = i; j < N; j++)
    {
        sum += A[j];
        subA.Add(sum);
    }
}

for (int i = 0; i < M; i++)
{
    long sum = 0;
    for (int j = i; j < M; j++)
    {
        sum += B[j];
        subB.Add(sum);
    }
}

subA.Sort();
subB.Sort();

long count = 0;

foreach (var currentA in subA)
{
    var target = T - currentA;
    var upperBound = UpperBound(subB, target);
    var lowerBound = LowerBound(subB, target);
    count += upperBound - lowerBound;
}

int UpperBound(List<long> list, long target)
{
    int left = 0;
    int right = list.Count;

    while (left < right)
    {
        int mid = (left + right) / 2;

        if (list[mid] <= target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }

    return right;
}

int LowerBound(List<long> list, long target)
{
    int left = 0;
    int right = list.Count;

    while (left < right)
    {
        int mid = (left + right) / 2;

        if (list[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }

    return right;
}

sw.WriteLine(count);
sr.Close();
sw.Close();