var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());
var str = sr.ReadLine();
var length = str.Length;
var palindrome = new bool[length, length];
var dp = new int[length];

for (var i = 0; i < length; i++)
{
    dp[i] = int.MaxValue;
}

for (var end = 0; end < length; end++)
{
    for (var start = 0; start <= end; start++)
    {
        if (str[start] == str[end] && (end - start <= 2 || palindrome[start + 1, end - 1]))
        {
            palindrome[start, end] = true;
            
            if (start == 0)
            {
                dp[end] = 1;
            }
            else
            {
                dp[end] = Math.Min(dp[end], dp[start - 1] + 1);
            }
        }
    }
}

sw.WriteLine(dp[length - 1]);

sr.Close();
sw.Close();