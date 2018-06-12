using System;

namespace My_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            My_Queue myQueue = new My_Queue(20);

            myQueue.Enqueue(3);
            myQueue.Enqueue(23);
            myQueue.Enqueue(13);
            myQueue.Enqueue(15);

            myQueue.Dequeue();
            myQueue.Dequeue();

            myQueue.Enqueue(2);

            myQueue.PrintQueue();
        }
    }
}
