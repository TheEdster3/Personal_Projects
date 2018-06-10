using System;

namespace Fibonacci_Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFibonacci(20);
        }
        
        static void PrintFibonacci(int n)
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write(Fibonacci_Recursive(i) + " ");
            }
        }
        static int Fibonacci_Recursive(int n)
        {
            if(n == 0)
                return 0;
            if(n == 1)
                return 1;
            int tempNumber = Fibonacci_Recursive(n - 2) + Fibonacci_Recursive(n - 1);
            return tempNumber;
        }
    }
}
