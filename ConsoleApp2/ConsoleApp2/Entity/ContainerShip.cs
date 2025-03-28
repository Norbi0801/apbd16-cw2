using ConsoleApp2.Abstract;

namespace ConsoleApp2.Entity;

public class ContainerShip
{
    public static List<ContainerShip> ContainerShipList = new ();
    public List<Container> ContainerList { get; set; }
    public double Velocity { get; set; }
    public double MaxCountOfContainerList { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(double velocity, double maxCountOfContainerList, double maxWeight)
    {
        Velocity = velocity;
        MaxCountOfContainerList = maxCountOfContainerList;
        MaxWeight = maxWeight;
        ContainerList = new List<Container>();
        
        ContainerShipList.Add(this);
    }
    
    public Container Get(SerialNumber serialNumber)
    {
        var container = Find(serialNumber);
        
        if (container == null)
        {
            throw new NullReferenceException("Container not found");
        }
        
        ContainerList.Remove(container);
        
        return container;
    }
    

    public void Put(Container some)
    {
        ContainerList.Add(some);
    }

    private Container? Find(SerialNumber serialNumber)
    {
        return ContainerList.Find((container) => container.Sn == serialNumber);
    }
}