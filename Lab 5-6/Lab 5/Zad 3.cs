using System;
using System.Collections.Generic;

// Generyczny interfejs IEntity
public interface IEntity<T>
{
    T Id { get; set; }
}

// Interfejs z w�asno�ci� daty utworzenia
public interface ICreationDate
{
    DateTime CreationDate { get; set; }
}

// Klasa Book implementuj�ca interfejsy IEntity i ICreationDate
public class Book : IEntity<int>, ICreationDate
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public DateTime CreationDate { get; set; }
}

// Klasa Person implementuj�ca interfejsy IEntity i ICreationDate
public class Person : IEntity<Guid>, ICreationDate
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; }
    public DateTime CreationDate { get; set; }
}

// Generyczny interfejs IBaseRepository
public interface IBaseRepository<T, TEntity>
    where T : IEntity<TEntity>
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    IEnumerable<T> GetAll();
    T Get(TEntity id);
    void Delete(TEntity id);
}

// Interfejs IBookRepository rozszerzaj�cy interfejs IBaseRepository
public interface IBookRepository : IBaseRepository<Book, int>
{
    // Dodatkowe metody specyficzne dla obs�ugi ksi��ek
}

// Interfejs IPersonRepository rozszerzaj�cy interfejs IBaseRepository
public interface IPersonRepository : IBaseRepository<Person, Guid>
{
    // Dodatkowe metody specyficzne dla obs�ugi os�b
}

class Program
{
    static void Main()
    {
        // Przyk�adowe u�ycie interfejs�w i klas
        IBookRepository bookRepository = new BookRepository();
        IPersonRepository personRepository = new PersonRepository();

        // Dodanie ksi��ki
        Book newBook = new Book
        {
            Id = 1,
            Title = "Sample Book",
            Author = "John Doe",
            YearPublished = 2022,
            CreationDate = DateTime.Now
        };
        bookRepository.Create(newBook);

        // Pobranie wszystkich ksi��ek
        var allBooks = bookRepository.GetAll();
        foreach (var book in allBooks)
        {
            Console.WriteLine($"Book: {book.Title}, Author: {book.Author}, Year: {book.YearPublished}");
        }
    }
}

// Implementacja IBookRepository
public class BookRepository : IBookRepository
{
    private List<Book> books = new List<Book>();

    public void Create(Book entity)
    {
        books.Add(entity);
    }

    public void Update(Book entity)
    {
        // Implementacja aktualizacji ksi��ki
    }

    public IEnumerable<Book> GetAll()
    {
        return books;
    }

    public Book Get(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public void Delete(int id)
    {
        var bookToDelete = books.FirstOrDefault(b => b.Id == id);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
        }
    }
}

// Implementacja IPersonRepository
public class PersonRepository : IPersonRepository
{
    private List<Person> people = new List<Person>();

    public void Create(Person entity)
    {
        people.Add(entity);
    }

    public void Update(Person entity)
    {
        // Implementacja aktualizacji osoby
    }

    public IEnumerable<Person> GetAll()
    {
        return people;
    }

    public Person Get(Guid id)
    {
        return people.FirstOrDefault(p => p.Id == id);
    }

    public void Delete(Guid id)
    {
        var personToDelete = people.FirstOrDefault(p => p.Id == id);
        if (personToDelete != null)
        {
            people.Remove(personToDelete);
        }
    }
}