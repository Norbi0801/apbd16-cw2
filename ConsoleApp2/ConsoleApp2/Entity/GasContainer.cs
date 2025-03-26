using ConsoleApp2.Abstract;

namespace ConsoleApp2.Entity;

public class GasContainer: Container
{
    private static double _coreOutWeightPercent = 0.85;
    
    GasContainer(double weight, double height, double selfweight, double depth) : base(weight, height, selfweight, depth)
    {
        Sn = new SerialNumber(GetContainerType());
    }

    protected sealed override char GetContainerType()
    {
        return 'G';
    }
}