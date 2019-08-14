using System;
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
        public Node[] kids;
        public Node Tail => SetLastNode();
        public int data;
        public int Size => SizeOfNode();

        public Node(int data)
        {
            this.data = data;
        }

        public Node AppendToTail(Node head, int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                return newNode;
            }

            Node node = this;
            while (node.next != null)
            {
                node = node.next;
            }
            node.next = newNode;
            return node;
        }

        public Node DeleteNode(Node head, int data)
        {
            Node node = head;
            if (node.data == data)
            {
                return head.next;
            }
            while (node.next != null)
            {
                if (node.next.data == data)
                {
                    node.next = node.next.next;
                    return head;
                }
                node = node.next;
            }
            return head;
        }

        private int SizeOfNode()
        {
            int count = 1;
            Node temp = next;
            while (temp != null)
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
