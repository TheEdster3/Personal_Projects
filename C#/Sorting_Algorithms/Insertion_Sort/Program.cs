using System;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedValues = new int[] {1, 3, 5, 6, 2, 5, 1, 8, 4 ,6, 30, 23, 12, 5, 5, 2};
            Console.Write("Sorting values: ");
            PrintArray(unsortedValues);
            PrintArray(Insertion_Sort(unsortedValues));
        }
        
        static int[] Insertion_Sort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
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
