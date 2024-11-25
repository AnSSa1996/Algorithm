var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var X = inputs[1];
var K = inputs[2];

var balls = new Pos[N + 1];
for (var i = 1; i <= N; i++)
{
    balls[i] = new Pos();
}

balls[X].isBall = true;

for (var k = 0; k < K; k++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    
    var left = inputs[0];
    var right = inputs[1];
    
    (balls[left], balls[right]) = (balls[right], balls[left]);
}

for (var i = 1; i <= N; i++)
{
    if (balls[i].isBall)
    {
        sw.WriteLine(i);
        break;
    }
}


sr.Close();
sw.Close();


public class Pos
{
    public bool isBall = false;
}