using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<string> agents = new List<string>();

            for (int i = 0; i < 5; i++) agents.Add(sr.ReadLine());

            var fbiAgents = agents.Select((s, i) => new
            {
                name = s,
                index = i + 1
            }).Where(x => x.name.Contains("FBI")).Select(a => a.index).ToList();

            if (fbiAgents.Count == 0) sw.WriteLine("HE GOT AWAY!");
            else sw.WriteLine(string.Join(" ", fbiAgents));

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
