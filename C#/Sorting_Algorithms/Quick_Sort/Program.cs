using System;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedValues = new int[] {1, 3, 5, 6, 2, 5, 1, 8, 4 ,6, 30, 23, 12, 5, 5, 2};
            Console.Write("Sorting values: ");
            PrintArray(unsortedValues);
            Quick_Sort(unsortedValues, 0, unsortedValues.Length - 1);
            PrintArray(unsortedValues);
        }
        
        static void Quick_Sort(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int pivot = arr[(left + right) / 2];
 
            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
 
                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
 
                if (i <= j)
                {
                    // Swap
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
            {
                Quick_Sort(arr, left, j);
            }
 
            if (i < right)
            {
                Quick_Sort(arr, i, right);
            }
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
