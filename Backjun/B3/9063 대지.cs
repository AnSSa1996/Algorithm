var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var xList = new List<int>();
var yList = new List<int>();

for (var n = 0; n < N; n++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = inputs[0];
    var y = inputs[1];
    
    xList.Add(x);
    yList.Add(y);
}

var maxX = xList.Max();
var minX = xList.Min();

var maxY = yList.Max();
var minY = yList.Min();

var diffX = maxX - minX;
var diffY = maxY - minY;

var result = diffX * diffY;
sw.WriteLine(result);

sr.Close();
sw.Close();