using System;
using System.Collections.Generic;
using System.Text;

namespace Kinectures
{
    public class Listener
    {
        static long nextId = 0;
        long id = 0;
        public Listener()
        {
            id = nextId++;
        }
        
        public long GetID()
        {
            return this.id;
        }
        
        public void Notify()
        {
            
        }
    }
}
