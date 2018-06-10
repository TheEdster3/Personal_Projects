using System;

namespace Fibonacci_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] fib = Fibonacci_Dynamic(20);
            for(int i = 0; i < fib.Length - 2; i++)
            {
                Console.Write(fib[i] + " ");
            }
        }

        static int[] Fibonacci_Dynamic(int n)
        {
            if(n == 0)
                return new int[] {0};
            int[] fib = new int[n + 2]; //Prevents out of bounds with a small arrays
            fib[0] = 0;
            fib[1] = 1;

            for(int i = 2; i < n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib;
        }
    }
}
