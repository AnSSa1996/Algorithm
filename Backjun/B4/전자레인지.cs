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

            int time = int.Parse(sr.ReadLine());

            int fiveMinute = time / 300;
            time -= fiveMinute * 300;
            int oneMinute = time / 60;
            time -= oneMinute * 60;
            int tenSecond = time / 10;
            time -= tenSecond * 10;

            if(time == 0)
            {
                sb.Append($"{fiveMinute} {oneMinute} {tenSecond}");
            }
            else
            {
                sb.Append(-1);
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
