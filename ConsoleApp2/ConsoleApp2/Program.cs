using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;
using ConsoleApp2.Handle;

namespace ConsoleApp2;

class Program
{
    public const char ExitKey = 'X';
    public static List<Command> CommandList = [
        new ('A', "Dodaj kontenerowiec", delegate { return true; }, ContainerShipHandle.Add),
        new ('S', "Wybierz kontenerowiec", delegate { return ContainerShip.ContainerShipList.Count > 0;}, ContainerShipHandle.SelectContainerShip),
        new ('O', "Odznacz kontenerowiec", delegate { return ContainerShipHandle.Select != null;}, () => { ContainerShipHandle.Select = null;}),
        
        new ('K', "Dodaj kontener", delegate { return true; }, ContainerHandle.Add),
        new ('R', "Wybierz kontener", delegate { return Container.ContainerList.Count > 0;}, ContainerHandle.SelectContainer),
        new ('Q', "Odznacz kontener", delegate { return ContainerHandle.Select != null;}, () => { ContainerHandle.Select = null;}),
        

        new (ExitKey, "Exit", delegate { return false; }, () => {}),
    ];
    
    public static void Main(string[] args)
    {
        while (true)
        {
            Out.Display();
            char command = Convert.ToChar(Console.ReadLine() ?? string.Empty);
            if (command == ExitKey)
            {
                break;
            }
            CommandList.FindAll((x)=> x.OnCondition()).Find((x) => x.Key == command)?.ToDo();
        }
    }
}

