using System;

namespace My_Linked_List
{
    public class My_Linked_List
    {
        Node head;
        public class Node
        {
            public Node next;
            public int value { get; set; }
            public Node(int value)
            {
                this.value = value;
            }
        }
        public My_Linked_List(int value)
        {
            head = new Node(value);
        }
        private void Insert(Node newNode)
        {
        }
        public void Insert(int value)
        {
            Node newNode = new Node(value);
            this.Insert(newNode);
        } 

        public void Remove(int value)
        {
        }

        public void PrintAllNodes()
        {
            Node current = head;
            Console.Write("Elements: ");
            while(current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
