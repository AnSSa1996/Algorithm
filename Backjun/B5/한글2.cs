using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            var inputUnicode = Console.Read(); // 유니코드의 경우, 표준 입력으로 읽어올 수 없다. 주의
            sw.WriteLine($"{inputUnicode -'가' + 1}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
