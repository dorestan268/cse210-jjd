using System;

public class Address
{
    private string StreetAddress;
    private string City;
    private string State;
    private string Country;

    // Constructor to initialize the address
    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    // Method to return the full address as a formatted string
    public string GetFullAddress()
    {
        return $"{StreetAddress}\n{City}, {State}\n{Country}";
    }
}
