var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = new string[N];
var alphabet = new Dictionary<char, int>();

for (var i = 0; i < N; i++)
{
    var str = sr.ReadLine();
    nums[i] = str;
    var weight = str.Length;
    for (var j = 0; j < str.Length; j++)
    {
        var currentChar = str[j];
        var currentWeight = weight - j;
        if (alphabet.ContainsKey(currentChar))
        {
            alphabet[currentChar] += (int)Math.Pow(10, currentWeight);
        }
        else
        {
            alphabet.Add(currentChar, (int)Math.Pow(10, currentWeight));
        }
    }
}

var items = from pair in alphabet
    orderby pair.Value descending
    select pair;

var count = 9;
foreach (var pair in items)
{
    alphabet[pair.Key] = count--;
}

var sum = 0;
foreach (var num in nums)
{
    var legnth = num.Length;
    for (var index = 0; index < num.Length; index++)
    {
        var n = alphabet[num[index]];
        var multiple = (int)Math.Pow(10, legnth - index - 1);
        sum += n * multiple;
    }
}

sw.WriteLine(sum);

sw.Close();
sr.Close();