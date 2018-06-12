using System;

namespace My_Queue
{
    public class My_Queue
    {
        Queue_Entry[] arr;
        int size;
        int min;
        public class Queue_Entry
        {
            public int value { get; set; }
            public Queue_Entry(int value)
            {
                this.value = value;
            }
        }
        public My_Queue(int size)
        {
            arr = new Queue_Entry[size];
            this.size = size;
        }
        public void GetMin()
        {

        }
        public void Enqueue(int value)
        {
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                if((i + 1) < arr.Length && arr[i] != null || i == 0)
                {
                    arr[i + 1] = new Queue_Entry(value);
                    Console.WriteLine("Enqueued value: " + value);
                    break;
                }
            }
        }
        public void Dequeue()
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != null)
                {
                    int value = arr[i].value;
                    arr[i] = null;
                    Console.WriteLine("Dequeued value: " + value);
                    break;
                }
            }
        }

        public void PrintQueue()
        {
            Console.Write("Current Elements: ");
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != null)
                    Console.Write(arr[i].value + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Count: " + this.Count());
        }
        public int Count()
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}