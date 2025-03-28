using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;
using ConsoleApp2.Handle;

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

        if (ContainerShipHandle.Select != null)
        {
            Console.WriteLine("Wybrany kontenerowiec: ");
            Console.WriteLine(ContainerShipHandle.Select.Sn);
            Console.WriteLine();
        }
        
        if (ContainerHandle.Select != null)
        {
            Console.WriteLine("Wybrany kontener: ");
            Console.WriteLine(ContainerHandle.Select.Sn);
            Console.WriteLine();
        }

        DisplayList("Możliwe akcje", Program.CommandList.FindAll((x)=> x.OnCondition()));
    }
}