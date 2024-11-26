using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class Bord
{
    private char[,] bord;

    public Bord()
    {
        bord = new char[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                bord[i, j] = ' ';
            }
        }
    }
    public char[,] CopyBord()
    {
        return bord;
    }
    public void PrintBord()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (j != 2)
                {
                    Console.Write(bord[i, j] + "|");
                }
                else
                {
                    Console.Write(bord[i, j]);
                }
            }
            Console.WriteLine();
            if (i != 2)
                Console.WriteLine("- - -");
        }
    }

    public char DiagonalCheck()
    {
        char center = bord[1, 1];
        if (center == bord[0, 0] && center == bord[2, 2] && center != ' ')
        {
            return center;
        }
        else if (center == bord[0, 2] && center == bord[2, 0] && center != ' ')
        {
            return center;
        }
        else
        {
            return 'N';
        }
    }

    public char RowCheck()
    {
        for (int i = 0; i < 3; i++)
        {
            int count = 0;
            char checker = bord[i, 0];
            for (int j = 0; j < 3; j++)
            {
                if (bord[i, j] == checker)
                {
                    count++;
                }
            }
            if (count == 3 && checker != ' ')
            {
                return checker;
            }
        }
        return 'N';
    }

    public char ColumnCheck()
    {
        for (int i = 0; i < 3; i++)
        {
            int count = 0;
            char checker = bord[0, i];
            for (int j = 0; j < 3; j++)
            {
                if (bord[j, i] == checker)
                {
                    count++;
                }
            }
            if (count == 3 && checker != ' ')
            {
                return checker;
            }
        }
        return 'N';
    }

    public char TieCheck()
    {
        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (bord[i, j] == ' ')
                {
                    counter++;
                }
            }
        }
        if (counter != 0)
        {
            return 'N';
        }
        else
        {
            return 'T';
        }
    }

    public char Checker()
    {
        char[] results = { ColumnCheck(), RowCheck(), DiagonalCheck(), TieCheck() };
        for (int i = 0; i < 4; i++)
        {
            if (results[i] != 'N')
            {
                return results[i];
            }
        }
        return 'N';
    }

    public bool SetChar(int row, int column, char symbol)
    {
        if (bord[row, column] != ' ')
        {
            return false;
        }
        else
        {
            bord[row, column] = symbol;
            return true;
        }
    }

    public void Hello(string arg)
    {
        Console.WriteLine(arg);
    }
    public void PestBord(char[,] bord)
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                this.bord[i, j] = bord[i, j];
            }
        }
    }
    public List<Tuple<int,int>> Empty()
    {
        List<Tuple<int,int>> Emp = new List<Tuple<int,int>>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (bord[i,j] == ' ')
                {
                    Emp.Add(new Tuple<int, int>(i,j));
                }
            }
        }
        return Emp;
    }
}
class ComputerAi
{
    public static char MySympol;
    public static char HumenSympol;
    public int Score;
    public char TheMoveTo;
    public Bord CuruntState;
    public List<ComputerAi> PusebelState;
    public ComputerAi(Bord copy)
    {
        Score =0;
        CuruntState = new Bord();
        CuruntState.PestBord(copy.CopyBord());
        PusebelState = new List<ComputerAi>();
    }
    public ComputerAi(Bord copy,int row ,int colmn,char MoveTo)
    {
        Score = 0;
        TheMoveTo = MoveTo;
        CuruntState = new Bord();
        CuruntState.PestBord(copy.CopyBord());
        CuruntState.SetChar(row, colmn, TheMoveTo);
        PusebelState = new List<ComputerAi>();
    }
    public int Bosepuletes()
    {
        List<Tuple<int, int>> Movs = CuruntState.Empty();
        foreach(Tuple<int, int> item in Movs)
        {
            char next;
            if(TheMoveTo == 'X')
            {
                next = 'O';
            }
            else
            {
                next = 'X';
            }
            ComputerAi puseble = new ComputerAi(CuruntState, item.Item1,item.Item2,next);
            PusebelState.Add(puseble);
            if(puseble.CuruntState.Checker() == 'N')
            {
               Score += puseble.Bosepuletes();
            }
            else if(puseble.CuruntState.Checker() == MySympol)
            {
                Score++;
                puseble.Score = 1;
            }
            else if(puseble.CuruntState.Checker() == HumenSympol)
            {
                Score--;
                puseble.Score = -1;
            }
        }
        return Score;
    }
    public void PrintBest()
    {
        int best = PusebelState.First().Score;
        ComputerAi computerAi = PusebelState.First();
        foreach(ComputerAi ai in PusebelState)
        {
            if (ai.Score > best)
            {
                best = ai.Score;
                computerAi = ai;
            }
        }
        computerAi.CuruntState.PrintBord();
        if (computerAi.PusebelState.Count > 0)
        {
            computerAi.PrintBest();
        }
    }
}

