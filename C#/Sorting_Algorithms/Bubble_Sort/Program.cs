using System;
using System.Collections.Generic;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedValues = new int[] {1, 3, 5, 6, 2, 5, 1, 8, 4 ,6};
            Console.Write("Sorting values: ");
            PrintArray(unsortedValues);
            PrintArray(Bubble_Sort(unsortedValues));
        }

        static int[] Bubble_Sort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
