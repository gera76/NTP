using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());

        // Provera primalnosti naivni
        provera_primalnosti_naivni(n);

        // Provera primalnosti optimizovan
        provera_primalnosti_optimizovan(n);

        // Faktorizacija
        faktorizacija(n);

        // NZD iterativni
        long nzd_I = nzdIterativni(a, b);
        Console.WriteLine($"NZD iterativni: {nzd_I}");

        // NZD rekurzivni
        long nzd_R = nzd_rekurzivni(a, b);
        Console.WriteLine($"NZD rekurzivni: {nzd_R}");

        long nzs_I = nzsIterativni (a, b);
        Console.WriteLine($"NZS interativni: {nzd_I}");

        long nzs_R =nzd_rekurzivni (a, b);

        Console.WriteLine($"NZS rekurzivni: {nzs_R}");

        Console.ReadLine();
    }

    // Provera primalnosti naivni
    static void provera_primalnosti_naivni(long n)
    {
        bool prost;
        if (n == 1)
        {
            prost = false; // broj 1 nije prost
        }
           
        else
        {
            prost = true;
            for (long i = 2; i < n; i++)
                if (n % i == 0)
                {
                    prost = false;
                    i = n; // izlaz iz petlje
                }
        }
        Console.WriteLine(prost ? "DA" : "NE");
    }

    // Provera primalnosti optimizovan
    static void provera_primalnosti_optimizovan(long n)
    {
        long a = (long)Math.Ceiling(Math.Sqrt(n));
        bool prost;
        if (n == 1)
        {
            prost = false;
        }
        else if (n == 2)
        {
            prost = true;
        }
        else
        {
            prost = true;
            for (long i = 2; i <= a; i++)
                if (n % i == 0)
                {
                    prost = false;
                    break;
                }
        }
        Console.WriteLine(prost ? "DA" : "NE");
    }

    // Faktorizacija
    static void faktorizacija(long n)
    {
        Stopwatch b = new Stopwatch();
        b.Start();
        long a = (long)Math.Ceiling(Math.Sqrt(n));
        long i = 2;
        while (i <= a)
        {
            if (n % i == 0)
            {
                Console.WriteLine(i);
                n = n / i;
                a = (long)Math.Ceiling(Math.Sqrt(n));
            }
            else
            {
                i++;
            }
        }
        if (n > 1)
        {
            Console.WriteLine(n);
        }
        b.Stop();
        Console.WriteLine($"Vreme: {b.ElapsedMilliseconds * 0.001} sekundi");
    }

    // NZD iterativni
    static long nzdIterativni(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // NZD rekurzivni
    static long nzd_rekurzivni(long a, long b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return nzd_rekurzivni(b, a % b);
        }
    }


    static long nzsIterativni(long a, long b)
    {
       return (a*b)/nzdIterativni(a, b);
    }
    static long nzs_rekurzivni(long a, long b)
    {
        return (a * b) / nzd_rekurzivni (a, b);
    }
}
