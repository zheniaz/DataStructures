using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataStructure
{
    [TestClass]
    public class LinkedListTest
    {
        LinkedList ll = new LinkedList();

        #region 2.1 Remove Dups

        [TestMethod]
        public void RomoveDupsTest1()
        {
            LinkedList linkedList = CreateLLWithDuplicates();
            Node result = ll.RemoveDuplicates(linkedList.head);
            Assert.IsTrue(IsUniqueNode(result));
        }

        #endregion

        #region 2.2 Return Kth to Last

        [TestMethod]
        public void ReturnKthfromLast()
        {
            ll = CreateSortedList();
            int result = ll.KthItemToLast(ll.head, 1);
            int expected = 6;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region 2.3 Delete Middle Node

        [TestMethod]
        public void DeleteMiddleNodeTest()
        {

        }

        #endregion

        #region 2.4 Partition

        [TestMethod]
        public void LinkedListPartition()
        {
            ll.AddToTail(3);
            ll.AddToTail(5);
            ll.AddToTail(8);
            ll.AddToTail(5);
            ll.AddToTail(10);
            ll.AddToTail(2);
            ll.AddToTail(1);
        }

        #endregion

        #region 2.5 Sum Lists

        [TestMethod]
        public void SumLists1()
        {
            Node n1 = new Node(7);
            n1.next = new Node(1);
            n1.next.next = new Node(6);

            Node n2 = new Node(5);
            n2.next = new Node(9);
            n2.next.next = new Node(2);

            Node result = ll.SumLists(n1, n2, 0);

            Node expected = new Node(2);
            expected.next = new Node(1);
            expected.next.next = new Node(9);

            while (result != null)
            {
                Assert.AreEqual(result.data, expected.data);
                result = result.next;
                expected = expected.next;
            }
        }

        [TestMethod]
        public void SumLists2()
        {
            Node n1 = new Node(7);
            n1.next = new Node(1);
            n1.next.next = new Node(6);

            Node n2 = new Node(5);
            n2.next = new Node(9);

            Node result = ll.SumLists(n1, n2);

            Node expected = new Node(2);
            expected.next = new Node(1);
            expected.next.next = new Node(7);

            while (result != null)
            {
                Assert.AreEqual(result.data, expected.data);
                result = result.next;
                expected = expected.next;
            }
        }

        #endregion

        #region 2.6 Palindrome

        [TestMethod]
        public void IsPalindrome1()
        {
            bool expected = false;
            bool result = ll.IsLinkedListPalindrome(null);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome2()
        {
            Node node = new Node(1);
            bool expected = true;
            bool result = ll.IsLinkedListPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome3()
        {
            Node node = new Node(1);
            node.next = new Node(1);
            bool expected = true;
            bool result = ll.IsLinkedListPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome4()
        {
            Node node = new Node(1);
            node.next = new Node(2);
            bool expected = false;
            bool result = ll.IsLinkedListPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome5()
        {
            ll = FillRundomValues();
            bool expected = false;
            bool result = ll.IsLinkedListPalindrome(ll.head);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome6()
        {
            ll = CreatePalindrome();
            bool expected = true;
            bool result = ll.IsLinkedListPalindrome(ll.head);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome7()
        {
            bool expected = false;
            bool result = ll.IsLLPalindrome(null);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome8()
        {
            Node node = new Node(1);
            bool expected = true;
            bool result = ll.IsLLPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome9()
        {
            Node node = new Node(1);
            node.next = new Node(1);
            bool expected = false;
            bool result = ll.IsLLPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome10()
        {
            Node node = new Node(1);
            node.next = new Node(2);
            bool expected = false;
            bool result = ll.IsLLPalindrome(node);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome11()
        {
            ll = FillRundomValues();
            bool expected = false;
            bool result = ll.IsLLPalindrome(ll.head);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IsPalindrome12()
        {
            ll = CreatePalindrome();
            bool expected = true;
            bool result = ll.IsLLPalindrome(ll.head);
            Assert.AreEqual(result, expected);
        }

        #endregion

        #region 2.7 Intersection

        [TestMethod]
        public void IntersectionTest()
        {
            Node n1 = CreateSortedNode(4);
            Node n2 = new Node(0);
            n2.next = n1.next.next;

            Node expected = n1.next.next;
            Node actual = ll.FindIntersection(n1, n2);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region 2.8 Loop Detection

        [TestMethod]
        public void LoopDetection1()
        {
            ll = FillRundomValues();
            ll.tail.next = ll.head.next.next;
            Node expected = ll.head.next.next;
            Node result = ll.LoopDetection(ll.head);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LoopDetection2()
        {
            ll = FillRundomValues();
            Node expected = null;
            Node result = ll.LoopDetection(ll.head);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LoopDetection3()
        {
            ll = FillRundomValues();
            ll.AddToTail(123);
            Node expected = null;
            Node result = ll.LoopDetection(ll.head);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsLinkedListHasALoop1()
        {
            ll = FillRundomValues();
            ll.tail.next = ll.head.next.next;
            bool expected = true;
            bool result = ll.IsLinkedListHasALoop(ll.head);
            Assert.AreEqual(expected, result);
        }

        //  1 2 3    1-2, 2-1, 3-3
        // 1 2 3 4   1-2, 2-4, 3-2, 4-4
        // 1 2 3 4 5 1-2, 2-4, 3-1, 4-3, 5-5

        #endregion

        #region 2..1 The "Runner" Technique a1->a2->b1->b2 => a1->b1->a2->b2

        [TestMethod]
        public void RunnerTechniqueTest()
        {
            Node node = CreateSortedNode();
            Node actual = ll.Runner(node);
            Node expected = CreateSortedMixedNode();
            Assert.IsTrue(IsEqualNodes(expected, actual));
        }

        #endregion

        #region Working Region

        private LinkedList FillRundomValues()
        {
            LinkedList list = new LinkedList();
            list.AddToTail(3);
            list.AddToTail(5);
            list.AddToTail(8);
            list.AddToTail(5);
            list.AddToTail(10);
            list.AddToTail(2);
            list.AddToTail(1);
            return list;
        }

        private LinkedList CreatePalindrome()
        {
            LinkedList list = new LinkedList();
            list.AddToTail(3);
            list.AddToTail(5);
            list.AddToTail(8);
            list.AddToTail(5);
            list.AddToTail(3);
            return list;
        }

        private LinkedList CreateSortedList()
        {
            LinkedList list = new LinkedList();
            list.AddToTail(1);
            list.AddToTail(2);
            list.AddToTail(3);
            list.AddToTail(4);
            list.AddToTail(5);
            list.AddToTail(6);
            return list;
        }

        private LinkedList CreateLLWithDuplicates()
        {
            LinkedList list = new LinkedList();
            list.AddToTail(1);
            list.AddToTail(1);
            list.AddToTail(3);
            list.AddToTail(4);
            list.AddToTail(4);
            return list;
        }

        #region Working Region For Node

        private Node CreateSortedNode()
        {
            int i = 0;
            Node current = new Node(++i); ;
            Node node = current;
            while (i < 6)
            {
                current.next = new Node(++i);
                current = current.next;
            }
            return node;
        }

        private Node CreateSortedNode(int size)
        {
            int i = 0;
            Node current = new Node(++i); ;
            Node node = current;
            while (--size != 0)
            {
                current.next = new Node(++i);
                current = current.next;
            }
            return node;
        }

        private Node CreateSortedMixedNode()
        {
            int[] arr = { 1, 4, 1, 5, 2, 6 };
            Node current = null;
            Node node = current;

            for (int i = 0; i < arr.Length; i++)
            {
                current = new Node(i);
                current = current.next;
            }
            return node;
        }

        private bool IsEqualNodes(Node n1, Node n2)
        {
            while (n1 != null && n2 != null)
            {
                if (n1 == null || n2 == null || n1.data != n2.data) return false;
                n1 = n1.next;
                n2 = n2.next;
            }
            return true;
        }

        private bool IsUniqueNode(Node node)
        {
            bool isUnique = true;
            HashSet<int> hs = new HashSet<int>();
            while (node != null)
            {
                if (hs.Contains(node.data))
                {
                    isUnique = false;
                    break;
                }
                else
                {
                    hs.Add(node.data);
                }
                node = node.next;
            }
            return isUnique;
        }

        #endregion

        #endregion
    }
}
