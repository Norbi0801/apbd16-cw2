using ConsoleApp2.Abstract;
using ConsoleApp2.Entity;
using ConsoleApp2.Handle;

namespace ConsoleApp2;

class Program
{
    public const string ExitKey = "exit";
    public static List<Command> CommandList = [
        new ("sa", "Dodaj kontenerowiec", 
            delegate { return true; }, ContainerShipHandle.Add),
        new ("ss", "Wybierz kontenerowiec", 
            delegate { return ContainerShip.ContainerShipList.Count > 0;}, ContainerShipHandle.SelectContainerShip),
        new ("so", "Odznacz kontenerowiec", 
            delegate { return ContainerShipHandle.Select != null;}, () => { ContainerShipHandle.Select = null;}),
        
        new ("ka", "Dodaj kontener", 
            delegate { return true; }, ContainerHandle.Add),
        new ("ks", "Wybierz kontener", 
            delegate { return Container.ContainerList.Count > 0;}, ContainerHandle.SelectContainer),
        new ("ko", "Odznacz kontener", 
            delegate { return ContainerHandle.Select != null;}, () => { ContainerHandle.Select = null;}),
        
        new ("kl", "Dodaj ładunek do kontenera",
            delegate { return ContainerHandle.Select != null;}, ContainerHandle.LoadCargo),

        new (ExitKey, "Wyłącz program", delegate { return true; }, () => {}),
    ];
    
    public static void Main(string[] args)
    {
        while (true)
        {
            Out.Display();
            string? command = Console.ReadLine();
            if (command == ExitKey)
            {
                break;
            }
            CommandList.FindAll((x)=> x.OnCondition()).Find((x) => x.Key == command)?.ToDo();
        }
    }
}