class Program
{
    static void Main()
    {
        Bord StartBord = new Bord();
        char Ai;
        char Humen;
        ComputerAi ai = new ComputerAi(StartBord);
        Console.Write("Enter you'r sympole X or O: ");
        Humen = char.Parse(Console.ReadLine().ToUpper());
        if (Humen == 'X')
        {
            Ai = 'O';
        }
        else
        {
            Ai = 'X';
        }
        Console.Write("Do you wont to start?[y/n]: ");
        char anser = char.Parse(Console.ReadLine().ToLower());
        if (anser == 'y')
        {
            ai.TheMoveTo = Ai;
            ComputerAi.MySympol = Ai;
            ComputerAi.HumenSympol = Humen;
            ai.Bosepuletes();
            Game(Humen, Ai, ai);
        }
        else
        {
            ai.TheMoveTo = Humen;
            ComputerAi.MySympol = Ai;
            ComputerAi.HumenSympol = Humen;
            ai.Bosepuletes();
            int best = ai.PusebelState.First().Score;
            ComputerAi computerAi = ai.PusebelState.First();
            foreach (ComputerAi ai0 in ai.PusebelState)
            {
                if (ai0.Score > best)
                {
                    best = ai0.Score;
                    computerAi = ai0;
                }
            }
            ai = computerAi;
            Game(Ai, Humen, ai);
        }
    }
    static bool Equal(char[,] a, char[,] b)
    {
        for(int i = 0; i < a.GetLength(0); i++)
        {
            for(int j = 0; j < b.GetLength(1); j++)
            {
                if (a[i,j] != b[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    static void Game(char now, char befor, ComputerAi ai)
    {
        Bord StartBord = new Bord();
        StartBord.PestBord(ai.CuruntState.CopyBord());
        char R = 'N';
        while (R == 'N')
        {
            Console.Clear();
            StartBord.PrintBord();
            int row = 0;
            int column = 0;
            Console.WriteLine("you'r turn");
            Console.Write("Enter Row: ");
            row = int.Parse(Console.ReadLine());
            Console.Write("Enter Column: ");
            column = int.Parse(Console.ReadLine());
            if(StartBord.SetChar(--row, --column, ComputerAi.HumenSympol))
            {
                if(StartBord.Checker() == 'N')
                {
                    foreach (ComputerAi ai0 in ai.PusebelState)
                    {
                        if (Equal(StartBord.CopyBord(), ai0.CuruntState.CopyBord()))
                        {
                            ai = ai0;
                            break;
                        }
                    }
                    int best = ai.PusebelState.First().Score;
                    bool dont = false;
                    ComputerAi computerAi = ai.PusebelState.First();
                    foreach (ComputerAi ai0 in ai.PusebelState)
                    {
                        if (ai0.Score == 1)
                        {
                            computerAi = ai0;
                            break;
                        }
                        if (ai0.Score > best)
                        {
                            foreach (ComputerAi ai1 in ai0.PusebelState)
                            {
                                if (ai1.Score == -1)
                                {
                                    dont = true;
                                    break;
                                }
                                else
                                {
                                    dont = false;
                                }
                            }
                            if (!dont)
                            {
                                best = ai0.Score;
                                computerAi = ai0;
                            }
                        }
                    }
                    ai = computerAi;
                    StartBord.PestBord(ai.CuruntState.CopyBord());
                }
            }
            else
            {
                Console.WriteLine("Invaled Entre!!!");
            }
            R = StartBord.Checker();
            if (R != 'N')
            {
                StartBord.PrintBord();
                Console.WriteLine($"Winner is {R}");
            }
        }
    }
}
