using System;
using System.Collections.Generic;

namespace SystemRezerwacjiMiejscWKinie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicjalizacja systemu rezerwacji miejsc w kinie
            SystemRezerwacji systemRezerwacji = new SystemRezerwacji();
          // Logowanie użytkownika
            Console.WriteLine("Witaj w systemie rezerwacji miejsc w kinie!");
            Console.Write("Podaj login: ");
            string login = Console.ReadLine();
            Console.Write("Podaj haslo: ");
            string haslo = Console.ReadLine();

            bool czyZalogowany = systemRezerwacji.ZalogujUzytkownika(login, haslo);

            if (czyZalogowany)
            {
                Console.WriteLine("Zalogowano pomyslnie!");

                // Wybór filmu
                Console.WriteLine("Dostepne filmy:");
                foreach (var film in systemRezerwacji.DostepneFilmy())
                {
                    Console.WriteLine($"- {film}");
                }
                Console.Write("Wybierz film: ");
                string wybranyFilm = Console.ReadLine();

                // Wybór daty i godziny
                Console.Write("Podaj date (RRRR-MM-DD): ");
                DateTime data;
                while (!DateTime.TryParse(Console.ReadLine(), out data))
                {
                    Console.WriteLine("Nieprawidłowy format daty. Wprowadź ponownie (RRRR-MM-DD): ");
                }
                Console.Write("Podaj godzine (HH:MM): ");
                TimeSpan godzina;
                while (!TimeSpan.TryParse(Console.ReadLine(), out godzina))
                {
                    Console.WriteLine("Nieprawidłowy format godziny. Wprowadź ponownie (HH:MM): ");
                }

                // Wybór miejsc (liczba ograniczona (50szt.))
                Console.Write("Podaj liczbe miejsc do zarezerwowania: ");
                int liczbaMiejsc;
                while (!int.TryParse(Console.ReadLine(), out liczbaMiejsc) || liczbaMiejsc <= 0)
                {
                    Console.WriteLine("Nieprawidłowa liczba miejsc. Wprowadź ponownie: ");
                }
                List<int> zarezerwowaneMiejsca = new List<int>();
                for (int i = 0; i < liczbaMiejsc; i++)
                {
                    Console.Write($"Numer miejsca {i + 1}: ");
                    int miejsce;
                    while (!int.TryParse(Console.ReadLine(), out miejsce) || miejsce <= 0 || miejsce > 50)
                    {
                        Console.WriteLine("Nieprawidlowy numer miejsca. Wprowadź ponownie: ");
                    }
                    zarezerwowaneMiejsca.Add(miejsce);
                }

                // Rezerwacja miejsc
                systemRezerwacji.ZarezerwujMiejsca(wybranyFilm, data, godzina, zarezerwowaneMiejsca);

                // Potwierdzenie rezerwacji
                Console.WriteLine("Czy potwierdzic rezerwacje? (tak/nie): ");
                if (Console.ReadLine().ToLower() == "tak")
                {
                    systemRezerwacji.PotwierdzRezerwacje();
                }
                else 
                {
                    Console.WriteLine("Rezerwacja nie zostala potwierdzona.");
                }

                // Anulowanie rezerwacji
                Console.WriteLine("Czy anulowac rezerwacje? (tak/nie): ");
                if (Console.ReadLine().ToLower() == "tak")
                {
                    systemRezerwacji.AnulujRezerwacje(zarezerwowaneMiejsca);
                }
                else
                {
                    Console.WriteLine("Rezerwacja nie zostala anulowana.");
                }
            }
            else
            {
                Console.WriteLine("Blad logowania. Sprawdz login i haslo.");
            }
        }
    }

    public class SystemRezerwacji
    {
        private Dictionary<string, string> uzytkownicy = new Dictionary<string, string>();
        private List<string> filmy = new List<string>() { "Film 1", "Film 2", "Film 3" }; // Przykładowa lista dostępnych filmów
        private List<Rezerwacja> listaRezerwacji = new List<Rezerwacja>();

        public SystemRezerwacji()
        {
            // Tutaj można wczytać dane użytkowników i rezerwacje z bazy danych lub pliku
        }

        public bool ZalogujUzytkownika(string login, string haslo)
        {
            // Tutaj logika logowania użytkownika
            // Implementacja może być zależna od dalszych wymagań
            // W tym przykładzie logowanie jest proste, dla uproszczenia
            return true;
        }

        public List<string> DostepneFilmy()
        {
            // Tutaj można zaimplementować logikę pobierania dostępnych filmów z bazy danych lub pliku
            return filmy;
        }

        public void ZarezerwujMiejsca(string film, DateTime data, TimeSpan godzina, List<int> miejsca)
        {
            // Tutaj logika rezerwacji miejsc
            Rezerwacja rezerwacja = new Rezerwacja(film, data, godzina, miejsca);
            listaRezerwacji.Add(rezerwacja);
            Console.WriteLine("Zarezerwowano miejsca:");
            foreach (var miejsce in miejsca)
            {
                Console.WriteLine($"- Miejsce nr {miejsce}");
            }
        }

        public void PotwierdzRezerwacje()
        {
            // Tutaj logika potwierdzania rezerwacji
            // Implementacja może być zależna od dalszych wymagań
            Console.WriteLine("Rezerwacja potwierdzona.");
        }

        public void AnulujRezerwacje(List<int> miejsca)
        {
            // Tutaj logika anulowania rezerwacji
            // Implementacja może być zależna od dalszych wymagań
            Console.WriteLine("Rezerwacja anulowana.");
        }
    }

    public class Rezerwacja
    {
        public string Film { get; private set; }
        public DateTime Data { get; private set; }
        public TimeSpan Godzina { get; private set; }
        public List<int> Miejsca { get; private set; }

        public Rezerwacja(string film, DateTime data, TimeSpan godzina, List<int> miejsca)
        {
            Film = film;
            Data = data;
            Godzina = godzina;
            Miejsca = miejsca;
        }
    }
}

