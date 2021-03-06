using System;

namespace BST_Tree
{
    class MyBST
    {
        public Node root { get; set; }
        public class Node
        {
            public int value;
            public Node left;
            public Node right;
        }

        public void PrintTreeInOrder(Node node)
        {
            if(node != null)
            {   
                if(node.right != null)
                    PrintTreeInOrder(node.right);
                    
                Console.WriteLine(node.value);

                if(node.left != null)
                    PrintTreeInOrder(node.left);
            }
        }
        
        public void Insert(int data)
        {
            Node newNode = new Node();
            newNode.value = data;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (current != null)
                {
                    parent = current;
                    if (data < current.value)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void Delete(Node nodeToBeDeleted)
        {
            if(root == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                Node current = root;
                Node parent;
                while(current != null)
                {
                    parent = current;
                    if(nodeToBeDeleted.value < current.value)
                    {
                        if(current.left == null && current.right == null)
                        {
                            Console.WriteLine(nodeToBeDeleted.value + " Does not exist in the tree");
                        }
                        if(current.left != null)
                        {
                            current = current.left;
                        }
                    }
                    else if(nodeToBeDeleted.value > current.value)
                    {
                        if(current.left == null && current.right == null)
                        {
                            Console.WriteLine(nodeToBeDeleted.value + " Does not exist in the tree");
                        }
                        if(current.right != null)
                        {
                            current = current.right;
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }
        public void Delete(int value)
        {
            MyBST.Node selectedNode = new MyBST.Node();
            selectedNode.value = value;
            this.Delete(selectedNode);
        }
    }
}