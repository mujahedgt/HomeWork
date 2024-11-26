using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
   
    internal class Program
    {
         static int conter = 0;
        static void Main()
        {
            char[] S = { 'a', 'b', 'c','d','e','f','g','h','i'};
            DateTime  dateTime = DateTime.Now;
            List<char> list = S.ToList();
            int t = list.Count;
            List<char> printuble = new List<char>();
            for(int i =0; i < t; i++)
            {
                printuble.Add(list[i]);
                list.RemoveAt(i);
                Recersev(ref printuble, ref list);
                list.Insert(i, printuble[0]);
                printuble.RemoveAt(printuble.Count-1);
            }
            Console.WriteLine(DateTime.Now -  dateTime);
            Console.WriteLine(conter);
        }
        static void Recersev(ref List<char> printuble,ref List<char> lift)
        {
            for (int i = 0; i < lift.Count; i++)
            {
                printuble.Add(lift[i]);
                lift.RemoveAt(i);
                if(lift.Count == 0)
                {
                    print(printuble.ToArray());
                    conter++;
                }
                else
                {
                    Recersev(ref printuble, ref lift);
                }
                lift.Insert(i, printuble[printuble.Count-1]);
                printuble.RemoveAt(printuble.Count - 1);

            }
        }
        static void Swap(ref char[] r)
        {
            char h = r[1];
            r[1] = r[2];
            r[2]= h;
        }
        static void print(char[] t)
        {
            for(int i = 0;i<t.Length;i++)
            {
                Console.Write(t[i]);
            }
            Console.WriteLine();
        }

    }
}

