using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;

namespace ConsoleApp2;

class Program
{
    private static void DisplayList<T>(string description, List<T> list)
    {
        Console.WriteLine(description,':');
        list.ForEach(element => Console.WriteLine(element));
    }
    private static void Display()
    {
        DisplayList("Lista kontenerowców", ContainerShip.ContainerShipList);
        DisplayList("Lista kontenerów", Container.ContainerList);
        DisplayList("Możliwe akcje", ContainerShip.ContainerShipList);
    }
    
    public static void Main(string[] args)
    {
        while (true)
        {
            
        }
    }
}