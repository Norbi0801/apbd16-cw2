namespace ConsoleApp2.Entity;

public class Product
{
    public required string Name { get; set; }
    public required double Temperature { get; set; }

    Product(string name, double temperature)
    {
        Name = name;
        Temperature = temperature;
    }
    
    
}