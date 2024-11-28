using System.Numerics;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var K = inputs[1];
var numList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
numList.Sort((x, y) => y.CompareTo(x));

var result = numList[K - 1];
sw.WriteLine(result);


sr.Close();
sw.Close();