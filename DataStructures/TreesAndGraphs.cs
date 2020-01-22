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


        //public List<LinkedList> ListOfDepths(Node node)
        //{
        //    List<LinkedList> result = new List<LinkedList>();
        //    LinkedList currentLevelNode = new LinkedList();
        //    currentLevelNode.AddNode(node);
        //    result.Add(currentLevelNode);
        //    bool isHasChild = node.left != null || node.right != null ? true : false;
        //    while (isHasChild)
        //    {
        //        LinkedList tempLinkedList = new LinkedList();
        //        Node tempNode = currentLevelNode.head;
        //        while (tempNode != null)
        //        {
        //            if (tempNode.left != null) tempLinkedList.AddNode(tempNode.left);
        //            if (tempNode.right != null) tempLinkedList.AddNode(tempNode.right);
        //            tempNode = tempNode.next;
        //        }
        //        if (tempLinkedList.Count != 0)
        //        {
        //            result.Add(tempLinkedList);
        //            currentLevelNode = tempLinkedList;
        //            isHasChild = tempLinkedList.Count != 0;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    return result;
        //}

        public List<LinkedList> ListOfBSTDepths(Node node)
        {
            if (node == null)
            {
                throw new NullReferenceException();
            }

            List<LinkedList> result = new List<LinkedList>();
            LinkedList currentLevel = new LinkedList();
            currentLevel.AddNode(node);
            result.Add(currentLevel);
            while (currentLevel.head != null)
            {
                Node temp = currentLevel.head;
                LinkedList next = new LinkedList();
                while (temp != null)
                {
                    if (temp.left != null)
                    {
                        next.AddNode(temp.left);
                    }

                    if (temp.right != null)
                    {
                        next.AddNode(temp.right);
                    }

                    temp = temp.next;
                }
                if (next.Count != 0)
                {
                    result.Add(next);
                }

                currentLevel = next;
            }
            return result;
        }

        public List<LinkedList> ListOfDepths(Node node)
        {
            if (node == null)
            {
                throw new NullReferenceException();
            }

            List<LinkedList> result = new List<LinkedList>();
            LinkedList currentLevel = new LinkedList();
            currentLevel.AddNode(node);
            result.Add(currentLevel);
            Node[] nodes = currentLevel.head.kids;
            currentLevel = new LinkedList();




            while (nodes.Length != 0)
            {

                List<Node> nextLevel = new List<Node>();
                foreach (var item in nodes)
                {
                    currentLevel.AddNode(item);
                    nextLevel.AddRange(item.kids);
                }
                if (nextLevel.Count != 0)
                {
                    result.Add(currentLevel);
                }

                nodes = nextLevel.ToArray();
            }
            return result;
        }

        #endregion

        #region 4.5 Check if BT is a BST

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
    }
}
