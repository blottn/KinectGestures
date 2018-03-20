using System;
using Microsoft.Kinect;
using System.Collections.Generic;

namespace Kinectures
{

    public class Controller
    {
        private Dictionary<String, GestureListener> table;
        private Sensor sensor;
        public Controller()
        {
            this.table = new Dictionary<String, GestureListener>();
            this.sensor = new Sensor();
        }

        public void AddListener(String gesture, GestureListener listener)
        {
            this.table.Add(gesture, listener);
        }

        public void RemoveListener(String gesture, GestureListener listener)
        {
            this.table.Remove(gesture);
        }

        private void NotifyListeners(String gesture)
        {
            if (table[gesture] != null)
            {
                table[gesture].Notify();
            }
        }
    }
}
