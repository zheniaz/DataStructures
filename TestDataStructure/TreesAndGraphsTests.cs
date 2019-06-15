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
        #region 4.2 Minimal Tree

        [TestMethod]
        public void BSTFromSortedArrayTest1()
        {
            int[] arr = { 1, 2, 3 };
            Node expected = CreateSmallBinarySearchTree();
            bool isBST = _treesAndGraphs.CheckIsBST(expected);
            Assert.IsTrue(isBST);
        }

        #endregion

        #region 4..1 Check if two Trees have the same structure

        [TestMethod]
        public void TheSameStructureTest1()
        {
            Node n1 = CreateSmallBinarySearchTree();
            Node n2 = CreateBinaryTree();
            bool result = _treesAndGraphs.CheckIfTheSameStructure(n1, n2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TheSameStructureTest2()
        {
            Node n1 = CreateSmallBinarySearchTree();
            Node n2 = CreateTree();
            bool result = _treesAndGraphs.CheckIfTheSameStructure(n1, n2);
            Assert.IsFalse(result);
        }

        #endregion

        #region Working Region

        private Node CreateSmallBinarySearchTree()
        {
            Node node = new Node(2);
            node.left = new Node(1);
            node.right = new Node(3);
            return node;
        }

        private Node CreateTree()
        {
            Node node = new Node(2);
            node.left = new Node(1);
            return node;
        }

        private Node CreateBinaryTree()
        {
            Random rnd = new Random();
            Node node = new Node(rnd.Next(1, 9));
            node.left = new Node(rnd.Next(1, 9));
            node.right = new Node(rnd.Next(1, 9));
            return node;
        }
        #endregion
    }
}
