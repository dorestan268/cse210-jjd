using System.Collections.Generic;

public class Order
{
    private List<Product> _Products;
    private Customer _OrderCustomer;

    public List<Product> Products { get => _Products; set => _Products = value; } 
    public Customer OrderCustomer { get => _OrderCustomer; set => _OrderCustomer = value; }

    public Order()
    {
        _Products = new List<Product>();
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var product in _Products)
        {
            total += product.GetTotalCost();
        }

        total += _OrderCustomer.LiveInUSA() ? 5 : 45;
        return total;
    }

    public string GetPackageLabel()
    {
        var label = "Package Label:\n";
        foreach (var product in _Products)
        {
            label += $"{product.Name} (ID: {product.ProductID})\n";
        }
        return label;
    }

    public string GetShipping()
    {
        return $"Shipping:\n{_OrderCustomer.Name}\n{_OrderCustomer.CustomerAddress.GetFullAddress()}";
    }



}

   