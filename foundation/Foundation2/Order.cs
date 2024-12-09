using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> Products = new List<Product>();
    private Customer OrderCustomer;

    // Constructor to initialize the order with a customer
    public Order(Customer customer)
    {
        OrderCustomer = customer;
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // Method to calculate the total cost of the order
    public double CalculateTotalCost()
    {
        double productTotal = 0;

        foreach (var product in Products)
        {
            productTotal += product.GetTotalCost();
        }

        // Add shipping cost based on the customer's location
        double shippingCost = OrderCustomer.LivesInUSA() ? 5.0 : 35.0;
        return productTotal + shippingCost;
    }

    // Method to generate the packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"- {product.GetPackingLabel()}\n";
        }
        return label;
    }

    // Method to generate the shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{OrderCustomer.GetName()}\n{OrderCustomer.GetAddress()}";
    }
}
