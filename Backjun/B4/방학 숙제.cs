using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int vacation = int.Parse(sr.ReadLine());
            int mathPage = int.Parse(sr.ReadLine());
            int koreanPage = int.Parse(sr.ReadLine());
            int canMath = int.Parse(sr.ReadLine());
            int canKorean = int.Parse(sr.ReadLine());

            int math = (mathPage + canMath - 1) / canMath;
            int korean = (koreanPage + canKorean - 1) / canKorean;

            int maxNum = Math.Max(math, korean);
            int result = vacation - maxNum;
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
