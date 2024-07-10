var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = sr.ReadLine().Split();
var N = inputs[0].ToCharArray();
var K = int.Parse(inputs[1]); // 교체 횟수

var hashSet = new HashSet<string>();
var max = -1;

DFS(0);

void DFS(int count)
{
    if (count == K)
    {
        var num = int.Parse(new string(N));
        max = Math.Max(max, num);
        return;
    }

    for (var i = 0; i < N.Length - 1; i++)
    {
        for (var j = i + 1; j < N.Length; j++)
        {
            if (i == 0 && N[j] == '0')
            {
                continue;
            }
            Swap(ref N, i, j);
            var hashKey = new string(N) + count + 1;
            if (hashSet.Add(hashKey))
            {
                DFS(count + 1);
            }

            Swap(ref N, i, j);
        }
    }
}

sw.WriteLine(max);
sw.Flush();
sw.Close();
sr.Close();

void Swap(ref char[] charArray, int i, int j)
{
    (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
}