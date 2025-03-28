using ConsoleApp2.Entity;

namespace ConsoleApp2.Handle;

public class ContainerShipHandle
{
    public static ContainerShip? Select;
    public static void Add()
    {
        Console.WriteLine("Podaj dane kontenerowca");
        Console.Write("Prędkość: ");
        double velocity = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maksymalna ilość kontenerów: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Maksymalna całkowita waga(t) ładunku: ");
        double maxCargo = Convert.ToInt32(Console.ReadLine());
        
        new ContainerShip(velocity, n, maxCargo);
    }

    public static void SelectContainerShip()
    {
        Console.WriteLine("Podaj Sn ");
        string? sn = Console.ReadLine();
        var select = ContainerShip.ContainerShipList.Find((x)=>x.Sn.ToString() == sn);
        if (select != null)
        {
            Select = select;
        }
    }
}