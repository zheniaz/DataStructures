using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void IsUniqueTest3()
        {
            string str = "";
            bool result = _arraysAndStrings.IsUniq(str);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void IsUniqueTest4()
        {
            string str = null;
            bool result = _arraysAndStrings.IsUniq(str);
        }

        #endregion

        #region 1.2 Check Permutation Region

        [TestMethod]
        public void CheckPermutationTest1()
        {
            string s = "asdf";
            string t = "sdfa";
            bool result = _arraysAndStrings.IsPermutation(s, t);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CheckPermutationTest2()
        {
            string s = "asdf";
            string t = "sdf";
            bool result = _arraysAndStrings.IsPermutation(s, t);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void CheckPermutationTest3()
        {
            string s = "";
            string t = "";
            bool result = _arraysAndStrings.IsPermutation(s, t);
        }

        [TestMethod]
        public void CheckPermutationTest4()
        {
            string s = "aaff";
            string t = "ffaa";
            bool result = _arraysAndStrings.IsPermutation(s, t);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CheckPermutationTest5()
        {
            string s = "aasd";
            string t = "asad";
            bool result = _arraysAndStrings.IsPermutation(s, t);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void CheckPermutationTest6()
        {
            string s = "";
            string t = "asad";
            bool result = _arraysAndStrings.IsPermutation(s, t);
        }

        #endregion

        #region 1.4 Palindrom Section

        [TestMethod]
        public void IsPalindromTest1()
        {
            string palindrom = "Tact Coa";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest2()
        {
            string palindrom = "taat";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest3()
        {
            string palindrom = "atarata";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest4()
        {
            string palindrom = "a";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindromTest5()
        {
            string palindrom = "aa";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IsPalindromTest6()
        {
            string palindrom = "";
            var exception =  _arraysAndStrings.IsPalindromPermutation(palindrom);
        }

        [TestMethod]
        public void IsPalindromHasNullString()
        {
            string palindrom = null;
            var exception = Assert.ThrowsException<NullReferenceException>(() => _arraysAndStrings.IsPalindromPermutation(palindrom));
            Assert.IsTrue(exception.GetType() == typeof(NullReferenceException));
        }

        [TestMethod]
        public void IsNotPalindromTest1()
        {
            string palindrom = "fasdf";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotPalindromTest2()
        {
            string palindrom = "as";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotPalindromTest3()
        {
            string palindrom = "tatata";
            bool result = _arraysAndStrings.IsPalindromPermutation(palindrom);
            Assert.IsFalse(result);
        }

        // Classic palindrom with special chars
        [TestMethod]
        public void IsPalindromClassic()
        {
            string palindrom = @"a,b'[a\";
            bool actual = _arraysAndStrings.IsPalindromClasic(palindrom);
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void IsPalindromClassic2()
        {
            string palindrom = @"a,b'[a";
            bool actual = _arraysAndStrings.IsPalindromClasic(palindrom);
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void IsPalindromClassic3()
        {
            string palindrom = @"-/.,a,b'[a\";
            bool actual = _arraysAndStrings.IsPalindromClasic(palindrom);
            bool expected = true;
            Assert.AreEqual(actual, expected);
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
        public void IsOneAwayTest21()
        {
            string first = "pale", second = "palse";
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

        [TestMethod]
        public void TwiceEditTest()
        {
            string first = "pale", second = "bqle";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TwiceEditTest2()
        {
            string first = "pale", second = "bqles";
            bool result = _arraysAndStrings.OneEditAway(first, second);
            Assert.IsFalse(result);
        }

        #endregion

        #region 1.6 Compression

        [TestMethod]
        public void StringCompressionTest1()
        {
            string str = "aabcccccaaa";
            string expected = "a2b1c5a3";
            string result = _arraysAndStrings.StringCompression(str);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringCompressionTest2()
        {
            string str = "abc";
            string expected = "abc";
            string result = _arraysAndStrings.StringCompression(str);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringCompressionTest3()
        {
            string str = "aaa";
            string expected = "a3";
            string result = _arraysAndStrings.StringCompression(str);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringCompressionTest4()
        {
            string str = "aaac";
            string expected = "a3c1";
            string result = _arraysAndStrings.StringCompression(str);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringCompressionTest5()
        {
            string str = "accc";
            string expected = "a1c3";
            string result = _arraysAndStrings.StringCompression(str);
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

        [TestMethod]
        public void IsRotationTest3()
        {
            string s1 = "waterbottle";
            string s2 = "erbottlewat";
            bool result = _arraysAndStrings.IsRotation(s1, s2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRotationTest4()
        {
            string s1 = "abc";
            string s2 = "ab";
            bool result = _arraysAndStrings.IsRotation(s1, s2);
            Assert.IsFalse(result);
        }

        #endregion

        #region 1..1 Sorting Region

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
            int[] arr = { 5, 4, 3, 2, 1 };
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
            int[] expected = { 1, 2, 1, 2, 1 };
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

        #region 1..2 Remove Duplicates From Each Substring in String

        [TestMethod]
        public void RemoveDupsTestSuccess1()
        {
            string str = "a";
            string expected = "a";
            var result = _arraysAndStrings.RemoveDupsFromSubstrings(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveDupsEmptyString()
        {
            string palindrom = "";
            var exception = Assert.ThrowsException<Exception>(() => _arraysAndStrings.RemoveDupsFromSubstrings(palindrom));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
        }

        [TestMethod]
        public void RemoveDupsNullString()
        {
            string palindrom = null;
            var exception = Assert.ThrowsException<NullReferenceException>(() => _arraysAndStrings.RemoveDupsFromSubstrings(palindrom));
            Assert.IsTrue(exception.GetType() == typeof(NullReferenceException));
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
        public void RemoveDupsNonAlphabetChar()
        {
            string str = "a-3[";
            var exception = Assert.ThrowsException<Exception>(() => _arraysAndStrings.RemoveDupsFromSubstrings(str));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
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

        #region 1..3 Reverse Words in string

        [TestMethod]
        public void ReverseWordsCorrectSentence()
        {
            string arrange = "This is a test";
            string expected = "test a is This";
            var result = _arraysAndStrings.ReverseWordsInString(arrange);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReverseWordsStringWithSpaces()
        {
            string arrange = "  This is a test  ";
            string expected = "test a is This";
            var result = _arraysAndStrings.ReverseWordsInString(arrange);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReverseWordsStringWithSpacesBetweenWords()
        {
            string arrange = "  This   is    a     test  ";
            string expected = "test     a    is   This";
            var result = _arraysAndStrings.ReverseWordsInString(arrange);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReverseWordsNullString()
        {
            string arrange = null;
            var exception = Assert.ThrowsException<NullReferenceException>(() => _arraysAndStrings.IsPalindromPermutation(arrange));
            Assert.IsTrue(exception.GetType() == typeof(NullReferenceException));
        }

        #endregion

        #region 1..4 Reverse Substrings

        [TestMethod]
        public void ReverseSubstringTest()
        {
            string str = "abc qwer";
            string expected = "cba rewq";
            var result = _arraysAndStrings.ReverseSubstrings(str);
            Assert.AreEqual(expected, result);
        }
        #endregion

        #region 1..5 Reverse String Region

        [TestMethod]
        public void ReverseStringTest()
        {
            string str = "abc";
            string expected = "cba";
            var result = _arraysAndStrings.ReverseString(str).ToString();
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region 1..6 Count unique Words in string

        [TestMethod]
        public void CountUniqueWordsTest1()
        {
            var result = _arraysAndStrings.CountUniqueWords(" a a a f d");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest2()
        {
            var result = _arraysAndStrings.CountUniqueWords(" aasdf aasdf a f d");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest3()
        {
            var result = _arraysAndStrings.CountUniqueWords("asdf");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest4()
        {
            var result = _arraysAndStrings.CountUniqueWords("qwer wetr erty qwer e");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest5()
        {
            var result = _arraysAndStrings.CountUniqueWords(null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest6()
        {
            var result = _arraysAndStrings.CountUniqueWords(" ");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest7()
        {
            var result = _arraysAndStrings.CountUniqueWords("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest8()
        {
            var result = _arraysAndStrings.CountUniqueWords("b");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest9()
        {
            var result = _arraysAndStrings.CountUniqueWords("b  c");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest10()
        {
            var result = _arraysAndStrings.CountUniqueWords("b!  b");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest11()
        {
            var result = _arraysAndStrings.CountUniqueWords("b!  b!");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsTest12()
        {
            var result = _arraysAndStrings.CountUniqueWords("b!  b@");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountUniqueWordsFromTextFile()
        {
            string filePath = @"C:\Users\v-vinala\source\repos\DataStructures\DataStructures\uniqueWords.txt";
            var result = _arraysAndStrings.CountUniqueWordsFromFile(filePath);
            Assert.AreEqual(2, result);
        }



        #endregion

        #region 1..7 Common Occurrence (majority number of digit in the array) 

        [TestMethod]
        public void CommonOccurence()
        {
            int[] arr = { 2, 2, 2, 3 };
            int expected = 2;
            int? actual = _arraysAndStrings.CommonOccurrence(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CommonOccurence1()
        {
            int[] arr = { 2, 2, 1, 3 };
            int expected = 2;
            int? actual = _arraysAndStrings.CommonOccurrence(arr);
            Assert.AreNotEqual(expected, null);
        }

        #endregion

        #region 1..8 shift zeros to the right


        [TestMethod]
        public void ShiftZerosToTheRight1()
        {
            int[] arr = { 0, 1, 2, 3 };
            int[] expected = { 3, 1, 2, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight2()
        {
            int[] arr = { 0, 0, 2, 3 };
            int[] expected = { 3, 2, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight3()
        {
            int[] arr = { 0, 1, 0, 3 };
            int[] expected = { 3, 1, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight4()
        {
            int[] arr = { 0, 1, 2, 0 };
            int[] expected = { 2, 1, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight5()
        {
            int[] arr = { 0, 1, 0, 0 };
            int[] expected = { 1, 0, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight6()
        {
            int[] arr = { 0, 0, 1, 0, 0, 0 };
            int[] expected = { 1, 0, 0, 0, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight7()
        {
            int[] arr = { 1, 2, 3 };
            int[] expected = { 1, 2, 3 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight8()
        {
            int[] arr = { 0, 0, 0 };
            int[] expected = { 0, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight9()
        {
            int[] arr = { 0, 1, 0, 1, 0 };
            int[] expected = { 1, 1, 0, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight10()
        {
            int[] arr = { 1, 0, 1, 0, 1 };
            int[] expected = { 1, 1, 1, 0, 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight11()
        {
            int[] arr = { };
            int[] expected = { };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight12()
        {
            int[] arr = { 0 };
            int[] expected = { 0 };
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void ShiftZerosToTheRight13()
        {
            int[] arr = null;
            int[] expected = null;
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ShiftZerosToTheRight14()
        {
            int[] arr = { 0, 0, 0, 0, 1 };
            int[] expected = { 1, 0, 0, 0, 0 }; ;
            int[] actual = _arraysAndStrings.ShiftZerosToTheRight(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        #endregion

        #region 1..9 Get Uniq Digits

        [TestMethod]
        public void GetUniqDigitsArrayTest31()
        {
            int[] arr = { 1, 1, 2, 3 };
            int[] expected = { 1, 2, 3, 0 };
            int[] actual = _arraysAndStrings.GetUniqDigitsArray(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void GetUniqDigitsArrayTest32()
        {
            int[] arr = { 1, 1, 1, 2, 3 };
            int[] expected = { 1, 2, 3, 0, 0 };
            int[] actual = _arraysAndStrings.GetUniqDigitsArray(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void GetUniqDigitsArrayTest3()
        {
            int[] arr = { 1, 1, 1, 3 };
            int[] expected = { 1, 3, 0, 0 };
            int[] actual = _arraysAndStrings.GetUniqDigitsArray(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void GetUniqDigitsArrayTest34()
        {
            int[] arr = { 1, 1, 1, 1 };
            int[] expected = { 1, 0, 0, 0 };
            int[] actual = _arraysAndStrings.GetUniqDigitsArray(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void GetUniqDigitsArrayTest35()
        {
            int[] arr = { 1, 1, 2, 2 };
            int[] expected = { 1, 2, 0, 0 };
            int[] actual = _arraysAndStrings.GetUniqDigitsArray(arr);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        #endregion

        #region 1..10 addition, subtraction, multiplication

        // ---------------- Start Addition ----------------

        [TestMethod]
        public void AdditionStringNumbers1()
        {
            string s1 = "123";
            string s2 = "129";
            string expected = "252";
            var result = _arraysAndStrings.AdditionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AdditionStringNumbers2()
        {
            string s1 = "12";
            string s2 = "129";
            string expected = "141";
            var result = _arraysAndStrings.AdditionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AdditionStringNumbers3()
        {
            string s1 = "129";
            string s2 = "12";
            string expected = "141";
            var result = _arraysAndStrings.AdditionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AdditionStringNumbers4()
        {
            string s1 = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
            string s2 = "987654321876543187645318765431287654312398765432187654318764531876543128765431239876543218765431876453187654312876543123";
            string expected = "1111111110888888866546553333321411111101411111111088888886654655333332141111110141111111108888888665465533333214111111013";
            var result = _arraysAndStrings.AdditionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AdditionStringNumbers5()
        {
            string s1 = "123456789";
            string s2 = "987654321";
            string expected = "1111111110";
            var result = _arraysAndStrings.AdditionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        // ---------------- End Addition ----------------

        // ---------------- Start Subtraction ----------------

        [TestMethod]
        public void SubtractionStringNumbers1()
        {
            string s1 = "36";
            string s2 = "24";
            string expected = "12";
            var result = _arraysAndStrings.SubtractionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractionStringNumbers2()
        {
            string s1 = "361";
            string s2 = "24";
            string expected = "337";
            var result = _arraysAndStrings.SubtractionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractionStringNumbers3()
        {
            string s1 = "25";
            string s2 = "26";
            string expected = "-1";
            var result = _arraysAndStrings.SubtractionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractionStringNumbers4()
        {
            string s1 = "25";
            string s2 = "260";
            string expected = "-235";
            var result = _arraysAndStrings.SubtractionStringNumbers(s1, s2);
            Assert.AreEqual(expected, result);
        }

        // ---------------- End Subtraction ----------------

        #endregion
    }
}
