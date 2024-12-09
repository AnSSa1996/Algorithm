var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var count = 0;

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    count = 0;
    var s = sr.ReadLine();
    var result = isPalindrome(s);
    sw.WriteLine($"{result} {count}");
}

sr.Close();
sw.Close();

int recursion(string s, int left, int right)
{
    count++;
    if (left >= right) return 1;
    if (s[left] != s[right]) return 0;
    return recursion(s, left + 1, right - 1);
}

int isPalindrome(string s)
{
    return recursion(s, 0, s.Length - 1);
}