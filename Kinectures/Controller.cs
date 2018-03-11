using System;
using Microsoft.Kinect;
using System.Collections.Generic.IDictionary;

public class Controller
{
    public Controller()
    {
        Dictionary<Gesture, Listener> hashTable = new Dictionary<Gesture, Listener>();
    }

    public void addListener(Gesture g,Listener l)
    {
        this.hashTable.Add(g,l);
    }

    public void removeListener(Listener l)
    {
        this.hashTable.Remove(l);
    }
    private void notifyListeners(Gesture g)
    {
        Listener val;
        if (hashTable.TryGetValue(g, out val))
        {
            //code to notify listener
        }
    }

    public void initilizeSensor()
    {
        Sensor s = new Sensor();
    }
    public static void Main()
    {
        

    }
}
