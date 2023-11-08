public class Samoch�d
{
    // Publiczne pola
    public String marka;
    public String model;
    public int rokProdukcji;

    // Prywatne pola
    private int pr�dko��;
    private int przebieg;
    private StanSilnika stanSilnika;

    // Enum opisuj�cy stan silnika
    private enum StanSilnika
    {
        URUCHOMIONY,
        ZATRZYMANY,
        CHECK_ENGINE
    }

    // Konstruktor
    public Samoch�d(String marka, String model, int rokProdukcji)
    {
        this.marka = marka;
        this.model = model;
        this.rokProdukcji = rokProdukcji;
        this.pr�dko�� = 0;
        this.przebieg = 0;
        this.stanSilnika = StanSilnika.ZATRZYMANY;
    }

    // Metoda do ustawiania tempomatu na zadan� pr�dko��
    public void ustawTempomat(int pr�dko��)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            this.pr�dko�� = pr�dko��;
        }
        else
        {
            System.out.println("Nie mo�na ustawi� tempomatu - silnik jest zatrzymany.");
        }
    }

    // Metoda do zwi�kszania pr�dko�ci o 5
    public void zwi�kszPr�dko��()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            pr�dko�� += 5;
        }
        else
        {
            System.out.println("Nie mo�na zwi�kszy� pr�dko�ci - silnik jest zatrzymany.");
        }
    }

    // Metoda do zmniejszania pr�dko�ci o 5
    public void zmniejszPr�dko��()
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            pr�dko�� -= 5;
        }
        else
        {
            System.out.println("Nie mo�na zmniejszy� pr�dko�ci - silnik jest zatrzymany.");
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
            System.out.println("Nie mo�na uruchomi� silnika - stan silnika to CHECK ENGINE.");
        }
    }

    // Metoda do zatrzymywania pracy silnika
    public void zatrzymajSilnik()
    {
        stanSilnika = StanSilnika.ZATRZYMANY;
        System.out.println("Silnik zatrzymany.");
    }

    // Metoda do przejechania podanego dystansu
    public double przejed�Dystans(double dystans)
    {
        if (stanSilnika == StanSilnika.URUCHOMIONY)
        {
            przebieg += dystans;
            if (przebieg > 10000)
            {
                stanSilnika = StanSilnika.CHECK_ENGINE;
                throw new IllegalStateException("CHECK ENGINE - Przebieg przekroczy� 10000 km.");
            }
            return dystans / pr�dko��;
        }
        else
        {
            System.out.println("Nie mo�na przejecha� dystansu - silnik jest zatrzymany.");
            return 0.0;
        }
    }

    // W�asno�� zwracaj�ca pr�dko��
    public int getPr�dko��()
    {
        return pr�dko��;
    }

    public static void main(String[] args)
    {
        Samoch�d samoch�d = new Samoch�d("Toyota", "Camry", 2022);
        samoch�d.uruchomSilnik();
        samoch�d.ustawTempomat(60);
        samoch�d.zwi�kszPr�dko��();
        samoch�d.zwi�kszPr�dko��();
        samoch�d.zmniejszPr�dko��();
        samoch�d.zatrzymajSilnik();
        try
        {
            double czas = samoch�d.przejed�Dystans(120);
            System.out.println("Czas podr�y: " + czas + " godzin.");
        }
        catch (IllegalStateException e)
        {
            System.out.println(e.getMessage());
        }
    }
}
