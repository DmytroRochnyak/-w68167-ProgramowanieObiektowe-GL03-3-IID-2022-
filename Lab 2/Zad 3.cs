public class Samochód
{
    // Publiczne pola
    public String marka;
    public String model;
    public int rokProdukcji;

    // Prywatne pola
    private int prêdkoœæ;
    private int przebieg;
    private StanSilnika stanSilnika;

    // Enum opisuj¹cy stan silnika
    private enum StanSilnika
    {
        URUCHOMIONY,
        ZATRZYMANY,
        CHECK_ENGINE
    }

    // Konstruktor
    public Samochód(String marka, String model, int rokProdukcji)
    {
        this.marka = marka;
        this.model = model;
        this.rokProdukcji = rokProdukcji;
        this.prêdkoœæ = 0;
        this.przebieg = 0;
        this.stanSilnika = StanSilnika.ZATRZYMANY;
    }

    // Metoda do ustawiania tempomatu na zadan¹ prêdkoœæ
    public void ustawTempomat(int prêdkoœæ)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            this.prêdkoœæ = prêdkoœæ;
        }
        else
        {
            System.out.println("Nie mo¿na ustawiæ tempomatu - silnik jest zatrzymany.");
        }
    }

    // Metoda do zwiêkszania prêdkoœci o 5
    public void zwiêkszPrêdkoœæ()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            prêdkoœæ += 5;
        }
        else
        {
            System.out.println("Nie mo¿na zwiêkszyæ prêdkoœci - silnik jest zatrzymany.");
        }
    }

    // Metoda do zmniejszania prêdkoœci o 5
    public void zmniejszPrêdkoœæ()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            prêdkoœæ -= 5;
        }
        else
        {
            System.out.println("Nie mo¿na zmniejszyæ prêdkoœci - silnik jest zatrzymany.");
        }
    }

    // Metoda do uruchamiania silnika
    public void uruchomSilnik()
    {
        if (stanSilnika != StanSilnika.CHECK_ENGINE)
        {
            stanSilnika = StanSilnika.URUCHOMIONY;
            System.out.println("Silnik uruchomiony.");
        }
        else
        {
            System.out.println("Nie mo¿na uruchomiæ silnika - stan silnika to CHECK ENGINE.");
        }
    }

    // Metoda do zatrzymywania pracy silnika
    public void zatrzymajSilnik()
    {
        stanSilnika = StanSilnika.ZATRZYMANY;
        System.out.println("Silnik zatrzymany.");
    }

    // Metoda do przejechania podanego dystansu
    public double przejedŸDystans(double dystans)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            przebieg += dystans;
            if (przebieg > 10000)
            {
                stanSilnika = StanSilnika.CHECK_ENGINE;
                throw new IllegalStateException("CHECK ENGINE - Przebieg przekroczy³ 10000 km.");
            }
            return dystans / prêdkoœæ;
        }
        else
        {
            System.out.println("Nie mo¿na przejechaæ dystansu - silnik jest zatrzymany.");
            return 0.0;
        }
    }

    // W³asnoœæ zwracaj¹ca prêdkoœæ
    public int getPrêdkoœæ()
    {
        return prêdkoœæ;
    }

    public static void main(String[] args)
    {
        Samochód samochód = new Samochód("Toyota", "Camry", 2022);
        samochód.uruchomSilnik();
        samochód.ustawTempomat(60);
        samochód.zwiêkszPrêdkoœæ();
        samochód.zwiêkszPrêdkoœæ();
        samochód.zmniejszPrêdkoœæ();
        samochód.zatrzymajSilnik();
        try
        {
            double czas = samochód.przejedŸDystans(120);
            System.out.println("Czas podró¿y: " + czas + " godzin.");
        }
        catch (IllegalStateException e)
        {
            System.out.println(e.getMessage());
        }
    }
}
