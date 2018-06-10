using System;
using System.Collections.Generic;

namespace Find_Int_Pairs_That_Add_To_K
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] exampleInputOne = new int[] {1, 2, 3, 7, 5, 4, 8};
            int[] exampleInputTwo = new int[] {-2, 3, 4, -3, 6, 5, 1 ,7, 10};
            int[] exampleInputThree = new int[] {1, 3};
            Console.WriteLine("In the array { " + PrintArray(exampleInputOne) + "}");
            Find_Int_Pairs_That_Add_To_K(exampleInputOne, 10);

            Console.WriteLine("In the array { " + PrintArray(exampleInputTwo) + "}");
            Find_Int_Pairs_That_Add_To_K(exampleInputTwo, 10);

            Console.WriteLine("In the array { " + PrintArray(exampleInputThree) + "}");
            Find_Int_Pairs_That_Add_To_K(exampleInputThree, 10);
        }

        static string PrintArray(int[] userArray)
        {
            string formattedArray = "";
            for(int i = 0; i < userArray.Length; i++)
            {
                formattedArray += userArray[i] + ", ";
            }
            return formattedArray;
        }

        static void Find_Int_Pairs_That_Add_To_K(int[] exampleInput, int k)
        {
            Dictionary<int,int> MyDictionary = new Dictionary<int,int>();
            for(int i = 0; i < exampleInput.Length; i++)
            {
                MyDictionary.Add(exampleInput[i], i);
                if(MyDictionary.TryGetValue(k - exampleInput[i], out int value))
                {
                    Console.WriteLine("There is a pairing of [" + exampleInput[i] + "," + (k - exampleInput[i] + "]"));
                }
            }
        }
    }
}
