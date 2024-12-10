using System;

class Program
{
    static void Main(string[] args)
    {
        // Create customers
        var customer1 = new Customer
        {
            Name = "Junior",
            CustomerAddress = new Address
            {
                StreetAddress = "10 main street",
                City = "Springfield",
                State = "Utah",
                Country = "USA"
            }
        };

        var customer2 = new Customer
        {
            Name = "Jeff",
            CustomerAddress = new Address
            {
                StreetAddress = "123 Lincoln Ave",
                City = "Chicago",
                State = "IL",
                Country = "USA"
            }
        };

        // Create products
        var product1 = new Product{ Name = "iPad", ProductID = "P1233", PricePerUnit = 129.99M, Quantity = 5};
        var product2 = new Product{ Name = "AirPods", ProductID = "P4562", PricePerUnit = 25.50M, Quantity = 2};
        var product3 = new Product{ Name = "Power suplly", ProductID = "P7892", PricePerUnit = 49.99M, Quantity = 1};
        var product4 = new Product{ Name = "Apple Watch", ProductID = "P3221", PricePerUnit = 150.00M, Quantity = 1};

        // Create orders
        var order1 = new Order { OrderCustomer = customer1 };
        order1.Products.Add(product1);
        order1.Products.Add(product2);

        var order2 = new Order{ OrderCustomer = customer2 };
        order2.Products.Add(product3);
        order2.Products.Add(product4);

        // Display order details
        Console.WriteLine(order1.GetPackageLabel());
        Console.WriteLine(order1.GetShipping());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():C}\n");

        Console.WriteLine(order2.GetPackageLabel());
        Console.WriteLine(order2.GetShipping());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}\n");
    }
}
