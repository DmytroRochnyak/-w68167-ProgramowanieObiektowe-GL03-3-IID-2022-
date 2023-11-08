using System;

public class Samochód
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int RokProdukcji { get; set; }

    private int prêdkoœæ;
    private int przebieg;
    private StanSilnika stanSilnika;

    private enum StanSilnika
    {
        URUCHOMIONY,
        ZATRZYMANY,
        CHECK_ENGINE
    }

    public Samochód(string marka, string model, int rokProdukcji)
    {
        Marka = marka;
        Model = model;
        RokProdukcji = rokProdukcji;
        prêdkoœæ = 0;
        przebieg = 0;
        stanSilnika = StanSilnika.ZATRZYMANY;
    }

    public void UstawTempomat(int prêdkoœæ)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            this.prêdkoœæ = prêdkoœæ;
        }
        else
        {
            Console.WriteLine("Nie mo¿na ustawiæ tempomatu - silnik jest zatrzymany.");
        }
    }

    public void ZwiêkszPrêdkoœæ()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            prêdkoœæ += 5;
        }
        else
        {
            Console.WriteLine("Nie mo¿na zwiêkszyæ prêdkoœci - silnik jest zatrzymany.");
        }
    }

    public void ZmniejszPrêdkoœæ()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            prêdkoœæ -= 5;
        }
        else
        {
            Console.WriteLine("Nie mo¿na zmniejszyæ prêdkoœci - silnik jest zatrzymany.");
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
            Console.WriteLine("Nie mo¿na uruchomiæ silnika - stan silnika to CHECK ENGINE.");
        }
    }

    public void ZatrzymajSilnik()
    {
        stanSilnika = StanSilnika.ZATRZYMANY;
        Console.WriteLine("Silnik zatrzymany.");
    }

    public double PrzejedŸDystans(double dystans)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            przebieg += (int)dystans;
            if (przebieg > 10000)
            {
                stanSilnika = StanSilnika.CHECK_ENGINE;
                throw new InvalidOperationException("CHECK ENGINE - Przebieg przekroczy³ 10000 km.");
            }
            return dystans / prêdkoœæ;
        }
        else
        {
            Console.WriteLine("Nie mo¿na przejechaæ dystansu - silnik jest zatrzymany.");
            return 0.0;
        }
    }

    public int Prêdkoœæ => prêdkoœæ;

    public static void Main()
    {
        Samochód samochód = new Samochód("Toyota", "Camry", 2022);
        samochód.UruchomSilnik();
        samochód.UstawTempomat(60);
        samochód.ZwiêkszPrêdkoœæ();
        samochód.ZwiêkszPrêdkoœæ();
        samochód.ZmniejszPrêdkoœæ();
        samochód.ZatrzymajSilnik();
        try
        {
            double czas = samochód.PrzejedŸDystans(120);
            Console.WriteLine("Czas podró¿y: " + czas + " godzin.");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
