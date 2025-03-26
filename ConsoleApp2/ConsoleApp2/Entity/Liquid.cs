using ConsoleApp2.Enum;

namespace ConsoleApp2.Entity;

public class Liquid
{
    private string _name;
    private ELiquidType _type;

    public string Name => _name;
        
    public ELiquidType Type => _type;

    Liquid(string name, ELiquidType type)
    {
        _name = name;
        _type = type;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Liquid other)
            return false;

        return Name == other.Name && Type == other.Type;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Type);
    }
}