using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Text;
//using DataStructures;
namespace TestDataStructure
{
    [TestClass]
    public class ArraysAndStringsTests
    {
        ArraysAndStrings _arraysAndStrings = new ArraysAndStrings();

        #region 1.1 Is Unique region

        [TestMethod]
        public void IsUniqueTest1()
        {
            string str = "asdf";
            bool result = _arraysAndStrings.IsUniq(str);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void IsUniqueTest2()
        {
            string str = "aasdf";
            bool result = _arraysAndStrings.IsUniq(str);
            Assert.AreEqual(result, false);
        }

        #endregion

        #region 1.2 Check Permutation Region

        [TestMethod]
        public void CheckPermutationTest1()
        {
            string s = "asdf";
            string t = "sdfa";
            bool result = _arraysAndStrings.CheckPermutation(s, t);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CheckPermutationTest2()
        {
            string s = "asdf";
            string t = "sdf";
            bool result = _arraysAndStrings.CheckPermutation(s, t);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CheckPermutationTest3()
        {
            string s = "";
            string t = "";
            bool result = _arraysAndStrings.CheckPermutation(s, t);
            Assert.AreEqual(result, false);
        }

        #endregion

        #region 1.4 Palindrom Section

        [TestMethod]
        public void IsPalindromTest1()
        {
            string palindrom = "Tact Coa";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest2()
        {
            string palindrom = "taat";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest3()
        {
            string palindrom = "atarata";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest4()
        {
            string palindrom = "a";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest5()
        {
            string palindrom = "aa";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest6()
        {
            string palindrom = "";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsNotPalindromTest1()
        {
            string palindrom = "fasdf";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNotPalindromTest2()
        {
            string palindrom = "as";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNotPalindromTest3()
        {
            string palindrom = "tatata";
            bool result = _arraysAndStrings.IsPalindrom(palindrom);
            Assert.IsFalse(result);
        }

        #endregion

        #region 1.5 One Away Section

        [TestMethod]
        public void IsOneAwayTest1()
        {
            string first = "pale", second = "ple";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOneAwayTest2()
        {
            string first = "pales", second = "pale";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOneAwayTest3()
        {
            string first = "pale", second = "bale";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOneAwayTest4()
        {
            string first = "pale", second = "bae";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsFalse(result);
        }

        #endregion

        #region 1.6 Compression

        [TestMethod]
        public void StringCompressionTest1()
        {
            string str = "aabbcca";
            string expected = "a2b2c2a1";
            string result = _arraysAndStrings.StringComperission(str);
            Assert.AreEqual(result, expected);
        }

        #endregion

        #region 1.9 Rotation region

        [TestMethod]
        public void IsRotationTest1()
        {
            string s1 = "asdfasdf";
            string s2 = "dfasdfas";
            bool result = _arraysAndStrings.IsRotation(s1, s2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRotationTest2()
        {
            string s1 = "asdfssdf";
            string s2 = "aaaaaaaa";
            bool result = _arraysAndStrings.IsRotation(s1, s2);
            Assert.IsFalse(result);
        }

        #endregion

        #region 2..1 Sorting Region

        [TestMethod]
        public void SortTest1()
        {
            int[] arr = { 1, 2, 3, 4, 3, 2, 1 };
            int[] expected = { 1, 1, 2, 2, 3, 3, 4 };
            var result = _arraysAndStrings.Sort(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortTestSuccess1()
        {
            int[] arr = { 5,4,3,2,1 };
            int[] expected = { 1, 2, 3, 4, 5 };
            var result = _arraysAndStrings.Sort(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortTestSuccess2()
        {
            int[] arr = { 3, 3, 2, 2, 1, 1 };
            int[] expected = { 1, 1, 2, 2, 3, 3 };
            var result = _arraysAndStrings.Sort(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortTestFaild1()
        {
            int[] arr = null;
            var result = _arraysAndStrings.Sort(arr);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortTestFaild2()
        {
            int[] arr = new int[0];
            var result = _arraysAndStrings.Sort(arr);
            Assert.IsNull(result);
        }

        // Sort SubArrays In Array
        [TestMethod]
        public void SortSubArraysSuccess1()
        {
            int[] arr = { 1, 1, 2, 3 };
            int[] expected = { 1, 2, 3, 1 };
            var result = _arraysAndStrings.SortSubArrays(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortSubArraysSuccess2()
        {
            int[] arr = { 1, 1, 2, 3, 4, 1, 2, 6, 9 };
            int[] expected = { 1, 2, 3, 4, 6, 9, 1, 2, 1 };
            var result = _arraysAndStrings.SortSubArrays(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortSubArraysSuccess3()
        {
            int[] arr = { 1, 1, 2, 2 };
            int[] expected = { 1, 2, 1, 2 };
            var result = _arraysAndStrings.SortSubArrays(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortSubArraysSuccess4()
        {
            int[] arr = { 1, 1, 1, 2, 2 };
            int[] expected = { 1, 2, 1, 2, 1};
            var result = _arraysAndStrings.SortSubArrays(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void SortSubArraysSuccess5()
        {
            int[] arr = { 1, 1, 1, 2, 2, 2 };
            int[] expected = { 1, 2, 1, 2, 1, 2 };
            var result = _arraysAndStrings.SortSubArrays(arr);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        //[TestMethod]
        //public void SortSubArraysSuccess6()
        //{
        //    int[] arr = { 1, 1, 1, 2, 2, 1 };
        //    int[] expected = { 1, 2, 1, 2, 1, 1 };
        //    var result = _arraysAndStrings.SortSubArrays(arr);
        //    Assert.IsTrue(expected.SequenceEqual(result));
        //}

        //[TestMethod]
        //public void SortSubArraysSuccess7()
        //{
        //    int[] arr = { 1, 1, 1, 2, 3, 4, 1, 2, 6, 9 };
        //    int[] expected = { 1, 2, 1, 2, 1, 1 };
        //    var result = _arraysAndStrings.SortSubArrays(arr);
        //    Assert.IsTrue(expected.SequenceEqual(result));
        //}

        #endregion

        #region 2..2 Remove Duplicates From Each Substring in String

        [TestMethod]
        public void RemoveDupsTestSuccess1()
        {
            string str = "a";
            string expected = "a";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess2()
        {
            string str = "";
            string expected = "";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess3()
        {
            string str = null;
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess4()
        {
            string str = "aa";
            string expected = "a";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess5()
        {
            string str = "asdf";
            string expected = "asdf";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess6()
        {
            string str = "a-3[";
            string expected = null;
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess7()
        {
            string str = "aaab";
            string expected = "ab";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsTestSuccess8()
        {
            string str = "aabbbcccbaa";
            string expected = "abcba";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        //I: "a" O: I
        //I: "" O: I
        //I: null O: trow NullReferenceException()
        //I: "aa" O: "a"
        //I: "asdf": O: "asdf"
        //I: "a-3[": O: trow new Exception("Not All Chars are Alphabetical")
        //I: "aaab" O: "ab"
        //I: "aabbbcccbaa: O: "abcba"

        #endregion

        #region 2..3 Reverse Words in string

        [TestMethod]
        public void ReverseWordsTest1()
        {
            string str = "This is a test";
            string expected = "test a is This";
            var result = _arraysAndStrings.ReverseWordsInString(str);
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
