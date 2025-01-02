var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

sw.WriteLine(int.Parse(sr.ReadLine()));
sw.WriteLine(1);

sw.Close();
sr.Close();