using System;
using System.Collections.Generic;

namespace Find_Most_Frequent_Int
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] exampleInputOne = new int[] {1, 2, 3, 7, 5, 5, 7, 4, 7, 7, 4, 3, 8};
            int[] exampleInputTwo = new int[] {-2, 3, 4, -2};
            int[] exampleInputThree = new int[] {1};

            Console.WriteLine("The first three examples first sort their respective arrays and then count identical consecutive integers.");
            Console.WriteLine(@"The next three store characters in a hashtable and increment a counter 
            for each one, afterwards the hashtable is iterated on and the most frequent integer is returned");

            DisplayMostCommonIntegerSorting(exampleInputOne);
            DisplayMostCommonIntegerSorting(exampleInputTwo);
            DisplayMostCommonIntegerSorting(exampleInputThree);

            Console.WriteLine("");

            DisplayMostCommonIntegerDictionary(exampleInputOne);
            DisplayMostCommonIntegerDictionary(exampleInputTwo);
            DisplayMostCommonIntegerDictionary(exampleInputTwo);
        } //Drive the running of the two separate algorithms

        static void DisplayMostCommonIntegerSorting(int[] exampleInput)
        {
            Console.WriteLine("In the array " + PrintArray(exampleInput));
            int mostCommonInteger = MostCommonIntegerUsingSorting(exampleInput);
            Console.WriteLine("The most frequently occuring integer is " + mostCommonInteger + ".\n");
        }

        static void DisplayMostCommonIntegerDictionary(int[] exampleInput)
        {
            Console.WriteLine("In the array " + PrintArray(exampleInput));
            int mostCommonInteger = MostCommonIntegerUsingDictionary(exampleInput);
            Console.WriteLine("The most frequently occuring integer is " + mostCommonInteger + ".\n");
        }

        static string PrintArray(int[] userArray)
        {
            string formattedArray = "";
            for(int i = 0; i < userArray.Length; i++)
            {
                formattedArray += userArray[i] + " ";
            }
            return formattedArray;
        }

        static int MostCommonIntegerUsingDictionary(int[] input)
        {
            if(input.Length <= 0)
                throw new ArgumentException();
            
            Dictionary<int, int> elementCount = new Dictionary<int, int>();
            for(int i = 0; i < input.Length - 1; i++)
            {
                if(!elementCount.ContainsKey(input[i]))
                {
                    elementCount.Add(input[i], 1);
                }
                else
                {
                    int value;
                    if(elementCount.TryGetValue(input[i], out value))
                    {
                        elementCount.Remove(input[i]);
                        elementCount.Add(input[i], value + 1);
                    }
                }
            } //Most common element and the counts are held and switched accordingly

            int count = 0;
            int mostCommonInteger = input[0];
            foreach(var item in elementCount)
            {
                if(item.Value > count)
                {
                    count = item.Value;
                    mostCommonInteger = item.Key;
                }
            }
            return mostCommonInteger;
        }

        static int MostCommonIntegerUsingSorting(int[] input)
        {
            if(input.Length <= 0)
                throw new ArgumentException();

            Array.Sort(input);

            int mostCommonInteger = input[0];
            int integerCount = 0;
            int tempIntegerCount = 0;
            for(int i = 0; i < input.Length - 1; i++)
            {
                if(input[i] == input[i + 1])
                {
                    tempIntegerCount++;
                }
                if(tempIntegerCount > integerCount)
                {
                    integerCount = tempIntegerCount;
                    mostCommonInteger = input[i];
                }
            } //Most common element and the counts are held and switched accordingly
            
            return mostCommonInteger;
        }
    }
}
