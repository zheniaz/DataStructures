using DataStructures.Models;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7,1, 2, 3, 4, 5,5,3,1,2 };
            Console.WriteLine();

            LinkedList ll = new LinkedList();
            ll.AddToTail(3);
            ll.AddToTail(5);
            ll.AddToTail(8);
            ll.AddToTail(5);
            ll.AddToTail(10);
            ll.AddToTail(2);
            ll.AddToTail(1);
            ShowLL(ll.head);
            ShowLL(ll.Partition(ll.head, 5));

            Console.WriteLine(ll.KthItemToLast(ll.head, 0));
        }

        bool checkbst(Node n)
        {
            return checkbst(n, 0, 0);
        }

        bool checkbst(Node n, int min, int max)
        {
            if (n == null) return true;
            if ((min != 0 && n.data < min) || (max != 0 && n.data > max)) return false;
            if (!checkbst(n.left, min, n.data) || !checkbst(n.right, n.data, max)) return false;
            return true;
        }

        public static void ShowLL(Node n)
        {
            Node current = n;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        static Tree CrateMinimalBinaryTree(int[] arr, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            Tree tree = new Tree(mid);
            tree.left = CrateMinimalBinaryTree(arr, start, mid - 1);
            tree.right = CrateMinimalBinaryTree(arr, mid + 1, end);
            return tree;
        }

        static int binarySearch(int[] arr, int start, int end, int x)
        {
            if (end < start) return -1;
            int mid = (start + end) / 2;
            if (arr[mid] == x) return mid;
            return (x < arr[mid]) ? binarySearch(arr, start, mid - 1, x) : binarySearch(arr, mid + 1, end, x);
        }

        static bool ContainsTree(Tree t, Tree s)
        {
            if (s == null) return true;
            return SubTree(t, s);
        }

        static bool SubTree(Tree t, Tree s)
        {
            if (t == null) return false;
            else if (t.data == s.data && MatchTree(t, s)) return true;
            return SubTree(t.left, s) || SubTree(t.right, s);
        }

        static bool MatchTree(Tree t, Tree s)
        {
            if (t == null && s == null) return true;
            else if (t == null || s == null) return false;
            else if (t.data != s.data) return false;
            return MatchTree(t.left, s.left) && MatchTree(t.right, s.right);
        }

        static List<LinkedList<Tree>> crateListOfDepths(Tree root)
        {
            List<LinkedList<Tree>> lists = new List<LinkedList<Tree>>();
            SetLinkedLists(root, lists, 0);
            return lists;
        }

        static void SetLinkedLists(Tree root, List<LinkedList<Tree>> lists, int level)
        {
            if (root == null)
            {
                return;
            }

            LinkedList<Tree> ll = null;

            if (lists.Count == level)
            {
                ll = new LinkedList<Tree>();
                lists.Add(ll);
            }
            else
            {
                ll = lists[level];
            }
            ll.AddLast(root);
            SetLinkedLists(root.left, lists, ++level);
            SetLinkedLists(root.right, lists, ++level);
        }
    }
}
