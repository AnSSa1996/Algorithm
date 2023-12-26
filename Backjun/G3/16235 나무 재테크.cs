var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];      // 땅의 크기
var M = inputs[1];      // 나무의 수
var K = inputs[2];      // K년 후

var WinterNutrient = new int[N, N];  // 겨울에 추가되는 양분
var land = new Land[N, N];  // 땅

// 겨울에 추가되는 양분
for (var i = 0; i < N; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    for (var j = 0; j < N; j++)
    {
        WinterNutrient[i, j] = inputs[j];
    }
}

// 땅 초기화
for (var i = 0; i < N; i++)
{
    for (var j = 0; j < N; j++)
    {
        // 가장 처음엔 영영가 5가 들어있습니다.
        land[i, j] = new Land { Nutrient = 5, Trees = new List<Tree>() };
    }
}

// 나무 심기

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var x = inputs[0] - 1;
    var y = inputs[1] - 1;
    var age = inputs[2];
    land[x, y].Trees.Add(new Tree { Age = age, isAlive = true });
}

// K년 동안 반복
for (var i = 0; i < K; i++)
{
    Spring();
    Summer();
    Fall();
    Winter();
}

// 살아있는 나무의 수
var answer = 0;
for (var i = 0; i < N; i++)
{
    for (var j = 0; j < N; j++)
    {
        answer += land[i, j].Trees.Count;
    }
}

sw.WriteLine(answer);

// 봄
void Spring()
{
    for (var i = 0; i < N; i++)
    {
        for (var j = 0; j < N; j++)
        {
            var trees = land[i, j].Trees;
            trees.Sort((a, b) => a.Age.CompareTo(b.Age));
            for (var k = 0; k < trees.Count; k++)
            {
                var tree = trees[k];
                if (tree.isAlive == false) continue;
                if (land[i, j].Nutrient >= tree.Age)
                {
                    land[i, j].Nutrient -= tree.Age;
                    tree.Age++;
                }
                else
                {
                    tree.isAlive = false;
                }
            }
        }
    }
}

// 여름
void Summer()
{
    for (var i = 0; i < N; i++)
    {
        for (var j = 0; j < N; j++)
        {
            var trees = land[i, j].Trees;
            for (var k = 0; k < trees.Count; k++)
            {
                var tree = trees[k];
                if (tree.isAlive) continue;
                land[i, j].Nutrient += tree.Age / 2;
                trees.RemoveAt(k);
                k--;
            }
        }
    }
}

// 가을
void Fall()
{
    var dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
    var dy = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
    for (var i = 0; i < N; i++)
    {
        for (var j = 0; j < N; j++)
        {
            var trees = land[i, j].Trees;
            for (var k = 0; k < trees.Count; k++)
            {
                var tree = trees[k];
                if (tree.isAlive == false) continue;
                if (tree.Age % 5 != 0) continue;
                    for (var l = 0; l < 8; l++)
                    {
                        var nx = i + dx[l];
                        var ny = j + dy[l];
                        if (nx < 0 || nx >= N || ny < 0 || ny >= N) continue;
                        land[nx, ny].Trees.Add(new Tree { Age = 1, isAlive = true });
                    }
            }
        }
    }
}

// 겨울
void Winter()
{
    for (var i = 0; i < N; i++)
    {
        for (var j = 0; j < N; j++)
        {
            land[i, j].Nutrient += WinterNutrient[i, j];
        }
    }
}


sr.Close();
sw.Close();

public class Tree
{
    public int Age { get; set; }
    public bool isAlive { get; set; }
}

public class Land
{
    public int Nutrient { get; set; }
    public List<Tree> Trees { get; set; }
}