using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj liczbę całkowitą: ");
        int liczba;

        if (int.TryParse(Console.ReadLine(), out liczba))
        {
            if (liczba % 2 == 0)
            {
                Console.WriteLine("Podana liczba jest parzysta.");
            }
            else
            {
                Console.WriteLine("Podana liczba jest nieparzysta.");
            }
        }
        else
        {
            Console.WriteLine("To nie jest liczba całkowita.");
        }
    }
}
