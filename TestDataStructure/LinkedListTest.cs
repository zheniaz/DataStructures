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
            ll.Add(1);
            ll.Add(2);
            ll.Add(2);
            ll.Add(3);

            Node result = ll.RemoveDuplicates(ll.head);
            bool isUnique = true;
            HashSet<int> hs = new HashSet<int>();
            while(result != null)
            {
                if (hs.Contains(result.data))
                {
                    isUnique = false;
                    break;
                }
                else
                {
                    hs.Add(result.data);
                }
                result = result.next;
            }
            Assert.IsTrue(isUnique);
        }

        #endregion

        #region 2.2 Return Kth to Last

        [TestMethod]
        public void ReturnKthfromLast()
        {
            ll = CreateSortedList();
            int result = ll.KthItemToLast(ll.head, 1);
            int expected = 5;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region 2.4 Partition

        [TestMethod]
        public void LinkedListPartition()
        {
            ll.Add(3);
            ll.Add(5);
            ll.Add(8);
            ll.Add(5);
            ll.Add(10);
            ll.Add(2);
            ll.Add(1);
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
            ll.Add(123);
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

        #region Working Region

        private LinkedList FillRundomValues()
        {
            LinkedList list = new LinkedList();
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(5);
            list.Add(10);
            list.Add(2);
            list.Add(1);
            return list;
        }

        private LinkedList CreatePalindrome()
        {
            LinkedList list = new LinkedList();
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(5);
            list.Add(3);
            return list;
        }

        private LinkedList CreateSortedList()
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            return list;
        }

        #endregion
    }
}
