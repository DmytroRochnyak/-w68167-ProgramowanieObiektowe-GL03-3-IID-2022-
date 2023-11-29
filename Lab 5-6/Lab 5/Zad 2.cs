using System;
using System.Collections.Generic;

// Abstrakcyjna klasa Transaction
public abstract class Transaction
{
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public abstract void ProcessTransaction();
}

// Klasa IncomeTransaction dziedzicz�ca po klasie Transaction
public class IncomeTransaction : Transaction
{
    public override void ProcessTransaction()
    {
        // Implementacja dodawania kwoty do og�lnej sumy dochod�w
        Account.TotalIncome += Amount;
        Console.WriteLine($"Dodano transakcj� dochodow�: +{Amount}");
    }
}

// Klasa ExpenseTransaction dziedzicz�ca po klasie Transaction
public class ExpenseTransaction : Transaction
{
    public override void ProcessTransaction()
    {
        // Implementacja odejmowania kwoty od og�lnej sumy wydatk�w
        Account.TotalExpenses += Amount;
        Console.WriteLine($"Dodano transakcj� wydatkow�: -{Amount}");
    }
}

// Klasa Account
public class Account
{
    public static decimal TotalIncome { get; set; }
    public static decimal TotalExpenses { get; set; }
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
        transaction.ProcessTransaction();
    }
}

// Przyk�ady u�ycia
class Program
{
    static void Main()
    {
        Account account = new Account();

        // Dodanie przyk�adowych transakcji
        account.AddTransaction(new IncomeTransaction { Amount = 1000, TransactionDate = DateTime.Now });
        account.AddTransaction(new ExpenseTransaction { Amount = 500, TransactionDate = DateTime.Now });
        account.AddTransaction(new IncomeTransaction { Amount = 2000, TransactionDate = DateTime.Now });

        // Wy�wietlenie og�lnej sumy dochod�w i wydatk�w
        Console.WriteLine($"Og�lna suma dochod�w: {Account.TotalIncome}");
        Console.WriteLine($"Og�lna suma wydatk�w: {Account.TotalExpenses}");
    }
}
