using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;

namespace ConsoleApp2;

public class Out
{
    private static void DisplayList<T>(string description, List<T> list)
    {
        Console.WriteLine($"{description}: ");
        list.ForEach(element => Console.WriteLine(element));
        Console.WriteLine();
    }
    public static void Display()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("------------------------------------System Do Kontenerów----------------------------------");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        
        DisplayList("Lista kontenerowców", ContainerShip.ContainerShipList);
        DisplayList("Lista kontenerów", Container.ContainerList);
        DisplayList("Możliwe akcje", Program.CommandList.FindAll((x)=> x.OnCondition()));
    }
}