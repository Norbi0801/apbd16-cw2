using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;
using ConsoleApp2.Handle;

namespace ConsoleApp2;

class Program
{
    public static List<Command> CommandList = [
        new ('A', "Dodaj kontenerowiec", delegate { return true; }, ContainerShipHandle.Add),
        new ('S', "Wybierz kontenerowiec", delegate { return ContainerShip.ContainerShipList.Count > 0;}, ContainerShipHandle.Add),
        new ('x', "Exit", delegate { return false; },  ContainerShipHandle.Add),
    ];
    
    public static void Main(string[] args)
    {
        while (true)
        {
            Out.Display();
            char command = Convert.ToChar(Console.ReadLine() ?? string.Empty);
            CommandList.FindAll((x)=> x.OnCondition()).Find((x) => x.Key == command)?.ToDo();
        }
    }
}

