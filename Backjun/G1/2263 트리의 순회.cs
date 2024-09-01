var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var inOrder = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var postOrder = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var inOrderIndex = new int[N + 1];

for (var i = 0; i < N; i++)
{
    inOrderIndex[inOrder[i]] = i;
}

var root = BuildTree(0, N - 1, 0, N - 1);
PreOrder(root);

sr.Close();
sw.Close();

TreeNode BuildTree(int inStart, int inEnd, int postStart, int postEnd)
{
    if (postStart > postEnd)
    {
        return null;
    }

    var rootValue = postOrder[postEnd];
    var root = new TreeNode(rootValue);
    var rootIndex = inOrderIndex[rootValue];
    var leftCount = rootIndex - inStart;
    root.Left = BuildTree(inStart, rootIndex - 1, postStart, postStart + leftCount - 1);
    root.Right = BuildTree(rootIndex + 1, inEnd, postStart + leftCount, postEnd - 1);
    return root;
}

void PreOrder(TreeNode node)
{
    if (node == null)
    {
        return;
    }

    sw.Write(node.Value + " ");
    PreOrder(node.Left);
    PreOrder(node.Right);
}

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;
    public TreeNode(int value)
    {
        Value = value;
    }
}