using System;

namespace My_Stack
{
    public class My_Stack
    {
        Stack_Entry[] arr;
        int size;
        public class Stack_Entry
        {
            public int value { get; set; }
            public Stack_Entry(int value)
            {
                this.value = value;
            }
        }
        public My_Stack(int size)
        {
            arr = new Stack_Entry[size];
            this.size = size;
        }
        public void Push(int value)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == null)
                {
                    Console.WriteLine("Pushed value: " + value + " onto the stack");
                    arr[i] = new Stack_Entry(value);
                    break;
                }
            }
        }
        public void Pop()
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if((i + 1 < arr.Length) && arr[i + 1] == null)
                {
                    int entryValue = arr[i].value;
                    arr[i] = null;
                    Console.WriteLine("Popped value: " + entryValue + " off of the stack");
                    break;
                }
            }
            
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