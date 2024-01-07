StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());           // 추의 개수
var weights = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 추의 무게

var M = int.Parse(sr.ReadLine());           // 구슬의 개수
var balls = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);   // 구슬의 무게

var dp = new bool[N + 1, 40001];            // dp[i, j] = i번째 추까지 사용해서 j 무게를 만들 수 있는가?
var hashSet = new HashSet<int>();           // 가능한 무게의 집합


void DFS(int index, int weight)
{
    hashSet.Add(weight);
    if (index == N) return;
    if (dp[index, weight]) return;
    dp[index, weight] = true;
    DFS(index + 1, weight + weights[index]);
    DFS(index + 1, weight);
    DFS(index + 1, Math.Abs(weight - weights[index]));
}

DFS(0, 0);

var answer = new List<char>();
for (int i = 0; i < M; i++)
{
    if (hashSet.Contains(balls[i])) answer.Add('Y');
    else answer.Add('N');
}

sw.WriteLine(string.Join(" ", answer));
sw.Close();
sr.Close();