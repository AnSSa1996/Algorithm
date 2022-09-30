using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int count = inputs[0]; int charLength = inputs[1];
            char[] characters = Array.ConvertAll(sr.ReadLine().Split(), char.Parse);
            Array.Sort(characters);
            List<char> moum = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            List<char> charList = new List<char>();

            DFS(0, 0, 0, 0);

            void DFS(int index, int c, int mo, int ja)
            {
                if (c == count && mo >= 1 && ja >= 2)
                {
                    sw.WriteLine(new string(charList.ToArray()));
                    return;
                }

                for (int current = index; current < charLength; current++)
                {
                    char currentChar = characters[current];
                    int currentMo = mo;
                    int currentJa = ja;
                    if (moum.Contains(currentChar)) currentMo++;
                    else currentJa++;
                    charList.Add(currentChar);
                    DFS(current + 1, c + 1, currentMo, currentJa);
                    charList.RemoveAt(charList.Count() - 1);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}