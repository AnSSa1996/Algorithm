var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var str = sr.ReadLine();
var stack = new Stack<(int legnth, int prevNum)>();
var count = 0;
int prevNum = '0';
foreach (var c in str)
{
    if (c == '(')
    {
        stack.Push((count - 1, prevNum));
        count = 0;
    }
    else if (c == ')')
    {
        var current = stack.Pop();
        count = count * current.prevNum + current.legnth;
    }
    else
    {
        count += 1;
        prevNum = c - '0';
    }
}

sw.WriteLine(count);

sw.Close();
sr.Close();