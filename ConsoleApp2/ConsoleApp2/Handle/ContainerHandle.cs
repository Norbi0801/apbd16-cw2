namespace ConsoleApp2.Handle;

public class ContainerHandle
{
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
}