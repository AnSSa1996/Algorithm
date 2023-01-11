var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var K = inputs[0];
var C = inputs[1];
var requirementChar = new char[5] { 'a', 'n', 't', 'i', 'c' };
var charArray = new bool[26];
foreach (var c in requirementChar)
{
    var current = c - 'a';
    charArray[current] = true;
}

var lst = new List<string>();
for (var i = 0; i < K; i++)
{
    var str = sr.ReadLine();
    str = str.Substring(4, str.Length - 8);
    lst.Add(str);
}

var answer = 0;

void DFS(int charIndex, int count)
{
    if (count == C)
    {
        var currentCount = 0;
        foreach (var word in lst)
        {
            var check = true;
            foreach (var currentChar in word)
            {
                var index = currentChar - 'a';
                if (charArray[index]) continue;
                check = false;
                break;
            }

            if (check) currentCount++;
        }

        answer = Math.Max(currentCount, answer);
        return;
    }

    for (var index = charIndex + 1; index < 26; index++)
    {
        if (charArray[index]) continue;
        charArray[index] = true;
        DFS(index, count + 1);
        charArray[index] = false;
    }
}

switch (C)
{
    case < 5:
        sw.WriteLine(0);
        break;
    case 26:
        sw.WriteLine(K);
        break;
    default:
        DFS(0, 5);
        sw.WriteLine(answer);
        break;
}


sr.Close();
sw.Close();