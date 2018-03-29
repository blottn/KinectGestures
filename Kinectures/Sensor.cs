using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Kinect;

namespace Kinectures
{
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

        private void MultiSourceFrameReader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            BodyFrameReference reference;
            reference = e.FrameReference.AcquireFrame().BodyFrameReference;
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].notify(reference);

            }
        }


        // adds a Listener to the List
        public void AddListener(KinectListener listener)
        {
            listeners.Add(listener);
        }

        // removes a Listener from the List
        public void RemoveListener(KinectListener listener)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                if (listeners[i].GetId() == listener.GetId())
                {
                    listeners.Remove(listener);
                    return;     // stop if listener has been removed
                }
            }
        }

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
