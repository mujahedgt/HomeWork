using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Schema;

class Solution
{

    public static int Main()
    {
        Console.WriteLine("enter h: ");
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine("enter W: ");
        double w= double.Parse(Console.ReadLine());
        rectangil my = new rectangil();
        my.Hait = h;
        my.Wedth = w;
        Console.WriteLine(my.GetArea());
        Console.WriteLine(my.GetP());

        return 0;
    }
}

class rectangil
{
    public double Hait, Wedth;
    public double  GetArea()
    {
        return (Hait * Wedth);
    }
    public double GetP()
    {
        return (Hait * 2 + Wedth * 2);
    }

}
class Coin 
{
    public rectangil(double hait, double wedth)
    {
        Hait = hait;
        Wedth = wedth;
    }
    private string Side;
    public int Flip()
    {
        Random random = new Random();
        int f = random.Next(0, 2);
        if (f == 1)
        {
            Console.Write("Head\t");
            Side = "Head";
            return 1;
        }else 
        {
            Console.Write("Tail\t");
            Side = "Tail";
            return 0;
        }
    }
}
//Coin coin = new Coin();
//int Heads = 0, Tails = 0;
//Console.ForegroundColor = ConsoleColor.Red;
//for (int i = 0; i < 100; i++)
//{
//    int conter = coin.Flip();
//    if (conter == 0)
//        Tails++;
//    if (conter == 1)
//        Heads++;
//}
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("\n {0} Heads and {1} Tails appears", Heads, Tails);
