var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var gradeDict = new Dictionary<string, double>()
{
    { "A+", 4.5d }, { "A0", 4.0d }, { "B+", 3.5d }, { "B0", 3.0d }, { "C+", 2.5d }, { "C0", 2.0d }, { "D+", 1.5d }, { "D0", 1.0d }, { "F", 0.0d }
};

var totalScore = 0d;
var totalGrade = 0d;

for (var i = 0; i < 20; i++)
{
    var inputs = sr.ReadLine().Split();
    var subject = inputs[0];
    var credit = double.Parse(inputs[1]);
    var grade = inputs[2];

    if (grade == "P")
    {
        continue;
    }
    
    totalScore += credit * gradeDict[grade];
    totalGrade += credit;
}

var result = totalScore / totalGrade;
sw.WriteLine($"{result:F6}");

sw.Close();
sr.Close();