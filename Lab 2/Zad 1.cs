using System;

public class Licz
{
    private int wartoœæ;

    // Konstruktor
    public Licz(int pocz¹tkowaWartoœæ)
    {
        this.wartoœæ = pocz¹tkowaWartoœæ;
    }

    // Metoda dodawania
    public void Dodaj(int dodawanaWartoœæ)
    {
        wartoœæ += dodawanaWartoœæ;
    }

    // Metoda odejmowania
    public void Odejmij(int odejmowanaWartoœæ)
    {
        wartoœæ -= odejmowanaWartoœæ;
    }

    // Metoda wypisuj¹ca stan obiektu
    public void WypiszStan()
    {
        Console.WriteLine("Wartoœæ: " + wartoœæ);
    }

    public static void Main()
    {
        Licz liczba = new Licz(10); // Tworzenie obiektu z pocz¹tkow¹ wartoœci¹ 10
        liczba.WypiszStan();       // Wyœwietlenie pocz¹tkowego stanu

        liczba.Dodaj(5);           // Dodawanie 5 do wartoœci
        liczba.WypiszStan();       // Wyœwietlenie zaktualizowanego stanu

        liczba.Odejmij(3);         // Odejmowanie 3 od wartoœci
        liczba.WypiszStan();       // Wyœwietlenie zaktualizowanego stanu
    }
}
