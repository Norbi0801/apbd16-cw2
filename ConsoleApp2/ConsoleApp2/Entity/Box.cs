namespace ConsoleApp2.Entity;

public class Box<T>
{
    public T? Content { get; set; }
    public double Weight { get; set; }

    public Box(T? content, double weight)
    {
        Content = content;
        Weight = weight;
    }
    
    public Box(double weight)
    {
        Weight = weight;
    }

    public void Clear()
    {
        Content = default;
        Weight = 0;
    }
}