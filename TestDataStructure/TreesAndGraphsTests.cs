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
        #endregion
    }
}
