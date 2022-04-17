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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(sr.ReadLine());
            Deck d = new Deck(sw);
            for (int i = 0; i < N; i++)
            {
                string[] strs = sr.ReadLine().Split();
                d.Check(strs);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Deck
    {
        List<int> lst = new List<int>();
        StreamWriter sw = null;

        public Deck(StreamWriter SW) { sw = SW; }

        public void Check(string[] strs)
        {
            if (strs[0] == "push_front")
            {
                int num = int.Parse(strs[1]);
                PushFront(num);
            }
            else if (strs[0] == "push_back")
            {
                int num = int.Parse(strs[1]);
                PushBack(num);
            }
            else if (strs[0] == "pop_front") PopFront();
            else if (strs[0] == "pop_back") PopBack();
            else if (strs[0] == "size") Size();
            else if (strs[0] == "empty") Empty();
            else if (strs[0] == "front") Front();
            else if (strs[0] == "back") Back();
        }

        public void PushFront(int num) { lst.Insert(0, num); }
        public void PushBack(int num) { lst.Add(num); }
        public void PopFront()
        {
            if (lst.Count == 0) sw.WriteLine(-1);
            else
            {
                sw.WriteLine(lst[0]);
                lst.RemoveAt(0);
            }
        }
        public void PopBack()
        {
            if (lst.Count == 0) sw.WriteLine(-1);
            else
            {
                sw.WriteLine(lst.Last());
                lst.RemoveAt(lst.Count() - 1);
            }
        }

        public void Size() { sw.WriteLine(lst.Count()); }
        public void Empty()
        {
            if (lst.Count() == 0) sw.WriteLine(1);
            else sw.WriteLine(0);
        }
        public void Front()
        {
            if (lst.Count == 0) sw.WriteLine(-1);
            else sw.WriteLine(lst[0]);
        }

        public void Back()
        {
            if (lst.Count == 0) sw.WriteLine(-1);
            else sw.WriteLine(lst.Last());
        }
    }
}
