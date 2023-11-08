using System;

public class Licz
{
    private int warto��;

    // Konstruktor
    public Licz(int pocz�tkowaWarto��)
    {
        this.warto�� = pocz�tkowaWarto��;
    }

    // Metoda dodawania
    public void Dodaj(int dodawanaWarto��)
    {
        warto�� += dodawanaWarto��;
    }

    // Metoda odejmowania
    public void Odejmij(int odejmowanaWarto��)
    {
        warto�� -= odejmowanaWarto��;
    }

    // Metoda wypisuj�ca stan obiektu
    public void WypiszStan()
    {
        Console.WriteLine("Warto��: " + warto��);
    }

    public static void Main()
    {
        Licz liczba = new Licz(10); // Tworzenie obiektu z pocz�tkow� warto�ci� 10
        liczba.WypiszStan();       // Wy�wietlenie pocz�tkowego stanu

        liczba.Dodaj(5);           // Dodawanie 5 do warto�ci
        liczba.WypiszStan();       // Wy�wietlenie zaktualizowanego stanu

        liczba.Odejmij(3);         // Odejmowanie 3 od warto�ci
        liczba.WypiszStan();       // Wy�wietlenie zaktualizowanego stanu
    }
}
