public class Product
{
    private string _Name;
    private string _ProductID;
    private decimal _PricePerUnit;
    private int _Quantity;

    // Constructor to initialize product details
    public string Name { get => _Name; set => _Name = value; }
    public string ProductID { get => _ProductID; set => _ProductID = value; }
    public decimal PricePerUnit { get => _PricePerUnit; set => _PricePerUnit = value; }
    public int Quantity { get => _Quantity; set => _Quantity = value; }

    // Method to calculate the total cost of the product
    public decimal GetTotalCost()
    {
        return _PricePerUnit * _Quantity;
    }
   
}
