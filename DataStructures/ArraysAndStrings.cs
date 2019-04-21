﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class ArraysAndStrings
    {
        #region 1.1 Is Unique Region

        public bool IsUniq(string str)
        {
            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val]) return false;
                charSet[val] = true;
            }
            return true;
        }

        #endregion

        #region 1.2 Check Permutation Region

        public bool CheckPermutation(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] letters = new int[128];
            char[] charSet = s.ToCharArray();

            for (int i = 0; i < charSet.Length; i++)
            {
                letters[charSet[i]]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                letters[t[i]]--;
                if (letters[t[i]] < 0)
                    return false;
            }
            return true;
        }

        #endregion

        #region 1.4 Palindrom Region

        public bool IsPalindrom(string s)
        {
            s = s.ToLower();
            if (s.Length == 1) return true;
            Hashtable ht = new Hashtable();
            int countOfOdd = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                int count = 0;
                if (!ht.ContainsKey(s[i]))
                {
                    ht.Add(s[i], ++count);
                }
                else
                {
                    count = (int)ht[s[i]];
                    ht[s[i]] = ++count;
                }
                countOfOdd = (int)ht[s[i]] % 2 == 0 ? --countOfOdd : ++countOfOdd;
            }
            return countOfOdd <= 1;
        }


        #endregion

        #region 1.5 One Away Region

        public bool OneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
                return IsOneEdit(first, second);
            else if (first.Length > second.Length)
                return IsOneInsert(first, second);
            else if (first.Length < second.Length)
                return IsOneInsert(second, first);
            return false;
        }

        bool IsOneEdit(string s1, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        return false;
                    }
                    foundDifference = true;
                }
            }
            return true;
        }

        bool IsOneInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;
            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }
                    index1++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        #endregion

        #region 1.6 String  Compression Section

        public string StringComperission(string str)
        {
            StringBuilder sb = new StringBuilder();
            char? previous = null;
            char? current = str[0];
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                current = str[i];
                if (previous == null)
                {
                    previous = str[i];
                    count++;
                }
                else if (previous == current)
                {
                    count++;
                    previous = str[i];
                }
                else if (previous != current)
                {
                    sb.Append(previous);
                    sb.Append(count);
                    count = 1;
                    previous = str[i];
                }
                if (i == str.Length - 1)
                {
                    sb.Append(current);
                    sb.Append(count);
                }
                
            }
            return sb.Length > str.Length ? sb.ToString() : str;
        }

        #endregion

        #region 1.9 Rotation Region

        public bool IsRotation(string s1, string s2)
        {
            if (s1.Length > 0 && s1.Length == s2.Length)
            {
                string s1s2 = s1 + s1;
                return s1s2.Contains(s2);
            }
            return false;
        }

        #endregion

        #region Sorting Region

        static int[] Sort(int[] arr)
        {
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

        static int[] SortSort(int[] arr)
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
    }
}
