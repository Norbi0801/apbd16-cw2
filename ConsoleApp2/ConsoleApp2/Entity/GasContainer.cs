using ConsoleApp2.Abstract;
using ConsoleApp2.Interface;

namespace ConsoleApp2.Entity;

public class GasContainer: Container, IHazardNotifier, IHandlingCargo<Box<Gas>>
{
    private static double _coreOutWeightPercent = 0.95;
    public double Pressure { get; set; }

    public GasContainer(double height, double selfweight, double depth, double maxCapacity) : base(
        height, selfweight, depth, maxCapacity, GetContainerType())
    {
    }

    protected static char GetContainerType()
    {
        return 'G';
    }
    
    public Box<Gas> Unload()
    {
        double unloadWeight = Weight*_coreOutWeightPercent;
        Weight -= unloadWeight;

        return new Box<Gas>(unloadWeight);
    }

    public void Load(Box<Gas> box)
    {
        Weight += box.Weight;
        
        box.Clear();
    }
    
    public void HazardNotify(string? notification = null)
    {
        Console.Error.WriteLine($"{Sn} have danger situation: {notification}");
    }
}