using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var diff = int.Parse(sr.ReadLine());

var left = 1;
var right = 1;

var sb = new StringBuilder();
while (left + right <= diff)
{
    var value = right * right - left * left;
    if (value > diff)
    {
        left++;
    }
    else if (value < diff)
    {
        right++;
    }
    else
    {
        sb.AppendLine(right.ToString());
        right++;
    }
}

if (sb.Length > 1) sw.Write(sb);
else sw.WriteLine(-1);

sr.Close();
sw.Close();