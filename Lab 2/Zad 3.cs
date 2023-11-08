using System;

public class Samoch�d
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int RokProdukcji { get; set; }

    private int pr�dko��;
    private int przebieg;
    private StanSilnika stanSilnika;

    private enum StanSilnika
    {
        URUCHOMIONY,
        ZATRZYMANY,
        CHECK_ENGINE
    }

    public Samoch�d(string marka, string model, int rokProdukcji)
    {
        Marka = marka;
        Model = model;
        RokProdukcji = rokProdukcji;
        pr�dko�� = 0;
        przebieg = 0;
        stanSilnika = StanSilnika.ZATRZYMANY;
    }

    public void UstawTempomat(int pr�dko��)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            this.pr�dko�� = pr�dko��;
        }
        else
        {
            Console.WriteLine("Nie mo�na ustawi� tempomatu - silnik jest zatrzymany.");
        }
    }

    public void Zwi�kszPr�dko��()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            pr�dko�� += 5;
        }
        else
        {
            Console.WriteLine("Nie mo�na zwi�kszy� pr�dko�ci - silnik jest zatrzymany.");
        }
    }

    public void ZmniejszPr�dko��()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            pr�dko�� -= 5;
        }
        else
        {
            Console.WriteLine("Nie mo�na zmniejszy� pr�dko�ci - silnik jest zatrzymany.");
        }
    }

    public void UruchomSilnik()
    {
        if (stanSilnika != StanSilnika.CHECK_ENGINE)
        {
            stanSilnika = StanSilnika.URUCHOMIONY;
            Console.WriteLine("Silnik uruchomiony.");
        }
        else
        {
            Console.WriteLine("Nie mo�na uruchomi� silnika - stan silnika to CHECK ENGINE.");
        }
    }

    public void ZatrzymajSilnik()
    {
        stanSilnika = StanSilnika.ZATRZYMANY;
        Console.WriteLine("Silnik zatrzymany.");
    }

    public double Przejed�Dystans(double dystans)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            przebieg += (int)dystans;
            if (przebieg > 10000)
            {
                stanSilnika = StanSilnika.CHECK_ENGINE;
                throw new InvalidOperationException("CHECK ENGINE - Przebieg przekroczy� 10000 km.");
            }
            return dystans / pr�dko��;
        }
        else
        {
            Console.WriteLine("Nie mo�na przejecha� dystansu - silnik jest zatrzymany.");
            return 0.0;
        }
    }

    public int Pr�dko�� => pr�dko��;

    public static void Main()
    {
        Samoch�d samoch�d = new Samoch�d("Toyota", "Camry", 2022);
        samoch�d.UruchomSilnik();
        samoch�d.UstawTempomat(60);
        samoch�d.Zwi�kszPr�dko��();
        samoch�d.Zwi�kszPr�dko��();
        samoch�d.ZmniejszPr�dko��();
        samoch�d.ZatrzymajSilnik();
        try
        {
            double czas = samoch�d.Przejed�Dystans(120);
            Console.WriteLine("Czas podr�y: " + czas + " godzin.");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
