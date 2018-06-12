using System;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedValues = new int[] {1, 3, 5, 6, 2, 5, 1, 8, 4 ,6, 30, 23, 12, 5, 5, 2};
            Console.Write("Sorting values: ");
            PrintArray(unsortedValues);
            PrintArray(Merge_Sort(unsortedValues));
        }
        
        static int[] Merge_Sort(int[] arr)
        {
            return null;
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
