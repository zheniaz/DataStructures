using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class TreesAndGraphs
    {
        #region 4.2 Minimal Binary Search Tree From Sorted array

        public Node MinimalTree(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }
            return MinimalTree(arr, 0, arr.Length - 1);
        }

        public Node MinimalTree(int[] arr, int min, int max)
        {
            if (max < min) return null;
            int mid = (min + max) / 2;
            Node node = new Node(arr[mid]);
            node.left = MinimalTree(arr, min, mid - 1);
            node.right = MinimalTree(arr, mid + 1, max);
            return node;
        }

        #endregion

        #region 4.5 Check if BT is a BST

        public bool CheckIsBST(Node node)
        {
            return CheckIsBST(node, null, null);
        }

        public bool CheckIsBST(Node node, int? min, int? max)
        {
            if (node == null) return true;
            if ((min != null && min > node.data) || (max != null && max < node.data))
            {
                return false;
            }
            if (!CheckIsBST(node.left, min, node.data) || !CheckIsBST(node.right, node.data, max))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region 4.10 Check SubTree

        //public bool ContainsSubTree(Node t, Node s)
        //{
        //    if (s == null) return true;
        //    return SubTree(t, s);
        //}

        //public bool SubTree(Node t, Node s)
        //{
        //    if (t == null) return false;
        //    if(t.data == s.data && MatchTree(t, s))
        //    {
        //        return true;
        //    }
        //    return (SubTree(t.left, s) || SubTree(t.right, s));
        //}

        //public bool MatchTree(Node t, Node s)
        //{
        //    if (t == null && s == null) return true;
        //    if (t == null || s == null) return false;
        //    if (t.data != s.data) return false;
        //    return (MatchTree(t.left, s.left) && MatchTree(t.right, s.right));
        //}

        public bool ContainsSubTree(Node n1, Node n2)
        {
            if (n2 == null) return true;
            return SubTree(n1, n2);
        }

        public bool SubTree(Node n1, Node n2)
        {
            if (n1 == null) return false;
            if (n1.data == n2.data && MatchTree(n1, n2)) return true;
            return SubTree(n1.left, n2) || SubTree(n1.right, n2);
        }

        public bool MatchTree(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null || n2 == null) return false;
            if (n1.data != n2.data) return false;
            return MatchTree(n1.left, n2.left) && MatchTree(n1.right, n2.right);
        }

        #endregion

        #region 4..1 Check if two Trees have the same structure

        public bool CheckIfTheSameStructure(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null || n2 == null) return false;
            return CheckIfTheSameStructure(n1.left, n2.left) && CheckIfTheSameStructure(n1.right, n2.right);
        }

        #endregion

        #region 4..2 Binary Search 

        public int? BinarySearch(int[] arr, int x)
        {
            if (arr == null || arr.Length == 0) return null;
            if (arr.Length == 1) return arr[0];
            return BinarySearch(arr, 0, arr.Length, x);
        }

        public int? BinarySearch(int[] arr, int start, int end, int x)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            if (arr[mid] == x) return mid;
            return (x < arr[mid]) ? BinarySearch(arr, start, mid - 1, x)
                             : BinarySearch(arr, mid + 1, end, x);
        }

        #endregion
    }
}
