using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesi velicinu niza:");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            int[] niz = new int[n];

            while(i < n)
            {
                Console.WriteLine($"Unesi {i}-ti element:");
                int el = Convert.ToInt32(Console.ReadLine());
                niz[i] = el;
                i++;
            }

            SelectionSort(niz, n);
            i = 0;

            while (i < n)
            {
                Console.Write(niz[i]);
                Console.Write(", ");

                i++;
            }
            Console.WriteLine();

            Console.WriteLine("Unesite element koji trazite:");
            int trazeni = Convert.ToInt32(Console.ReadLine());

            int nadjeno = binarna_pretraga(niz, 0, n-1, trazeni);

            if (nadjeno != -1)
                Console.WriteLine($"Trazeni element {trazeni} je na poziciji {nadjeno}.");
            else
                Console.WriteLine("Trazeni element ne postoji");

            Console.ReadLine();
        }


        //pazite sa binarnom pretragom ovde jer sad trazite u nizu sa nerastucim poretkom!
        private static int binarna_pretraga(int[] a, int l, int d, int x)
        {
            int s;
            if (l > d)
            {
                return -1;
            }
            s = l + (d - l) / 2;
            if (x == a[s])
            {
                return s;
            }
            if (x < a[s])
            {
                return binarna_pretraga(a, s + 1, d, x);
            }
            else /* if (x > a[s]) */
            {
                return binarna_pretraga(a, l, s - 1, x);
            }
        }

        private static void SelectionSort(int[] niz, int n)
        {
            int i, j;
            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (niz[i] < niz[j])
                    {
                        razmena(ref niz[i], ref niz[j]);
                    }
                }
            }
        }

        //verzija razmene sa referenciranjem
        //umesto ovoga mozete koristiti klasican metod bez referenci gde saljemo ceo niz i vrednosti indeksa koje
        //zelimo razmeniti u nizu (korisceno u Zadatak 1)
        private static void razmena(ref int a, ref int b)
        {
            int pom = a;
            a = b;
            b = pom;
        }
    }
}
