using System;

public class Address
{
    // Private member variables
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method to check if address is in USA
    public bool IsUSA()
    {
        // precise comparison, usually ignoring case is safer
        return _country.Trim().ToLower() == "usa";
    }

    // Method to return full address string
    public string GetDisplayText()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}