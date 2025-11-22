using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        // 1. Sum up the cost of all products
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // 2. Add shipping cost based on location
        // Logic: USA = $5, International = $35
        int shippingCost = _customer.LiveInUSA() ? 5 : 35;
        
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += $"{p.GetName()} (ID: {p.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddress().GetDisplayText();
        return label;
    }
}