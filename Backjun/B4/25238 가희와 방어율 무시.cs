var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
double a = inputs[0];
double b = inputs[1];

var result = a * (100 - b) * 0.01;
sw.WriteLine(result >= 100 ? 0 : 1);

sr.Close();
sw.Close();