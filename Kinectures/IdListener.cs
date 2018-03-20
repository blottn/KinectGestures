using System;

public abstract class IListener
{
    static long nextId = 0;

    long id;

    public IListener()
	{
        id = nextId++;
	}

    protected long getId()
    {
        return id;
    }
}
