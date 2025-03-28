using ConsoleApp2.Abstract;
using ConsoleApp2.Exception;
using ConsoleApp2.Interface;

namespace ConsoleApp2.Entity;

public class RefrigeratedContainer : Container, IHazardNotifier, IHandlingCargo<Box<Product>>
{
    public double MaxKeepTemperature { get; set; }
    private Product? _product;

    public Product? Product
    {
        get => _product;
        set
        {
            if (value != null && MaxKeepTemperature > value.Temperature)
            {
                HazardNotify($"Container maximum temperature is {MaxKeepTemperature}. Product {value.Name} required {value.Temperature}.");
            }
            
            if (_product != null && _product.Equals(value))
            {
                throw new NotSupportMixCargoException();
            }
            _product = value;
        }
    }
    public RefrigeratedContainer(double height, double selfweight, double depth, double maxCapacity) : base(
        height, selfweight, depth, maxCapacity, GetContainerType())
    {
    }
    
    protected static char GetContainerType()
    {
        return 'C';
    }

    public void HazardNotify(string? notification = null)
    {
        Console.Error.WriteLine($"{Sn} have danger situation: {notification}");
    }
    
    public Box<Product> Unload()
    {
        double unloadWeight = Weight;
        Weight = 0;

        return new Box<Product>(Product, unloadWeight);
    }

    public void Load(Box<Product> box)
    {
        Product = box.Content;
        Weight += box.Weight;
        
        box.Clear();
    }
}