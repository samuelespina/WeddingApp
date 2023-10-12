using System;

public class Gift
{

    private int _id;

    private string _description, _name;

    private double _price;

    public string Description { get => _description; }

    public double Price { get => _price; }

    public string Name { get => _name; }

    public Gift(int id, string name, string description, double price)
    {

        _id = id;
        _name = name;
        _description = description;
        _price = price;

    }

    public override string ToString()
    {
        return $"{_name} {_description} {_price}€";
    }
}