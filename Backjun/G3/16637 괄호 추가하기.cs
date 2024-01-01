var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());       // 수식의 길이
var expression = sr.ReadLine();      // 수식
var answer = long.MinValue;

Solve(1, expression[0] - '0');
void Solve(int index, long current)
{
    if (index >= N)
    {
        answer = Math.Max(answer, current);
        return;
    }
    
    var currentChar = expression[index];
    var next = expression[index + 1] - '0';
    
    Solve(index + 2, Calculate(current, next, currentChar));        // 괄호를 치지 않는 경우
    if (index + 3 < N)
    {
        var nextChar = expression[index + 2];
        var nextNext = expression[index + 3] - '0';
        Solve(index + 4, Calculate(current, Calculate(next, nextNext, nextChar), currentChar)); // 괄호를 치는 경우
    }
}

long Calculate(long current, long next, char op)
{
    switch (op)
    {
        case '+': return current + next;
        case '-': return current - next;
        case '*': return current * next;
    }

    return current;
}

sw.WriteLine(answer);
sr.Close();
sw.Close();