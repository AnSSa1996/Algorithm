using System.Numerics;
using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var inputs = sr.ReadLine().Split();

    var A = inputs[0];
    var B = inputs[1];

    var numA = BinaryStringToBigInteger(A);
    var numB = BinaryStringToBigInteger(B);

    var result = numA + numB;
    sw.WriteLine(BigIntegerToBinaryString(result));
}

sw.Close();
sr.Close();

BigInteger BinaryStringToBigInteger(string binary)
{
    BigInteger result = 0;
    foreach (var c in binary)
    {
        result <<= 1;
        if (c == '1')
        {
            result += 1;
        }
    }

    return result;
}

string BigIntegerToBinaryString(BigInteger number)
{
    if (number == 0) return "0";
    var binary = new StringBuilder();
    while (number > 0)
    {
        binary.Insert(0, number % 2);
        number >>= 1;
    }

    return binary.ToString();
}