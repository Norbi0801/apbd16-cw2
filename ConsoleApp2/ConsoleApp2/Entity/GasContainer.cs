using ConsoleApp2.Abstract;

namespace ConsoleApp2.Entity;

public class GasContainer: Container
{
    private static double _coreOutWeightPercent = 0.95;
    
    GasContainer(double weight, double height, double selfweight, double depth) : base(weight, height, selfweight, depth)
    {
        Sn = new SerialNumber(GetContainerType());
    }

    protected sealed override char GetContainerType()
    {
        return 'G';
    }
    
    protected sealed override double Unload()
    {
        double unloadWeight = Weight*_coreOutWeightPercent;
        Weight -= unloadWeight;

        return unloadWeight;
    }
    
    public void HazardNotify(string? notification = null)
    {
        Console.Error.WriteLine($"{Sn} have danger situation: {notification}");
    }
}