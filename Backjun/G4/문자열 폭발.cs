var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var firstString = sr.ReadLine();
var boomString = sr.ReadLine();

var answerLst = new List<char>();

for (var index = 0; index < firstString.Length; index++)
{
    answerLst.Add(firstString[index]);

    while (true)
    {
        if (answerLst.Count() < boomString.Length) break;
        if (answerLst.Last() != boomString.Last()) break;

        var str = new string(answerLst.GetRange(answerLst.Count - boomString.Length, boomString.Length).ToArray());
        if (str == boomString)
        {
            answerLst.RemoveRange(answerLst.Count - boomString.Length, boomString.Length);
        }
        else
        {
            break;
        }
    }
}

sw.WriteLine(answerLst.Count > 0 ? new string(answerLst.ToArray()) : "FRULA");

sw.Close();
sr.Close();