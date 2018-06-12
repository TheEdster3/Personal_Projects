using System;

namespace BST_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBST customBST = new MyBST();
            customBST.Insert(15);
            customBST.Insert(12);
            customBST.Insert(34);
            customBST.Insert(1);
            customBST.Insert(54);
            customBST.PrintTreeInOrder(customBST.root);
        }
    }
}
