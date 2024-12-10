public class Customer
{
    private string _name;
    private Address _CustomerAddress;

    public string Name { get => _name; set => _name = value; }
    public Address CustomerAddress { get => _CustomerAddress; set => _CustomerAddress = value; }

    public bool LiveInUSA()
    {
        return _CustomerAddress.IsInUSA();
    }
}
