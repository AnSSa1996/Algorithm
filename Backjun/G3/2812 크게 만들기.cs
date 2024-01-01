var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];          // 숫자의 개수
var K = inputs[1];          // 뺄 수 있는 횟수

var numbers = Array.ConvertAll(sr.ReadLine().ToCharArray(), c => int.Parse(c.ToString()));
var stack = new Stack<int>();

for (var i = 0; i < N; i++)
{
    // 스택에 있는 숫자보다 다음 숫자가 크면 스택에서 제거
    while (stack.Count > 0 && K > 0 && stack.Peek() < numbers[i])
    {
        stack.Pop();
        K--;
    }

    stack.Push(numbers[i]);
}

while (K > 0)
{
    stack.Pop();
    K--;
}

var result = stack.Reverse().ToArray();
sw.WriteLine(string.Join("", result));
sr.Close();
sw.Close();