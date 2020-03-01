using System;
using System.Collections.Generic;

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

        #region 4.3 List Of Depths

        //we want to iterate through the root first, then level 2, then level 3, and soon.
        //With each level i, we will have already fully visited all nodes on level i - l.Tbis means that to get which
        //nodes are on level i, we can simply look at all children of the nodes of level i - 1.
        //  0(N) time,  0(N) data
        public List<LinkedList<Node>> ListOfBSTDepths(Node root)
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();
            LinkedList<Node> current = new LinkedList<Node>();
            if (root != null)
            {
                current.AddLast(root);
            }
            while (current.Count > 0)
            {
                result.Add(current);
                LinkedList<Node> parents = current;
                current = new LinkedList<Node>();
                foreach (var parent in parents)
                {
                    if (parent.left != null)
                    {
                        current.AddLast(parent.left);
                    }
                    if (parent.right != null)
                    {
                        current.AddLast(parent.right);
                    }
                }
            }
            return result;
        }

        #endregion

        #region 4.5 Check if BT is a BST
        // The time complexity for this solution isO(N), where N is the number of nodes in the tree.
        // Due to the use of recursion, the space complexity is O(log M) on a balanced tree.
        // There are up to 0(log N) recursive calls on the stack since we may recurse up to the depth of the tree.
        public bool CheckIsBST(Node node)
        {
            return CheckIsBST(node, null, null);
        }

        public bool CheckIsBST(Node node, int? min, int? max)
        {
            if (node == null)
            {
                return true;
            }

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

        public bool ContainsSubTree(Node t, Node s)
        {
            if (s == null)
            {
                return true;
            }

            return SubTree(t, s);
        }

        public bool SubTree(Node t, Node s)
        {
            if (t == null)
            {
                return false;
            }

            if (t.data == s.data && MatchTree(t, s))
            {
                return true;
            }
            return (SubTree(t.left, s) || SubTree(t.right, s));
        }

        public bool MatchTree(Node t, Node s)
        {
            if (t == null && s == null)
            {
                return true;
            }

            if (t == null || s == null)
            {
                return false;
            }

            if (t.data != s.data)
            {
                return false;
            }

            return (MatchTree(t.left, s.left) && MatchTree(t.right, s.right));
        }

        #endregion

        #region 4..1 Check if two Trees have the same structure

        public bool CheckIfTheSameStructure(Node n1, Node n2)
        {
            if (n1 == null && n2 == null)
            {
                return true;
            }

            if (n1 == null || n2 == null)
            {
                return false;
            }

            return CheckIfTheSameStructure(n1.left, n2.left) && CheckIfTheSameStructure(n1.right, n2.right);
        }

        #endregion

        #region 4..2 Binary Search 

        public int? BinarySearch(int[] arr, int x)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            if (arr.Length == 1)
            {
                return arr[0];
            }

            return BinarySearch(arr, 0, arr.Length, x);
        }

        public int? BinarySearch(int[] arr, int start, int end, int x)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            if (arr[mid] == x)
            {
                return mid;
            }

            return (x < arr[mid]) ? BinarySearch(arr, start, mid - 1, x)
                             : BinarySearch(arr, mid + 1, end, x);
        }

        #endregion

        #region 4..3 Find BinarySearchMinimum

        public int BinarySearchMinimum1(int[] arr)
        {
            if (arr.Length <= 2)
            {
                return -1;
            }
            return BinarySearchMinimum2(arr, 0, arr.Length - 1);
        }

        public int BinarySearchMinimum2(int[] arr, int s, int e)
        {
            if (s > e) return -1;
            int m = (s + e) / 2;
            if (m - 1 < 0 || m + 1 > arr.Length - 1) return -1;
            if (arr[m] > arr[m - 1] && arr[m] < arr[m + 1])
            {
                return m;
            }
            var first = BinarySearchMinimum2(arr, s, m - 1);
            var second = BinarySearchMinimum2(arr, m + 1, e);
            return (first != -1) ? first : second;
        }

        #endregion
    }
}
