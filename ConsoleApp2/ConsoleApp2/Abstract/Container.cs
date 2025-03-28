using ConsoleApp2.Exception;

namespace ConsoleApp2.Abstract;

public abstract class Container
{
    private protected double _weight;
    protected double Weight
    {
        get => _weight;
        set
        {
            if (value > MaxCapacity)
            {
                throw new OverfillException();
            }
            _weight = value;
        }
    }

    protected double Height { get; set; }
    protected double TareWeight { get; set; }
    protected double Depth { get; set; }

    protected SerialNumber? Sn { get; set; }
    protected double MaxCapacity { get; set; }

    protected Container(double weight, double height, double tareWeight, double depth, double maxCapacity, char containerType)
    {
        Weight = weight;
        Height = height;
        TareWeight  = tareWeight;
        Depth = depth;
        Sn = SerialNumber.Generate(containerType);
        MaxCapacity = maxCapacity;
    }
    
    protected virtual char Ini()
    {
        throw new NotSupportedException();
    }

}