﻿namespace ConsoleApp2;

public class SerialNumber
{
    private static List<SerialNumber> _serialNumbers = new();
    
    private string Prefix { get; set; }
    // TODO: In future change ContainerType to class
    private char ContainerType { get; set; }
    private int Id { get; set; }

    private const string DefaultPrefix = "KON";

    private SerialNumber(char containerType, string prefix = DefaultPrefix)
    {
        Prefix = prefix;
        ContainerType = containerType;
        Id = _serialNumbers.Count + 1;
        
    }

    public static SerialNumber Generate(char containerType, string prefix = DefaultPrefix)
    {
        var sn = new SerialNumber(containerType, prefix);
        _serialNumbers.Add(sn);
        
        return sn;
    }
    
    public static bool Exists(int id)
    {
        return _serialNumbers.Any(x => x.Id == id);
    }

    public override string ToString()
    {
        return $"{Prefix}-{ContainerType}-{Id}";
    }
}
