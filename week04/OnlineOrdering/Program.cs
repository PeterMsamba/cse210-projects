using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1: USA Customer
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "A100", 1000, 1));
        order1.AddProduct(new Product("Mouse", "M200", 25, 2));
        order1.AddProduct(new Product("Cable", "C300", 10, 3));

        // ORDER 2: International Customer
        Address address2 = new Address("456 Likuni NRC", "Lilongwe", "QC", "Malawi");
        Customer customer2 = new Customer("Peter Msamba", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Smartphone", "P500", 800, 1));
        order2.AddProduct(new Product("Case", "X99", 20, 1));
        
        // Create a list of orders to iterate easily
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine();
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("\nTotal Cost: $" + order.CalculateTotalCost());
            Console.WriteLine("---------------------------------------------");
        }
    }
}