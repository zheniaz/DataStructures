using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataStructure
{
    [TestClass]
    public class TreesAndGraphsTests
    {
        TreesAndGraphs _treesAndGraphs = new TreesAndGraphs();

        #region 4.2 Minimal Binary Search Tree From Sorted array

        [TestMethod]
        public void BSTFromSortedArrayTest1()
        {
            int[] arr = { 1, 2, 3 };
            Node result = _treesAndGraphs.MinimalTree(arr);
            Node expected = CreateBinarySearchTree();
            Assert.IsTrue(CheckIsTheSameTree(result, expected));
        }

        #endregion

        #region 4.3 List Of Depths

        [TestMethod]
        public void ListOfBSTDepthTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            Node node = _treesAndGraphs.MinimalTree(arr);
            List<LinkedList> result = _treesAndGraphs.ListOfBSTDepths(node);

            List<LinkedList> expected = CreateListOfLinkedListsFor_ListOfDepths();



            Assert.IsTrue(IsListsOfDeptshAreEqual(expected, result));
        }

        [TestMethod]
        public void ListOfDepthTest()
        {
            Node node = CreateNodeWithTwoLevelsKids();
            List<LinkedList> result = _treesAndGraphs.ListOfDepths(node);

            List<LinkedList> expected = CreateListOfLinkedListsFor_ListOfDepths();



            Assert.IsTrue(IsListsOfDeptshAreEqual(expected, result));
        }

        #endregion

        #region 4.5 Check if BT is a BST

        [TestMethod]
        public void IsBST()
        {
            Node binarySearchTree = CreateBinarySearchTree();
            bool isBST = _treesAndGraphs.CheckIsBST(binarySearchTree);
            bool expected = true;
            Assert.AreEqual(isBST, expected);
        }

        [TestMethod]
        public void NotBST()
        {
            Node binaryTree = CreateNotBinarySearchTree();
            bool isBST = _treesAndGraphs.CheckIsBST(binaryTree);
            bool expected = false;
            Assert.AreEqual(isBST, expected);
        }

        #endregion

        #region 4.10 Check SubTree

        [TestMethod]
        public void ContainsSubTree()
        {
            Node binarySearchTree = CreateBinarySearchTree();
            Node binarySearchSubTree = CreateBinarySearchTree();
            bool isContainsSubTree = _treesAndGraphs.ContainsSubTree(binarySearchTree, binarySearchSubTree);
            Assert.IsTrue(isContainsSubTree);
        }

        #endregion

        #region 4..1 Check if two Trees have the same structure

        [TestMethod]
        public void TheSameStructure()
        {
            Node n1 = CreateBinarySearchTree();
            Node n2 = CreateRandomBinaryTree();
            bool result = _treesAndGraphs.CheckIfTheSameStructure(n1, n2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotTheSameStructure()
        {
            Node n1 = CreateBinarySearchTree();
            Node n2 = CreateTree();
            bool result = _treesAndGraphs.CheckIfTheSameStructure(n1, n2);
            Assert.IsFalse(result);
        }

        #endregion

        #region Working Region

        private Node CreateBinarySearchTree()
        {
            Node node = new Node(2);
            node.left = new Node(1);
            node.right = new Node(3);
            return node;
        }

        private Node CreateNotBinarySearchTree()
        {
            Node node = new Node(1);
            node.left = new Node(2);
            node.right = new Node(3);
            return node;
        }

        private Node CreateTree()
        {
            Node node = new Node(2);
            node.left = new Node(1);
            return node;
        }

        private Node CreateRandomBinaryTree()
        {
            Random rnd = new Random();
            Node node = new Node(rnd.Next(1, 9));
            node.left = new Node(rnd.Next(1, 9));
            node.right = new Node(rnd.Next(1, 9));
            return node;
        }

        private bool CheckIsTheSameTree(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null || n2 == null) return false;
            if (n1.data != n2.data) return false;
            return CheckIsTheSameTree(n1.left, n2.left) && CheckIsTheSameTree(n1.right, n2.right);
        }

        private Node CreateNodeWithTwoLevelsKids()
        {
            Node node = new Node(1);
            node.kids = AddKidsToNode();

            for (int i = 0; i < 3; i++)
            {
                node.kids[i].kids = AddKidsToNode();
            }
            return node;
        }

        private Node[] AddKidsToNode()
        {
            Node[] nodes = { new Node(1), new Node(2), new Node(3) };
            return nodes;
        }

        #region working region for 4.3 List Of Depths

        private List<LinkedList> CreateListOfLinkedListsFor_ListOfDepths()
        {
            List<LinkedList> list = new List<LinkedList>();
            LinkedList level1 = new LinkedList();
            LinkedList level2 = new LinkedList();
            LinkedList level3 = new LinkedList();
            level1.AddToTail(4);
            level2.AddToTail(2);
            level2.AddToTail(6);
            level3.AddToTail(1);
            level3.AddToTail(3);
            level3.AddToTail(5);
            level3.AddToTail(7);
            list.Add(level1);
            list.Add(level2);
            list.Add(level3);
            return list;
        }

        private bool IsListsOfDeptshAreEqual(List<LinkedList> list1, List<LinkedList> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Count != list2[i].Count) return false;
                Node node1 = list1[i].head;
                Node node2 = list2[i].head;
                while (node1 != null || node2 != null)
                {
                    if (node1.data != node2.data)
                    {
                        return false;
                    }
                    node1 = node1.next;
                    node2 = node2.next;
                }
            }
            return true;
        }

        #endregion

        #endregion
    }
}
