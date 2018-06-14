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
            myLinkedList.Insert(12);
            myLinkedList.Insert(15);
            myLinkedList.InsertLast(32);
            myLinkedList.InsertLast(42);

            myLinkedList.Remove(6);

            myLinkedList.PrintAllNodes();
        }
    }
}
