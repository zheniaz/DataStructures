using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestDataStructure
{
    [TestClass]
    public class StackAndQueuesTests
    {
        MyStack myStack = new MyStack();
        MyQueue myQueue = new MyQueue();
        LEAP leap = new LEAP();

        #region 3.2 Stack Min Region

        [TestMethod]
        public void StackMinTest()
        {
            bool result = false;
            int[] arr = { 5, 6, 3, 7 };
            int[] minArr = { 5, 5, 3, 3 };
            for (int i = 0; i < arr.Length; i++)
            {
                myStack.Push(arr[i]);
                result = myStack.stackMin.data == minArr[i];
            }
            int count = 2;
            for (int i = minArr.Length - 1; count != 0; i--)
            {
                myStack.Pop();
                result = myStack.stackMin.data == minArr[i];
                count--;
            }

            Assert.IsTrue(result);
        }

        #endregion

        #region Paul Miller Task

        [TestMethod]
        public void MaxSubarraySumTest1()
        {
            int[] arr = { 1, 2, 5, 2, 8, 1, 5 };
            int k = 2;

            int[] result = leap.MaxSubarraySum(arr, k);
            int[] expected = { 2, 8 };
            bool isEqual = Enumerable.SequenceEqual(result, expected);
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MaxSubarraySumTest2()
        {
            int[] arr = { 1, 2, 5, 2, 8, 1, 5 };
            int k = 4;

            int[] result = leap.MaxSubarraySum(arr, k);
            int[] expected = { 2, 5, 2, 8 };
            bool isEqual = Enumerable.SequenceEqual(result, expected);
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MaxSubarraySumTest3()
        {
            int[] arr = { 4, 2, 1, 6 };
            int k = 1;

            int[] result = leap.MaxSubarraySum(arr, k);
            int[] expected = { 6 };
            bool isEqual = Enumerable.SequenceEqual(result, expected);
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MaxSubarraySumTest4()
        {
            int[] arr = { };
            int k = 4;

            int[] result = leap.MaxSubarraySum(arr, k);
            int[] expected = { };
            bool isEqual = Enumerable.SequenceEqual(result, expected);
            Assert.IsTrue(isEqual);
        }

        #endregion
    }
}
