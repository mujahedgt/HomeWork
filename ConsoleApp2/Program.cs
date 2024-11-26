using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] a = { 1, 5, 43, 4, 10, 3, 2 ,6,7,20,30,90,-1};
        List<Tuple<int, int>> arras = new List<Tuple<int, int>>();
        arras.Add(new Tuple<int, int>(0, a.Length - 1));
        while (arras.Count > 0)
        {
            Tuple<int, int> m = arras[arras.Count - 1];
            arras.RemoveAt(arras.Count - 1);
            int q = Partition(a, m.Item1, m.Item2);
            if (q + 1 <= m.Item2) 
            {
                arras.Add(new Tuple<int, int>(q + 1, m.Item2));
            }
            if (q - 1 >= m.Item1) 
            {
                arras.Add(new Tuple<int, int>(m.Item1, q - 1));
            }
        }
        Print(a);
    }
    static void Print(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            string s = ",";
            if (a.Length - 1 == i)
                s = "";
            Console.Write(a[i]+s);
        }
        Console.WriteLine();
    }
    static int Partition(int[] A, int low, int high)
    {
        int pivot = A[low];
        int leftwall = low;
        for (int i = low + 1; i <= high; i++)
        {
            if (A[i] < pivot)
            {
                leftwall++;
                int temp = A[i];
                A[i] = A[leftwall];
                A[leftwall] = temp;
            }
        }
        int temp0 = A[low];
        A[low] = A[leftwall];
        A[leftwall] = temp0;
        return leftwall;
    }
}
