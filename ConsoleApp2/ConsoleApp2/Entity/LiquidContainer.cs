using ConsoleApp2.Abstract;
using ConsoleApp2.Enum;
using ConsoleApp2.Exception;
using ConsoleApp2.Interface;

namespace ConsoleApp2.Entity;

public class LiquidContainer : Container, IHazardNotifier
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

    public LiquidContainer(double weight, double height, double selfWeight, double depth) : base(weight, height, selfWeight, depth)
    {
        Sn = new SerialNumber(GetContainerType());
    }

    protected sealed override char GetContainerType()
    {
        return 'L';
    }

    public void HazardNotify(string? notification = null)
    {
        Console.Error.WriteLine($"{Sn} have danger situation: {notification}");
    }

    public void Load(Liquid liquid, double weight)
    {
        Liquid = liquid;
        base.Load(weight);
    }

    public override void Load(double weight)
    {
        throw new NotSupportedException();
    }

    protected sealed override double Unload()
    {
        throw new NotSupportedException();
    }
}