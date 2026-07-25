using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: Domestic customer
        Address address1 = new Address("123 Main St", "Boise", "Idaho", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "SKU-1001", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "SKU-1002", 9.99, 3));
        order1.AddProduct(new Product("Laptop Stand", "SKU-1003", 34.99, 1));

        // Order 2: International customer
        Address address2 = new Address("45 Independence Ave", "Windhoek", "Khomas", "Namibia");
        Customer customer2 = new Customer("Anselm Kadhila", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "SKU-2001", 89.99, 1));
        order2.AddProduct(new Product("Monitor Arm", "SKU-2002", 45.50, 1));

        // Display Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine("--- Packing Label ---");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\n--- Shipping Label ---");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalPrice():0.00}");

        Console.WriteLine("\n===============================\n");

        // Display Order 2
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine("--- Packing Label ---");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\n--- Shipping Label ---");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.GetTotalPrice():0.00}");
    }
}