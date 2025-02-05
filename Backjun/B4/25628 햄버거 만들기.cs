var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var breads = inputs[0] / 2;
var patties = inputs[1];

var result = Math.Min(breads, patties);

sw.WriteLine(result);
sw.Close();
sr.Close();