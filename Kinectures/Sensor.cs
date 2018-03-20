using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Kinect;

namespace Kinectures
{
    class Sensor
    {
        public List<Listener> listeners = null;
        public KinectSensor kinectSensor = null;
        
        public Sensor()
        {
            this.listeners = new List<Listener>();
            this.kinectSensor = KinectSensor.GetDefault();
            // init kinect polling
        }

        // adds a Listener to the List
        public void AddListener(Listener listener)
        {
            listeners.Add(listener);
        }

        // removes a Listener from the List
        public void RemoveListener(Listener listener)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                if (listeners[i].GetID() == listener.GetID())
                {
                    listeners.Remove(listener);
                    return;     // stop if listener has been removed
                }
            }
        }

        /*
         * TODO:
         * POLL SENSOR, NOTIFY LISTENERS WHEN A FRAME IS AVAILABLE
         */

    }
}
