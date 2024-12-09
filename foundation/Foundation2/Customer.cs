using System;

public class Customer
{
    private string Name;
    private Address CustomerAddress;

    // Constructor to initialize customer details
    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    // Method to check if the customer lives in the USA
    public bool LivesInUSA()
    {
        return CustomerAddress.IsInUSA();
    }

    // Method to get the customer's name
    public string GetName()
    {
        return Name;
    }

    // Method to get the customer's address
    public string GetAddress()
    {
        return CustomerAddress.GetFullAddress();
    }
}
