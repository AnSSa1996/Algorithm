var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());


var A = sr.ReadLine();
var B = sr.ReadLine();
var C = sr.ReadLine();

var intResult = (int.Parse(A) + int.Parse(B) - int.Parse(C));
var strResult = (int.Parse(A + B) - int.Parse(C));

sw.WriteLine(intResult);
sw.WriteLine(strResult);

sw.Close();
sr.Close();