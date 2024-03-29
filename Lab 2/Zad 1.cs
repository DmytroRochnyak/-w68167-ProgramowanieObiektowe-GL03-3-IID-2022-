using System;

public class Licz
{
    private int wartość;

    // Konstruktor
    public Licz(int początkowaWartość)
    {
        this.wartość = początkowaWartość;
    }

    // Metoda dodawania
    public void Dodaj(int dodawanaWartość)
    {
        wartość += dodawanaWartość;
    }

    // Metoda odejmowania
    public void Odejmij(int odejmowanaWartość)
    {
        wartość -= odejmowanaWartość;
    }

    // Metoda wypisująca stan obiektu
    public void WypiszStan()
    {
        Console.WriteLine("Wartość: " + wartość);
    }

    public static void Main()
    {
        Licz liczba = new Licz(10); // Tworzenie obiektu z początkową wartością 10
        liczba.WypiszStan();       // Wyświetlenie początkowego stanu

        liczba.Dodaj(5);           // Dodawanie 5 do wartości
        liczba.WypiszStan();       // Wyświetlenie zaktualizowanego stanu

        liczba.Odejmij(3);         // Odejmowanie 3 od wartości
        liczba.WypiszStan();       // Wyświetlenie zaktualizowanego stanu
    }
}
