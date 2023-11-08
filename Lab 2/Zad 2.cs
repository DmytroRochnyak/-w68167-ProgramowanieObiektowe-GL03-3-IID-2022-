using System;

public class Sumator
{
    private int[] Liczby;

    // Konstruktor
    public Sumator(int[] liczby)
    {
        this.Liczby = liczby;
    }

    // Metoda obliczaj¹ca sumê wszystkich liczb
    public int Suma()
    {
        int suma = 0;
        foreach (int liczba in Liczby)
        {
            suma += liczba;
        }
        return suma;
    }

    // Metoda obliczaj¹ca sumê liczb podzielnych przez 3
    public int SumaPodziel3()
    {
        int suma = 0;
        foreach (int liczba in Liczby)
        {
            if (liczba % 3 == 0)
            {
                suma += liczba;
            }
        }
        return suma;
    }

    // Metoda zwracaj¹ca liczbê elementów w tablicy
    public int IleElementów()
    {
        return Liczby.Length;
    }

    // Metoda wypisuj¹ca wszystkie elementy tablicy
    public void WypiszElementy()
    {
        foreach (int liczba in Liczby)
        {
            Console.Write(liczba + " ");
        }
        Console.WriteLine();
    }

    // Metoda wypisuj¹ca elementy o indeksach >= lowIndex oraz <= highIndex
    public void WypiszElementyWZakresie(int lowIndex, int highIndex)
    {
        if (lowIndex < 0)
        {
            lowIndex = 0;
        }
        if (highIndex >= Liczby.Length)
        {
            highIndex = Liczby.Length - 1;
        }

        for (int i = lowIndex; i <= highIndex; i++)
        {
            Console.Write(Liczby[i] + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Sumator sumator = new Sumator(liczby);

        Console.WriteLine("Suma wszystkich liczb: " + sumator.Suma());
        Console.WriteLine("Suma liczb podzielnych przez 3: " + sumator.SumaPodziel3());
        Console.WriteLine("Liczba elementów w tablicy: " + sumator.IleElementów());

        Console.WriteLine("Wszystkie elementy tablicy:");
        sumator.WypiszElementy();

        Console.WriteLine("Elementy o indeksach 2-6:");
        sumator.WypiszElementyWZakresie(2, 6);
    }
}
