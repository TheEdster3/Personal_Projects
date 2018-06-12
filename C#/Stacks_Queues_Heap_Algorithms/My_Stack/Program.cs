using System;

namespace My_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            My_Stack myStack = new My_Stack(20);
            myStack.Push(23);
            myStack.Push(21);
            myStack.Push(11);
            myStack.Push(5);

            myStack.Pop();
            myStack.Pop();
            myStack.Pop();

            Console.WriteLine("Count: " + myStack.Count());
        }
    }
}
