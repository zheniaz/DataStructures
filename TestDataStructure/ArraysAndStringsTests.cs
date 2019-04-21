using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
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
    }
}
