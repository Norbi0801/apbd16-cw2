namespace ConsoleApp2;

public class Command
{
    public char Key;
    public string Mnemonic;
    public Func<bool> OnCondition;
    public Action ToDo;

    public Command(char key, string mnemonic, Func<bool> onCondition, Action todo)
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