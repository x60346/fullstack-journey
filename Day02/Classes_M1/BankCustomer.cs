namespace Classes_M1;

public class BankCustomer
{
    public BankCustomer()
    {
        Console.WriteLine("BankCustomer created");
    }

    public BankCustomer(string firstName, string lastName)
    {
        Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
    }
}

