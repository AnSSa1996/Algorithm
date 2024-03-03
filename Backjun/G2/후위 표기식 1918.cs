using System.Text;

var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var input = sr.ReadLine();
var sb = new StringBuilder();
var stack = new Stack<char>();

foreach (var c in input)
{
    if (IsAlpha(c))
    {
        sb.Append(c);
    }
    else
    {
        if (c == '(') stack.Push(c);
        if (c == ')')
        {
            while (stack.Count > 0 && stack.Peek() != '(')
            {
                sb.Append(stack.Pop());
            }
            stack.Pop(); // '(' 제거
        }

        if (c == '*' || c == '/')
        {
            while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/'))
            {
                sb.Append(stack.Pop());
            }
            stack.Push(c);
        }

        if (c == '+' || c == '-')
        {
            while (stack.Count > 0 && stack.Peek() != '(')
            {
                sb.Append(stack.Pop());
            }

            stack.Push(c);
        }
    }
}

while (stack.Count > 0)
{
    sb.Append(stack.Pop());
}

sw.WriteLine(sb.ToString());
sw.Close();
sr.Close();


bool IsAlpha(char c)
{
    return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
}