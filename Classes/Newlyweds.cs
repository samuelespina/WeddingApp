using System;

public class Newlyweds
{
    private ushort _id;
    private User _wife;
    private User _husband;

    public ushort ID { get => _id; }

    public Newlyweds(ushort id, User husband, User wife)
    {
        _id = id;
        _husband = husband;
        _wife = wife;
    }

    public override string ToString()
    {
        return $"{_id}=> {_husband} - {_wife}";
    }
}