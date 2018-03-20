namespace Kinectures
{
    public class GestureListener
    {
        static long nextId = 0;

        long id = 0;

        public GestureListener()
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
