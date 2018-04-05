using System;
using Microsoft.Kinect;
//using Microsoft.Kinect.VisualGestureBuilder;
using System.Collections.Generic;

namespace Kinectures
{

    public class Controller
    {
        private const String JUMP = "Jump";
        private const String BENCH = "Bench";
        private const String LEFT = "Left";
        private const String RIGHT = "Right";
        private BodyFrameReader bodyFrameReader = null;
        private Body[] bodies = null;
        private int bodyIndex;
        private bool bodyTracked = false;
        private Dictionary<String, GestureListener> table;
        private Sensor sensor;
        public Controller()
        {
            this.table = new Dictionary<String, GestureListener>();
            this.sensor = new Sensor();
            this.bodyFrameReader = this.sensor.kinectSensor.BodyFrameSource.OpenReader();
        }

        public void AddListener(String gesture, GestureListener listener)
        {
            sensor.AddListener(listener);
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
                table[gesture].OnGesture();
            }
        }


        public void onFrame()
        {

        }

        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;

                    if (dataReceived)
                    {
                        Body body = null;
                        if (this.bodyTracked)
                        {
                            Joint head = body.Joints[JointType.Head];

                            float x = head.Position.X;
                            float y = head.Position.Y;
                            float z = head.Position.Z;

                            String g = null;

                            //Vector4 output = body.FloorClipPlane;
                            if (z > 20)
                            {
                                g = JUMP;
                                Console.WriteLine("Jump");
                            }
                            else if (z < -20)
                            {
                                g = BENCH;
                                Console.WriteLine("Bench");
                            }
                            else if (y > 20)
                            {
                                g = LEFT;
                                Console.WriteLine("Left");
                            }
                            else if (x > 20)
                            {
                                g = RIGHT;
                                Console.WriteLine("Right");
                            }
                            if (g != null)
                            {
                                NotifyListeners(g);
                            }

                            if (!bodyTracked)
                            {
                                for (int i = 0; i < this.bodies.Length; ++i)
                                {
                                    if (this.bodies[i].IsTracked)
                                    {
                                        this.bodyIndex = i;
                                        this.bodyTracked = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }


    }
}
