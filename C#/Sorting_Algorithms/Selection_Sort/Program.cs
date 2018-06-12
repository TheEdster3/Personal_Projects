using System;
using System.Collections.Generic;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedValues = new int[] {1, 3, 5, 6, 2, 5, 1, 8, 4 ,6, 30, 23, 12, 5, 5, 2};
            Console.Write("Sorting values: ");
            PrintArray(unsortedValues);
            PrintArray(Selection_Sort(unsortedValues));
        }
        
        static int[] Selection_Sort(int[] arr)
        {
            int index = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                for(int j = i; j < arr.Length; j++)
                {
                    if(arr[j] < min)
                    {
                        min = arr[j];
                        index = j;
                    }
                }
                if(arr[i] > min)
                {
                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;
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