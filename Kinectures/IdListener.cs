using System;

public abstract class IListener
{
    static long nextId = 0;

    long id;

    public IListener()
	{
        id = nextId++;
	}

    public long GetId()
    {
        return id;
    }
}
