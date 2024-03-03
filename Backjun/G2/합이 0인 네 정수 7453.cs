var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());

var A = new int[N];
var B = new int[N];
var C = new int[N];
var D = new int[N];

for (var i = 0; i < N; i++)
{
    var input = sr.ReadLine().Split();
    A[i] = int.Parse(input[0]);
    B[i] = int.Parse(input[1]);
    C[i] = int.Parse(input[2]);
    D[i] = int.Parse(input[3]);
}

var AB = new long[N * N];
var CD = new long[N * N];

for (var i = 0; i < N; i++)
{
    for (var j = 0; j < N; j++)
    {
        AB[i * N + j] = A[i] + B[j];
        CD[i * N + j] = C[i] + D[j];
    }
}


Array.Sort(AB);
Array.Sort(CD);


var result = 0L;

var abIndex = 0L;
var cdIndex = N * N - 1L;

while (abIndex < N * N && cdIndex >= 0)
{
    var sum = AB[abIndex] + CD[cdIndex];

    if (sum < 0)
    {
        abIndex++;
        continue;
    }
    else if (sum > 0)
    {
        cdIndex--;
        continue;
    }
    else
    {
        var abCount = 1L;
        var cdCount = 1L;
        while (abIndex + abCount < N * N && AB[abIndex] == AB[abIndex + abCount])
        {
            abCount++;
        }

        while (cdIndex - cdCount >= 0 && CD[cdIndex] == CD[cdIndex - cdCount])
        {
            cdCount++;
        }

        result += abCount * cdCount;
        
        abIndex += abCount;
        cdIndex -= cdCount;
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();