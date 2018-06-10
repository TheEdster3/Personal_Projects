using System;

namespace Is_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World: " + Is_Palindrome("Hello World"));
            Console.WriteLine("Watermelon: " + Is_Palindrome("Watermelon"));
            Console.WriteLine("racecar: " + Is_Palindrome("racecar"));
            Console.WriteLine("ToToT: " + Is_Palindrome("ToToT"));
        }

        static bool Is_Palindrome(string userInput)
        {
            for(int i = 0, j = userInput.Length - 1; i < j; i++, j--)
            {
                if(userInput[i] != userInput[j])
                    return false;
            }

            return true;
        }
    }
}
