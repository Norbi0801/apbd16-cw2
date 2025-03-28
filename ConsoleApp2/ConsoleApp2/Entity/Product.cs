namespace ConsoleApp2.Entity;

public class Product
{
    private string _name;
    private double _temperature;

    public string Name => _name;
        
    public double Temperature => _temperature;

    Product(string name, double temperature)
    {
        _name = name;
        _temperature = temperature;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is not Product other)
            return false;

        return Name == other.Name && Temperature.Equals( other.Temperature);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Temperature);
    }
}