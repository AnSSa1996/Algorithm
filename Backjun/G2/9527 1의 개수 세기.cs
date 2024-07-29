using System.Numerics;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
var A = inputs[0];
var B = inputs[1];

var countB = CountOnes(B);
var countA = CountOnes(A - 1);

sw.WriteLine(countB - countA);

sw.Flush();
sw.Close();
sr.Close();

BigInteger CountOnes(BigInteger n)
{
    BigInteger count = 0;
    for(var i = 0; i < 64; i++)
    {
        BigInteger pow = BigInteger.Pow(2, i);
        BigInteger pairs = (n + 1) / pow;
        count += (pairs / 2) * pow;
        BigInteger remain = (n + 1) % pow;
        
        if(remain > pow / 2)
        {
            count += remain - pow / 2;
        }
    }
    return count;
}