public class Sumator
{
    private int[] Liczby;

    // Konstruktor
    public Sumator(int[] liczby)
    {
        this.Liczby = liczby;
    }

    // Metoda obliczaj�ca sum� wszystkich liczb
    public int Suma()
    {
        int suma = 0;
        for (int liczba : Liczby)
        {
            suma += liczba;
        }
        return suma;
    }

    // Metoda obliczaj�ca sum� liczb podzielnych przez 3
    public int SumaPodziel3()
    {
        int suma = 0;
        for (int liczba : Liczby)
        {
            if (liczba % 3 == 0)
            {
                suma += liczba;
            }
        }
        return suma;
    }

    // Metoda zwracaj�ca liczb� element�w w tablicy
    public int IleElement�w()
    {
        return Liczby.length;
    }

    // Metoda wypisuj�ca wszystkie elementy tablicy
    public void WypiszElementy()
    {
        for (int liczba : Liczby)
        {
            System.out.print(liczba + " ");
        }
        System.out.println();
    }

    // Metoda wypisuj�ca elementy o indeksach >= lowIndex oraz <= highIndex
    public void WypiszElementyWZakresie(int lowIndex, int highIndex)
    {
        if (lowIndex < 0)
        {
            lowIndex = 0;
        }
        if (highIndex >= Liczby.length)
        {
            highIndex = Liczby.length - 1;
        }

        for (int i = lowIndex; i <= highIndex; i++)
        {
            System.out.print(Liczby[i] + " ");
        }
        System.out.println();
    }

    public static void main(String[] args)
    {
        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Sumator sumator = new Sumator(liczby);

        System.out.println("Suma wszystkich liczb: " + sumator.Suma());
        System.out.println("Suma liczb podzielnych przez 3: " + sumator.SumaPodziel3());
        System.out.println("Liczba element�w w tablicy: " + sumator.IleElement�w());

        System.out.println("Wszystkie elementy tablicy:");
        sumator.WypiszElementy();

        System.out.println("Elementy o indeksach 2-6:");
        sumator.WypiszElementyWZakresie(2, 6);
    }
}
