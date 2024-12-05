var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var numList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
numList.Sort();

var sum = numList[0] + numList[1];
if (sum > numList[2])
{
    sw.WriteLine(numList.Sum());
}
else
{
    sw.WriteLine(sum * 2 - 1);
}

sr.Close();
sw.Close();