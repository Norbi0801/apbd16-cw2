namespace ConsoleApp2.Interface;

public interface IHandlingCargo<T>
{
    public T Unload();

    public void Load(T some);
}