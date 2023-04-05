using System.Collections;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var str = sr.ReadLine();
var length = str.Length;

var stack = new Stack<char>();
for (var index = 0; index < length; index++)
{
    var current = str[index];
    stack.Push(current);

    if (stack.Count < 4) continue;
    var currentStr = new string(stack.Take(4).Reverse().ToArray());
    if (currentStr != "PPAP") continue;
    for (var i = 0; i < 3; i++) stack.Pop();
}

var isPPAP = new string(stack.Reverse().ToArray()) == "PPAP";
var isP = stack.Count == 1 && stack.Peek() == 'P';
if(isPPAP || isP) sw.WriteLine("PPAP");
else sw.WriteLine("NP");


sw.Flush();
sw.Close();
sr.Close();