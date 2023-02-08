using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD_Lab_6
{
    class Tree
    {
        public Tree LeftChild;
        public Tree RightChild;
        public string Data;
        public int Priority;

        public Tree(string data,int priority, Tree leftChild = null, Tree rightChild = null)
        {
            Data = data;
            Priority = priority;
            LeftChild = leftChild;
            RightChild = rightChild;
           

        }
    }
}
