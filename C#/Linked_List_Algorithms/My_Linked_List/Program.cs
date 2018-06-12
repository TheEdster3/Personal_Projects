using System;

namespace My_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            My_Linked_List myLinkedList = new My_Linked_List(3);
            myLinkedList.Insert(6);
            myLinkedList.Insert(9);

            //myLinkedList.Remove(6);

            myLinkedList.PrintAllNodes();
        }
    }
}
