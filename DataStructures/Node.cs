﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Node
    {
        public Node next;
        public Node previous;
        public Node left;
        public Node right;
        public Node last {
            set { value = SetLastNode(); } }
        public int data;
        public int size { set { value = Size(); } }
        public Node(int data)
        {
            this.data = data;
        }

        private int Size()
        {
            int count = 1;
            Node temp = next;
            while(temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }

        private Node SetLastNode()
        {
            if (this.next == null)
            {
                return this;
            }
            Node temp = next;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        #region 4.2 Minimal Tree

        public Node MinimalTree(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }
            return MinimalTree(arr, 0, arr.Length);
        }

        public Node MinimalTree(int[] arr, int min, int max)
        {
            if (max < min) return null;
            int mid = (min + max) / 2;
            Node node = new Node(mid);
            node.left = MinimalTree(arr, min, mid - 1);
            node.right = MinimalTree(arr, mid + 1, max);
            return node;
        }

        #endregion
    }
}