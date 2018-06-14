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
            public Node()
            {
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
            newNode.next = head;
            head = newNode;
            //this.Insert(newNode);
        } 
        public void InsertLast(int value)
        {
            Node tempNode = new Node();
            Node newNode = new Node(value);
            if(head == null)
            {
                head = newNode;
                return;
            }
            tempNode = head;
            while(tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            tempNode.next = newNode;
        }
        public void Remove(int value)
        {
            Node temp = head;
            Node prev = null;
            if(temp != null && temp.value == value)
            {
                head = temp.next;
                return;
            }
            while(temp != null && temp.value != value)
            {
                prev = temp;
                temp = temp.next;
            }
            if(temp == null)
            {
                return;
            }
            prev.next = temp.next;
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
