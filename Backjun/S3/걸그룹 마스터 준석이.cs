using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            Dictionary<string, List<string>> dictMemeber = new Dictionary<string, List<string>>();
            Dictionary<string, string> dictTeamName = new Dictionary<string, string>();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int Team = inputs[0]; int Q = inputs[1];

            for (int i = 0; i < Team; i++)
            {
                string teamName = sr.ReadLine();
                int memberCount = int.Parse(sr.ReadLine());
                dictMemeber.Add(teamName, new List<string>());

                for (int j = 0; j < memberCount; j++)
                {
                    string name = sr.ReadLine();
                    dictMemeber[teamName].Add(name);
                    dictTeamName.Add(name, teamName);
                }

                dictMemeber[teamName].Sort();
            }

            for (int i = 0; i < Q; i++)
            {
                string question = sr.ReadLine();
                int kind = int.Parse(sr.ReadLine());
                if (kind == 1) sw.WriteLine(dictTeamName[question]);
                else
                {
                    foreach (var str in dictMemeber[question])
                    {
                        sw.WriteLine(str);
                    }
                }

            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
