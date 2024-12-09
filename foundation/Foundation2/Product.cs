using System;

public class Product
{
    private string Name;
    private string ProductID;
    private double PricePerUnit;
    private int Quantity;

    // Constructor to initialize product details
    public Product(string name, string productID, double pricePerUnit, int quantity)
    {
        Name = name;
        ProductID = productID;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double GetTotalCost()
    {
        return PricePerUnit * Quantity;
    }

    // Method to get the product's packing label
    public string GetPackingLabel()
    {
        return $"{Name} (ID: {ProductID})";
    }
}
