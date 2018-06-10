using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World: " + Reverse_String("Hello World"));
            Console.WriteLine("Watermelon: " + Reverse_String("Watermelon"));
            Console.WriteLine("racecar: " + Reverse_String("racecar"));
            Console.WriteLine("Reverse this string: " + Reverse_String("Reverse this string"));
            Console.Write("This was reversed recursively: ");
            Console.WriteLine(Reverse_String_Recursive("This was reversed recursively"));

        }

        static string Reverse_String(string userInput)
        {
            string reversedString = "";
            for(int i = userInput.Length - 1; i >= 0; i--)
            {
                reversedString += userInput[i];
            }
            return reversedString;
        }

        static string Reverse_String_Recursive(string userInput)
        {
            if(userInput.Length == 1)
                return userInput[0].ToString();
            
            Console.Write(userInput[userInput.Length - 1]);
            return Reverse_String_Recursive(userInput.Substring(0, userInput.Length - 1));
        }
    }
}
