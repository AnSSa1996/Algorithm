var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var Q = inputs[1];

var fenwickTree = new FenwickTree(N);

for (var q = 0; q < Q; q++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var type = inputs[0];
    var a = inputs[1];
    var b = inputs[2];

    if (type == 1)
    {
        fenwickTree.Update(a, b);
    }

    if (type == 2)
    {
        var answer = fenwickTree.RangeSum(a, b);
        sw.WriteLine(answer);
    }
}

sw.Close();
sr.Close();

public class FenwickTree
{
    private long[] tree;
    private int size;
    
    public FenwickTree(int n)
    {
        size = n;
        tree = new long[n + 1];
    }
    
    public void Update(int index, long diff)
    {
        while(index <= size)
        {
            tree[index] += diff;
            index += (index & -index);
        }
    }
    
    public long PrefixSum(int index)
    {
        long result = 0;
        while(index > 0)
        {
            result += tree[index];
            index -= (index & -index);
        }
        return result;
    }
    
    public long RangeSum(int start, int end)
    {
        return PrefixSum(end) - PrefixSum(start - 1);
    }
}