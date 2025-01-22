var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var result = (int)Math.Sqrt(N);
sw.WriteLine(result);
sw.Close();
sr.Close();