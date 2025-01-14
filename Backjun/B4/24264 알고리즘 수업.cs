var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = long.Parse(sr.ReadLine());
sw.WriteLine(N * N);
sw.WriteLine(2);

sw.Close();
sr.Close();