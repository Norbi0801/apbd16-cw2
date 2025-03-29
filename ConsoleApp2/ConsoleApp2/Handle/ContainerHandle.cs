using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;

namespace ConsoleApp2.Handle;

public class ContainerHandle
{
    public static Container? Select;
    public static void Add()
    {
        Console.WriteLine("Podaj dane kontenera");
        Console.Write("Wysokość: ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Waga kontenera (kg): ");
        double selfWeight = Convert.ToDouble(Console.ReadLine());
        Console.Write("Głębia: ");
        double depth = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maksymalna całkowita waga(t) ładunku: ");
        double maxCargo = Convert.ToDouble(Console.ReadLine());
        
        // TODO: Change when implement container type
        
        Console.WriteLine("Wybierz rodzaj kontenera");
        Console.WriteLine("C - cold");
        Console.WriteLine("G - gas");
        Console.WriteLine("L - liquid");
        
        char kind = Convert.ToChar(Console.ReadLine() ?? string.Empty);

        switch (kind)
        {
            case 'C':
                new RefrigeratedContainer(height, selfWeight, depth, maxCargo);
                break;
            case 'G':
                new GasContainer(height, selfWeight, depth, maxCargo);
                break;
            case 'L':
                new LiquidContainer(height, selfWeight, depth, maxCargo);
                break;
        }
    }
    
    public static void SelectContainer()
    {
        Console.WriteLine("Podaj Sn ");
        string? sn = Console.ReadLine();
        var select = Container.ContainerList.Find((x)=>x.Sn.ToString() == sn);
        if (select != null)
        {
            Select = select;
        }
    }

    public static void LoadCargo()
    {
        
    }
}