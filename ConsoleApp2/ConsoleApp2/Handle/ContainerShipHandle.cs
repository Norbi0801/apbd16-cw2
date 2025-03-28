using ConsoleApp2.Entity;

namespace ConsoleApp2.Handle;

public class ContainerShipHandle
{
    public static void Add()
    {
        Console.WriteLine("Podaj dane kontenerowca");
        Console.Write("Nazwa: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Prędkość: ");
        double velocity = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maksymalna ilość kontenerów: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Maksymalna całkowita waga(t) ładunku: ");
        double maxCargo = Convert.ToInt32(Console.ReadLine());
        
        new ContainerShip(name, velocity, n, maxCargo);
    }
}