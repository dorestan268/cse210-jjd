public class Address
{
    private string _StreetAddress;
    private string _City;
    private string _State;
    private string _Country;

    // Constructor to initialize the address
    public string StreetAddress {get => _StreetAddress; set => _StreetAddress = value; }
    public string City {get => _City; set => _City = value; }
    public string State {get => _State; set => _State = value; }
    public string Country {get => _Country; set => _Country = value; }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return _Country.ToUpper() == "USA";
    }

    // Method to return the full address as a formatted string
    public string GetFullAddress()
    {
        return $"{StreetAddress}\n{City}, {State}\n{Country}";
    }
}
