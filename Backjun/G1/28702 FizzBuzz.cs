var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var n = 0;
for (var i = 3; i > 0; i--)
{
    var input = sr.ReadLine();
    if(input != "Fizz" && input != "Buzz" && input != "FizzBuzz")
    {
        n = int.Parse(input) + i;
    }
}

if (n % 3 == 0 && n % 5 == 0)
{
    sw.WriteLine("FizzBuzz");
}
else if (n % 3 == 0)
{
    sw.WriteLine("Fizz");
}
else if (n % 5 == 0)
{
    sw.WriteLine("Buzz");
}
else
{
    sw.WriteLine(n);
}


sr.Close();
sw.Close();