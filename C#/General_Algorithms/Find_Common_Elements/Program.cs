using System;
using System.Collections.Generic;

namespace Find_Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = new int[] {1, 2, 3, 6, 7};
            int[] arrayTwo = new int[] {1, 6, 4, 5, 2};
            Console.WriteLine("The common elements of the follow two arrays:");
            PrintElements(arrayOne);
            PrintElements(arrayTwo);

            Console.WriteLine("Are the below elements:");
            PrintElements(FindCommonElements(arrayOne, arrayTwo));
        }
        static void PrintElements(int[] commonElements)
        {
            Console.Write("{");
            for(int i = 0;i < commonElements.Length; i++)
            {
                Console.Write(commonElements[i]);
                if(i != (commonElements.Length - 1))
                    Console.Write(", ");
            }
            Console.WriteLine("}");
        }
        static int[] FindCommonElements(int[] arrayOne, int[] arrayTwo)
        {
            List<int> commonElements = new List<int>();
            Dictionary<int,int> MyDictionary = new Dictionary<int,int>();
            for(int i = 0; i < arrayOne.Length; i++)
            {
                if(!MyDictionary.ContainsKey(arrayOne[i]))
                {
                    MyDictionary.Add(arrayOne[i], i);
                }
            }

            for(int i = 0; i < arrayTwo.Length; i++)
            {
                if(MyDictionary.ContainsKey(arrayTwo[i]))
                {
                    commonElements.Add(arrayTwo[i]);
                }
            }

            return commonElements.ToArray();
        }
    }
}
