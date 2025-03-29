namespace ConsoleApp2;

public class Command
{
    public string Key;
    public string Mnemonic;
    public Func<bool> OnCondition;
    public Action ToDo;

    public Command(string key, string mnemonic, Func<bool> onCondition, Action todo)
    {
        Key = key;
        Mnemonic = mnemonic;
        OnCondition = onCondition;
        ToDo = todo;
    }

    public override string ToString()
    {
        return $"{Key}. {Mnemonic}";
    }
}