var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var stack = new Stack<int>();

var N = int.Parse(sr.ReadLine());

for (var n = 0; n < N; n++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var command = inputs[0];

    switch (command)
    {
        case 1:
        {
            var num = inputs[1];
            stack.Push(num);
            break;
        }
        case 2 when stack.Count == 0:
            sw.WriteLine(-1);
            break;
        case 2:
            sw.WriteLine(stack.Pop());
            break;
        case 3:
            sw.WriteLine(stack.Count);
            break;
        case 4:
            sw.WriteLine(stack.Count == 0 ? 1 : 0);
            break;
        case 5 when stack.Count == 0:
            sw.WriteLine(-1);
            break;
        case 5:
            sw.WriteLine(stack.Peek());
            break;
    }
}

sw.Close();
sr.Close();