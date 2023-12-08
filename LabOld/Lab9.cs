using System;
using System.Buffers;
using System.Buffers.Binary;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;

class Set
{
    int Count;
    int[] Elements;
    public Set()
    {
        int ElementSize = Convert.ToInt32(Console.ReadLine());
        this.Count = ElementSize;
        this.Elements = new int[ElementSize];
        Fill(ElementSize);
    }
    public Set(int[] ElemArray)
    {
        this.Count = ElemArray.Length;
        this.Elements = ElemArray;
    }
    public void Fill(int elemcount)
    {
        for (int a = 0; a < elemcount; a++)
        {
            string input = Console.ReadLine();
            int insp = Convert.ToInt32(input);
            Elements[a] = insp;
        }
    }
    public int IndexOf(int Value)
    {
        for (int a = 0; a < Elements.Length; a++)
        {
            if (Elements[a] == Value)
            {
                return a;
            }
        }
        return -1;
    }

    public void Add(int NewElement)
    {
        Array.Resize(ref Elements, Elements.Length + 1);
        int LastEl = Elements.Length - 1;
        Elements[LastEl] = NewElement;
    }

    public void ShowSet()
    {
        Console.WriteLine("Вывод множества:");
        for (int a = 0; a < Elements.Length; a++)
        {
            Console.Write(Elements[a]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static Set operator ++(Set set)
    {
        Set newset = set;
        int[] Elements = newset.Elements;
        for (int a = 0; a < Elements.Length; a++)
        {
            int tmp = Elements[a];
            tmp += 1;
            Elements[a] = tmp;
        }
        return newset;
    }

    public static Set operator +(Set set1, Set set2)
    {
        Set newset = set1;
        int[] Elements = set2.Elements;
        for (int a = 0; a < Elements.Length; a++)
        {
            newset.Add(Elements[a]);
        }
        return newset;
    }

    public static Set operator *(Set set1, Set set2)
    {
        int[] Result = new int[] { 999999999 };
        int[] Elements1 = set1.Elements;
        int[] Elements2 = set2.Elements;
        int[] Elements3 = set2.Elements;
        if (Elements2.Length > Elements1.Length)
        {
            Elements2 = Elements1;
            Elements1 = Elements3;
        }
        else
        {
            Console.WriteLine("Placeholder");
        }
        for (int a = 0; a < Elements1.Length; a++)
        {
            for (int b = 0; b < Elements2.Length; b++)
            {
                if (Elements1[a] == Elements2[b])
                {
                    bool Cont1 = Result.Contains(Elements1[a]);
                    if (Cont1 is false)
                    {
                        Array.Resize(ref Result, Result.Length + 1);
                        Result[Result.Length - 1] = Elements1[a];
                    }
                }
            }
        }
        Result = Result.Where(val => val != 999999999).ToArray();
        Set Set3 = new Set(Result);
        return Set3;
    }

    public static Set operator /(Set set1, Set set2)
    {
        int[] Result = new int[] { 999999999 };
        int[] Result2 = Result;
        int[] Elements1 = set1.Elements;
        int[] Elements2 = set2.Elements;
        int[] Elements3 = set2.Elements;
        if (Elements2.Length > Elements1.Length)
        {
            Elements2 = Elements1;
            Elements1 = Elements3;
        }
        else
        {
            Console.WriteLine("Placeholder");
        }
        for (int a = 0; a < Elements1.Length; a++)
        {
            for (int b = 0; b < Elements2.Length; b++)
            {
                if (Elements1[a] == Elements2[b])
                {
                    bool Cont1 = Result.Contains(Elements1[a]);
                    if (Cont1 is false)
                    {
                        Array.Resize(ref Result, Result.Length + 1);
                        Result[Result.Length - 1] = Elements1[a];
                    }
                }
            }
        }
        Result = Result.Where(val => val != 999999999).ToArray();
        for (int a = 0; a < Elements1.Length; a++)
        {
            for (int b = 0; b < Elements2.Length; b++)
            {
                if (Elements1[a] != Elements2[b])
                {
                    bool Cont1 = Result.Contains(Elements1[a]);
                    bool Cont2 = Result2.Contains(Elements1[a]);
                    if (Cont1 is false && Cont2 is false)
                    {
                        Array.Resize(ref Result2, Result2.Length + 1);
                        Result2[Result2.Length - 1] = Elements1[a];
                    }
                }
            }
        }
        for (int a = 0; a < Elements2.Length; a++)
        {
            for (int b = 0; b < Elements1.Length; b++)
            {
                if (Elements2[a] != Elements1[b])
                {
                    bool Cont1 = Result.Contains(Elements2[a]);
                    bool Cont2 = Result2.Contains(Elements2[a]);
                    if (Cont1 is false && Cont2 is false)
                    {
                        Array.Resize(ref Result2, Result2.Length + 1);
                        Result2[Result2.Length - 1] = Elements2[a];
                    }
                }
            }
        }
        Result2 = Result2.Where(val => val != 999999999).ToArray();
        Set Set3 = new Set(Result2);
        return Set3;
    }
    public static bool operator >(Set set1, Set set2)
    {
        bool spc;
        if (set1.Count > set2.Count)
        {
            spc = true;
        }
        else
        {
            spc = false;
        }
        return spc;
    }
    public static bool operator <(Set set1, Set set2)
    {
        bool spc;
        if (set1.Count < set2.Count)
        {
            spc = true;
        }
        else
        {
            spc = false;
        }
        return spc;
    }

    public int this[int index]
    {
        get { return Elements[index]; }
    }

}

class HelloWorld
{
    static void Main()
    {
        Set Set2 = new Set();
        int[] SPR = { 17, 3, 4, 9, 6 };
        Set Set3 = new Set(SPR);
        Set2.ShowSet();
        Set3.ShowSet();
        Set Set4 = Set2 * Set3;
        Set4.ShowSet();
        Set Set5 = Set2 / Set3;
        Set5.ShowSet();
        Console.WriteLine(Set5[0]);
    }
}