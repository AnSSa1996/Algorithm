var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var preOrderArray = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
    var inOrderArray = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);

    var preIndex = 0;
    PostOrder(preOrderArray, inOrderArray, 0, N - 1, ref preIndex);
    sw.WriteLine();
}

sw.Flush();
sw.Close();

void PostOrder(int[] preOrderArray, int[] inOrderArray, int start, int end, ref int preIndex)
{
    if (start > end) return;
    var root = preOrderArray[preIndex++];
    var mid = Array.IndexOf(inOrderArray, root);
    PostOrder(preOrderArray, inOrderArray, start, mid - 1, ref preIndex);
    PostOrder(preOrderArray, inOrderArray, mid + 1, end, ref preIndex);
    sw.Write(root + " ");
}