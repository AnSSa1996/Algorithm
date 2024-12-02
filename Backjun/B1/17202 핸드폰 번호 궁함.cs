var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var firstPhone = sr.ReadLine();
var secondPhone = sr.ReadLine();
var phoneNumber = new char[firstPhone.Length + secondPhone.Length];

for(var index = 0; index < firstPhone.Length; index++)
{
    phoneNumber[index * 2] = firstPhone[index];
    phoneNumber[index * 2 + 1] = secondPhone[index];
}

while (true)
{
    var nextPhoneNumber = new char[phoneNumber.Length - 1];
    for (var index = 0; index < phoneNumber.Length - 1; index++)
    {
        nextPhoneNumber[index] = (char)(((phoneNumber[index] - '0' + phoneNumber[index + 1] - '0') % 10) + '0');
    }
    
    phoneNumber = nextPhoneNumber;
    if (nextPhoneNumber.Length == 2) break;
}

sw.WriteLine(phoneNumber[0] + "" + phoneNumber[1]);

sr.Close();
sw.Close();