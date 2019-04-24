using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDataStructure
{
    [TestClass]
    public class ContinousSubSetMaxTest
    {
        [TestMethod]
        public void ContinousSubSet1()
        {
            int[] arrange = { 3, 2, -1, 4 };
            int[] expected = { 3, 2 };
            LEAP leap = new LEAP();
            int[] result = leap.FindMaxProductContinousSubSet(arrange);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ContinousSubSet2()
        {
            int[] arrange = { 1, 2, 3, 4 };
            int[] expected = { 1, 2, 3, 4 };
            LEAP leap = new LEAP();
            int[] result = leap.FindMaxProductContinousSubSet(arrange);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ContinousSubSet3()
        {
            int[] arrange = { -2, 4, 5, -3 };
            int[] expected = { -2, 4, 5, -3 };
            LEAP leap = new LEAP();
            int[] result = leap.FindMaxProductContinousSubSet(arrange);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ContinousSubSet4()
        {
            int[] arrange = { -3, 2, -11, -4 };
            int[] expected = { 2, -11, -4 };
            LEAP leap = new LEAP();
            int[] result = leap.FindMaxProductContinousSubSet(arrange);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }
    }
}
