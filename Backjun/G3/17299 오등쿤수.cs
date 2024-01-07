var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine()); // 수열 A의 크기
var A = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse); // 수열 A

var NGF = new int[N];
for (var index = 0; index < N; index++)
{
    NGF[index] = -1;
}

var countDict = new Dictionary<int, int>();
for (var index = 0; index < N; index++)
{
    if (countDict.ContainsKey(A[index]))
    {
        countDict[A[index]]++;
    }
    else
    {
        countDict.Add(A[index], 1);
    }
}

var stack = new Stack<int>();

for (var index = 0; index < N; index++)
{
    while (stack.Count > 0 && countDict[A[stack.Peek()]] < countDict[A[index]])
    {
        NGF[stack.Pop()] = A[index];
    }

    stack.Push(index);
}

sw.WriteLine(string.Join(" ", NGF[0..]));
sr.Close();
sw.Close();