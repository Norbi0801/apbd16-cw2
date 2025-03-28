using ConsoleApp2.Abstract;

namespace ConsoleApp2.Entity;

public class ContainerShip
{
    public static List<ContainerShip> ContainerShipList = new ();
    public List<Container> ContainerList { get; set; }
    
    public SerialNumber Sn { get; set; }
    public double Velocity { get; set; }
    public int MaxCountOfContainerList { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(double velocity, int maxCountOfContainerList, double maxWeight)
    {
        Sn = SerialNumber.Generate('S', "SHP");
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
    
    public void Put(List<Container> someList)
    {
        ContainerList.AddRange(someList);
    }

    public Container Replace(Container newContainer, SerialNumber replaceSerialNumber)
    {
        int? replaceContainerIndex = FindIndex(replaceSerialNumber);

        if (replaceContainerIndex == null)
        {
            throw new NullReferenceException("Replace container not found");
        }
        
        var replaceContainer = ContainerList[(int)replaceContainerIndex];
        
        ContainerList[(int)replaceContainerIndex] = newContainer;
        
        return replaceContainer;
    }

    private Container? Find(SerialNumber serialNumber)
    {
        return ContainerList.Find((container) => container.Sn == serialNumber);
    }
    
    private int? FindIndex(SerialNumber serialNumber)
    {
        return ContainerList.FindIndex((container) => container.Sn == serialNumber);
    }

    public override string ToString()
    {
        return $"{Sn} (velocity={Velocity}, maxCountOfContainers={MaxCountOfContainerList}, maxWeight={MaxWeight})";
    }
}