var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var i = 0; i < T; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    var A = inputs[0];
    var B = inputs[1];
    Queue<(int value, List<char> answer)> q = new Queue<(int value, List<char> answer)>();
    q.Enqueue((A, new List<char>()));

    var result = new List<char>();
    var visited = new bool[10000];
    visited[A] = true;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        var value = current.value;
        var answer = current.answer;

        if (value == B)
        {
            result = answer;
            break;
        }

        var next_D = value * 2 % 10000;
        if (visited[next_D] == false)
        {
            var answer_D = answer.ToList();
            answer_D.Add('D');
            q.Enqueue((next_D, answer_D));
            visited[next_D] = true;
        }

        var next_S = value - 1;
        if (next_S < 0) next_S = 9999;
        if (visited[next_S] == false)
        {
            var answer_S = answer.ToList();
            answer_S.Add('S');
            q.Enqueue((next_S, answer_S));
            visited[next_S] = true;
        }

        var next_L = (value * 10) % 10000 + value / 1000;
        if (visited[next_L] == false)
        {
            var answer_L = answer.ToList();
            answer_L.Add('L');
            q.Enqueue((next_L, answer_L));
            visited[next_L] = true;
        }

        var next_R = value / 10 + value % 10 * 1000;
        if (visited[next_R] == false)
        {
            var answer_R = answer.ToList();
            answer_R.Add('R');
            q.Enqueue((next_R, answer_R));
            visited[next_L] = true;
        }
    }

    sw.WriteLine(new string(result.ToArray()));
}

sw.Close();
sr.Close();