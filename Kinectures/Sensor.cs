using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Kinect;

namespace Kinectures
{
    /*
     * Initializes a Sensor, Frame Reader, Listeners and Event Handler
     */
    class Sensor
    {
        public List<KinectListener> listeners = null;
        public KinectSensor kinectSensor = null;
        public MultiSourceFrameReader multiSourceFrameReader = null;
        public Sensor()
        {
            this.listeners = new List<KinectListener>();
            this.kinectSensor = KinectSensor.GetDefault();
            this.kinectSensor.Open();
            
            this.multiSourceFrameReader = this.kinectSensor.OpenMultiSourceFrameReader(FrameSourceTypes.Body);
            this.multiSourceFrameReader.MultiSourceFrameArrived += MultiSourceFrameReader_MultiSourceFrameArrived;
        }

        /*
        * Notifies the listeners when a frame arrives
        */
        private void MultiSourceFrameReader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            BodyFrameReference reference;
            reference = e.FrameReference.AcquireFrame().BodyFrameReference;
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].Notify(reference);

            }
        }

        /*
        * Adds a Listener to the list
        */
        public void AddListener(KinectListener listener)
        {
            listeners.Add(listener);
        }

        /*
        * Removes a specific listener from the list
        */
        public void RemoveListener(KinectListener listener)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                // stop searching when the listener is removed
                if (listeners[i].GetId() == listener.GetId())
                {                    
                    listeners.Remove(listener);
                    return;
                }
            }
        }

        /*
        * Closes the Frame Reader and Sensor
        */
        public void CloseSensor()
        {
            if (this.multiSourceFrameReader != null)
            {
                this.multiSourceFrameReader.Dispose();
                this.multiSourceFrameReader = null;
            }

            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }
        }

    }
}
