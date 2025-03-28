using ConsoleApp2.Abstract;
using ConsoleApp2.Enum;
using ConsoleApp2.Exception;
using ConsoleApp2.Interface;

namespace ConsoleApp2.Entity;

public class LiquidContainer : Container, IHazardNotifier, IHandlingCargo<Box<Liquid>>
{
    protected new double Weight
    {
        get => _weight;
        set
        {
            if (Liquid == null)
            {
                throw new NullReferenceException();
            }
            var threshold = Liquid.Type == ELiquidType.Danger ? DangerLiquidThreshold : NormalLiquidThreshold;
            
            if (value > MaxCapacity * threshold)
            {
                HazardNotify();
            }
            
            if (value > MaxCapacity)
            {
                throw new OverfillException();
            }
            _weight = value;
        }
    }
    
    private Liquid? _liquid;

    public Liquid? Liquid
    {
        get => _liquid;
        set
        {
            if (_liquid != null && _liquid.Equals(value))
            {
                throw new NotSupportMixCargoException();
            }
            _liquid = value;
        }
    }

    private const double DangerLiquidThreshold = 0.9;
    private const double NormalLiquidThreshold = 0.5;

    public LiquidContainer(double height, double selfweight, double depth, double maxCapacity) : base(
        height, selfweight, depth, maxCapacity, GetContainerType())
    {
    }

    protected static char GetContainerType()
    {
        return 'L';
    }

    public void HazardNotify(string? notification = null)
    {
        Console.Error.WriteLine($"{Sn} have danger situation: {notification}");
    }

    public Box<Liquid> Unload()
    {
        double unloadWeight = Weight;
        Weight = 0;

        return new Box<Liquid>(Liquid, unloadWeight);
    }

    public void Load(Box<Liquid> box)
    {
        Liquid = box.Content;
        Weight += box.Weight;
        
        box.Clear();
    }
}