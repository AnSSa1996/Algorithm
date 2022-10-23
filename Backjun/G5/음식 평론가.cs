StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int LEFT = inputs[0];
int RIGHT = inputs[1];

int gcd = GCD(LEFT, RIGHT);
sw.WriteLine(RIGHT - gcd);

int GCD(int left, int right)
{
    if (left % right == 0) return right;
    return GCD(right, left % right);
}

sw.Flush();
sw.Close();
sr.Close();