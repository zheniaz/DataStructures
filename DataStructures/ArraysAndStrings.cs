using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class ArraysAndStrings
    {
        #region 1.1 Is Unique Region

        public bool IsUniq(string str)
        {
            if (str == null) throw new NullReferenceException();
            if (str == "") throw new Exception("String is empty");
            if (str.Length == 1) return true;
            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int item = str[i];
                if (charSet[item] == true)
                {
                    return false;
                }
                charSet[item] = true;
            }
            return true;
        }

        #endregion

        #region 1.2 Check Permutation Region

        public bool CheckPermutation(string s, string t)
        {
            if (s.Length != t.Length) return false;
            if ((s == null && t == null)
                || (s == "" && t == "")
                || (s.Length == 1 && t.Length == 1 && s == t))
                return true;
            int[] letter = new int[128];
            for (int i = 0; i < s.Length; i++)
            {
                ++letter[s[i]];
            }
            for (int i = 0; i < t.Length; i++)
            {
                --letter[t[i]];
                if (letter[t[i]] < 0) return false;
            }
            return true;
        }

        #endregion

        #region 1.4 Palindrom Region

        public bool IsPalindrom(string str)
        {
            if (str == null) throw new NullReferenceException();
            if (str == "") throw new Exception("String is empty");
            if (str.Length == 1) return true;
            str = str.ToLower();
            int oddCount = 0;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < str.Length; i++)
            {
                int count = 0;
                char item = str[i];
                if (item == ' ') continue;
                if (!ht.ContainsKey(item))
                {
                    ht.Add(item, ++count);
                }
                else
                {
                    count = (int)ht[item];
                    ht[item] = ++count;
                }
                oddCount = (count % 2 == 0) ? --oddCount : ++oddCount;
            }
            return oddCount <= 1;
        }

        #endregion

        #region 1.5 One Away Region

        public bool OneEditAway(string s, string t)
        {
            if (s == null && t == null || s == null || t == null)
                throw new NullReferenceException();
            if (s == "" && t == "") throw new Exception("Strings are empty");
            if (Math.Abs(s.Length - t.Length) > 1) return false;
            if (s.Length == t.Length)
            {
                return IsOneEdit(s, t);
            }
            return s.Length > t.Length ? IsOneInsert(s, t) : IsOneInsert(t, s);
        }

        private bool IsOneEdit(string s, string t)
        {
            bool isOneEdit = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    if (isOneEdit) return false;
                    isOneEdit = true;
                }
            }
            return true;
        }

        private bool IsOneInsert(string s, string t)
        {
            int indexS = 0;
            int indexT = 0;
            while (indexT < t.Length && indexS < s.Length)
            {
                if (s[indexS] != t[indexT])
                {
                    indexS++;
                    if (indexS - indexT > 1) return false;
                }
                else
                {
                    indexT++;
                    indexS++;
                }
            }
            return true;
        }

        #endregion

        #region 1.6 String  Compression Section

        public string StringCompression(string str)
        {
            if (str == null) throw new NullReferenceException();
            if (str == "") throw new Exception("String is empty");
            if (str.Length <= 2) return str;
            StringBuilder sb = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    sb.Append(str[i]).Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return (sb.Length <= str.Length) ? sb.ToString() : str;
        }

        #endregion

        #region 1.9 Rotation Region

        public bool IsRotation(string s, string t)
        {
            if (s == null && t == null || s == null || t == null)
                throw new NullReferenceException();
            if (s == "" && t == "") throw new Exception("Strings are empty");
            if (s.Length != t.Length) return false;
            string ss = s + s;
            return ss.Contains(t);
        }

        #endregion

        // Tasks From My Interviews

        #region 1..1 Sorting Region

        public int[] Sort(int[] arr)
        {
            if (arr == null) return null;
            if (arr.Length == 0) return null;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        public int[] SortSubArrays(int[] arr)
        {
            arr = Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                while (arr[i] == arr[i + 1])
                {
                    for (int j = i + 1; j < arr.Length - 1; j++)
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        #endregion

        #region 1..2 Remove Duplicates From Each Substring in String

        //public string RemoveDupsFromSubstrings(string str)
        //{
        //    if (str == null) throw new NullReferenceException();
        //    if (str == "") throw new Exception("String is empty");
        //    if (str.Length == 1) return str;
        //    if (!str.All(c => char.IsLetter(c))) throw new Exception("This string contains non alphabetic char");
        //    StringBuilder sb = new StringBuilder();
        //    char current = str[0];
        //    char next;
        //    sb.Append(current);
        //    for (int i = 0; i < str.Length - 1; i++)
        //    {
        //        current = str[i];
        //        next = str[i + 1];
        //        if (current != next)
        //        {
        //            sb.Append(next);
        //        }
        //    }
        //    return sb.ToString();
        //}

        public string RemoveDupsFromSubstrings(string str)
        {
            if (str == null) throw new NullReferenceException();
            if (str == "") throw new Exception("String is empty");
            if (str.Length == 1) return str;
            if (!str.All(c => char.IsLetter(c))) throw new Exception("This string contains non alphabetic chars");
            StringBuilder sb = new StringBuilder();
            sb.Append(str[0]);
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                {
                    sb.Append(str[i + 1]);
                }
            }
            return sb.ToString();
        }

        #endregion

        #region 1..3 Reverse Words in string

        public string ReverseWordsInString(string str)
        {
            str = str.Trim();
            StringBuilder sb = new StringBuilder();
            List<string> words = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' && sb.Length != 0)
                {
                    words.Add(sb.ToString());
                    sb.Clear();
                }
                else if (str[i] != ' ')
                {
                    sb.Append(str[i]);
                }
            }
            words.Add(sb.ToString());
            sb.Clear();

            for (int i = words.Count - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i != 0) sb.Append(' ');
            }
            return sb.ToString();
        }

        #endregion

        #region 1..4 Reverse Substrings

        public string ReverseSubstrings(string str)
        {
            if (str == null) throw new NullReferenceException();
            if (str == "") throw new Exception("String is empty");
            if (str.Length == 1) return str;
            str = str.Trim();
            str = ReverseString(str);
            List<string> words = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' && sb.Length != 0)
                {
                    words.Add(sb.ToString());
                    sb.Clear();
                }
                else if (str[i] != ' ')
                {
                    sb.Append(str[i]);
                }
            }
            words.Add(sb.ToString());
            sb.Clear();

            for (int i = words.Count - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i != 0) sb.Append(' ');
            }
            return sb.ToString();
        }

        #endregion

        #region 1..5 Reverse String Region

        public string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length / 2; i++)
            {
                char item = arr[i];
                arr[i] = str[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = item;
            }
            return new string(arr);
        }

        #endregion

        #region 1..6 Count unique Words in string

        public int CountUniqueWords(string str)
        {
            if (str == null) return 0;
            Hashtable words = new Hashtable();
            str = str.Trim();
            if (str == "") return 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    sb.Append(str[i]);
                }
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    string word = sb.ToString();
                    if (!words.ContainsKey(word))
                    {
                        words.Add(word, 1);
                    }
                    else
                    {
                        int count = (int)words[word];
                        words[word] = ++count;
                    }
                    sb.Clear();
                }
            }
            int uniqueCount = 0;
            var keyArr = words.Values;
            foreach (var item in keyArr)
            {
                if ((int)item == 1)
                {
                    uniqueCount++;
                }
            }
            return uniqueCount;
        }

        #endregion
    }
}
