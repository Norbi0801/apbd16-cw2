using ConsoleApp2.Abstract;

namespace ConsoleApp2.Handle;

public class ContainerHandle
{
    public static Container? Select;
    public static void Add()
    {
        
        Console.WriteLine("Podaj dane kontenera");
        Console.Write("Wysokość: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Prędkość: ");
        double velocity = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maksymalna ilość kontenerów: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Maksymalna całkowita waga(t) ładunku: ");
        double maxCargo = Convert.ToInt32(Console.ReadLine());
        
        // new Container(name, velocity, n, maxCargo);
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
}