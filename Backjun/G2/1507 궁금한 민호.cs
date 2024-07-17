var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var roads = new int[N, N];
var necessary = new bool[N,N];

for (var i = 0; i < N; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < N; j++)
    {
        roads[i, j] = input[j];
        necessary[i, j] = true;
    }
}


for (var k = 0; k < N; k++)
{
    for (var i = 0; i < N; i++)
    {
        for (var j = 0; j < N; j++)
        {
            if (i == j || i == k || j == k) continue;
            if (roads[i, j] == roads[i, k] + roads[k, j])
            {
                necessary[i, j] = false;
            }
            
            if (roads[i, j] > roads[i, k] + roads[k, j])
            {
                sw.WriteLine(-1);
                sw.Flush();
                sw.Close();
                sr.Close();
                return;
            }
        }
    }
}

var result = 0;

for (var i = 0; i < N; i++)
{
    for (var j = 0; j < i; j++)
    {
        if (necessary[i, j])
        {
            result += roads[i, j];
        }
    }
}

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();