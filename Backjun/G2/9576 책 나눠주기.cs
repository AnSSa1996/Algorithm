var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var M = inputs[1];

    var books = new bool[N + 1];

    var peopleList = new List<(int start, int end)>();
    for (var i = 0; i < M; i++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        peopleList.Add((inputs[0], inputs[1]));
    }

    peopleList = peopleList.OrderBy(x => x.end).ThenBy(x => x.start).ToList();
    var cnt = 0;

    foreach (var people in peopleList)
    {
        for (var i = people.start; i <= people.end; i++)
        {
            if (books[i] == false)
            {
                books[i] = true;
                cnt++;
                break;
            }
        }
    }

    sw.WriteLine(cnt);
}


sw.Flush();
sw.Close();
sr.Close();