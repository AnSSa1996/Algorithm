using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;
using Microsoft.VisualBasic;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var nums = new int[N + 1];
var rank = new int[N + 1];
for (var i = 0; i <= N; i++)
{
    nums[i] = i;
}

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var check = inputs[0];
    var left = inputs[1];
    var right = inputs[2];

    if (check == 0)
    {
        Union(left,right);
    }
    else
    {
        sw.WriteLine(Find(left) == Find(right) ? "YES" : "NO");
    }
}

int Find(int x)
{
    if (nums[x] == x) return x;
    else return Find(nums[x]);
}

void Union(int left, int right)
{
    left = Find(left);
    right = Find(right);
    
    if(left==right) return;

    // 항상 랭크가 낮은 쪽에 갱신한다.
    if (rank[left] < rank[right])
    {
        nums[left] = right;
    }
    else
    {
        nums[right] = left;
    }
    // 꼬리가 같다면, 왼쪽의 랭크를 우선 상승 시킨다. 다음 꼬리는 오른쪽에 붙도록
    if (rank[left] == rank[right]) rank[left]++;
}

sw.Flush();
sr.Close();
sw.Close();