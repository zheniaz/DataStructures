using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Models
{
    public class Tree
    {
        public int data;
        public Tree left;
        public Tree right;
        public Tree(int data)
        {
            this.data = data;
        }
    }
}
