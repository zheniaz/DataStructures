using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class ArraysAndStrings
    {
        #region 1.1 Is Unique Region

        public bool IsUniq(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new Exception("The string is null, or empty!");
            }
            var charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                var item = str[i];
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

        public bool IsPermutation(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                throw new NullReferenceException();
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            if ((s == null && t == null)
                || (s == "" && t == "")
                || (s.Length == 1 && t.Length == 1 && s == t))
            {
                return true;
            }

            int[] letter = new int[128];
            for (int i = 0; i < s.Length; i++)
            {
                ++letter[s[i]];
            }
            for (int i = 0; i < t.Length; i++)
            {
                --letter[t[i]];
                if (letter[t[i]] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 1.4 Palindrom Region

        public bool IsPalindromPermutation(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new NullReferenceException();
            }
            if (str.Length <= 1)
            {
                return true;
            }
            str = str.ToLower();
            int oddCount = 0;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < str.Length; i++)
            {
                int count = 0;
                if (str[i] == ' ' || !Char.IsLetter(str[i]))
                {
                    continue;
                }
                if (!ht.Contains(str[i]))
                {
                    ht.Add(str[i], ++count);
                }
                else
                {
                    count = (int)ht[str[i]];
                    ht[str[i]] = ++count;
                }
                oddCount = (int)ht[str[i]] % 2 != 0 ? ++oddCount : --oddCount;
            }
            return oddCount <= 1;
        }

        // "aba" == true; "a,,;b]a" == true;
        public bool IsPalindromClasic(string str)
        {
            if (str == "" || str.Length == 1)
            {
                return true;
            }

            int start = 0;
            int end = str.Length - 1;
            for (int i = 0; i < str.Length / 2; i++)
            {
                while (!Char.IsLetter(str[start]) && !Char.IsNumber(str[start]) && start < end)
                {
                    start++;
                }
                while (!Char.IsLetter(str[end]) && !Char.IsNumber(str[end]) && end > start)
                {
                    end--;
                }

                if (str[start] != str[end])
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 1.5 One Away Region

        public bool OneEditAway(string s, string t)
        {
            if (s == null && t == null || s == null || t == null)
            {
                throw new NullReferenceException();
            }

            if (s == "" && t == "")
            {
                throw new Exception("Strings are empty");
            }

            if (Math.Abs(s.Length - t.Length) > 1)
            {
                return false;
            }

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
                    if (isOneEdit)
                    {
                        return false;
                    }

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
                    if (indexS - indexT > 1)
                    {
                        return false;
                    }
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
            if (str == null)
            {
                throw new NullReferenceException();
            }

            if (str == "")
            {
                throw new Exception("String is empty");
            }

            if (str.Length <= 2)
            {
                return str;
            }

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
            {
                throw new NullReferenceException();
            }

            if (s == "" && t == "")
            {
                throw new Exception("Strings are empty");
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            string ss = s + s;
            return ss.Contains(t);
        }

        #endregion

        #region 1..1 Sorting Region

        public int[] Sort(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            if (arr.Length == 0)
            {
                return null;
            }

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

        public string RemoveDupsFromSubstrings(string str)
        {
            if (str == null)
            {
                throw new NullReferenceException();
            }

            if (str == "")
            {
                throw new Exception("String is empty");
            }

            if (str.Length == 1)
            {
                return str;
            }

            if (!str.All(c => char.IsLetter(c)))
            {
                throw new Exception("This string contains non alphabetic chars");
            }
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
                if (i != 0)
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }

        // new approach using list of strings
        public string ReverseWordsInString2(string str)
        {
            List<string> words = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    sb.Append(str[i]);
                }
                else
                {
                    words.Add(sb.ToString());
                    sb.Clear();
                }
            }
            words.Add(sb.ToString());
            sb.Clear();
            for (int i = words.Count - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                sb.Append(' ');
            }
            return sb.ToString();
        }
        #endregion

        #region 1..4 Reverse Substrings

        public string ReverseSubstrings(string str)
        {
            if (str == null)
            {
                throw new NullReferenceException();
            }

            if (str == "")
            {
                throw new Exception("String is empty");
            }

            if (str.Length == 1)
            {
                return str;
            }

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
                if (i != 0)
                {
                    sb.Append(' ');
                }
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
            if (str == null)
            {
                return 0;
            }

            Hashtable words = new Hashtable();
            str = str.Trim();
            if (str == "")
            {
                return 0;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c != ' ')
                {
                    if (char.IsLetter(c))
                    {
                        sb.Append(c);
                    }

                }
                if (str[i] == ' ' && sb.Length != 0 || i == str.Length - 1)
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

        public int CountUniqueWordsFromFile(string filePath)
        {
            if (filePath == null)
            {
                return 0;
            }

            Hashtable words = new Hashtable();
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> lines = null;
            if (File.Exists(filePath))
            {
                lines = File.ReadLines(filePath);
            }
            else
            {
                throw new Exception("File does not exist");
            }

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (!char.IsLetter(line[i]))
                    {
                        continue;
                    }
                    if (line[i] != ' ')
                    {
                        sb.Append(line[i]);
                    }
                    if (line[i] == ' ' || i == line.Length - 1)
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

        #region 1..7 Common Occurrence (majority number of digit in the array) 

        public int? CommonOccurrence(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            int middleMore = (arr.Length / 2) + 1;
            int occurrences = 0;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!ht.Contains(arr[i]))
                {
                    ht.Add(arr[i], 1);
                }
                else
                {
                    int value = (int)ht[arr[i]];
                    ht[arr[i]] = ++value;
                    if (occurrences < value)
                    {
                        occurrences = value;
                    }

                    if (value >= middleMore)
                    {
                        return arr[i];
                    }

                    if ((arr.Length - i - 1 + occurrences) < middleMore)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 1..8 shift zeros to the right
        // Move all zeros in an array to the end
        public int[] ShiftZerosToTheRight(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
            {
                return arr;
            }
            int indexForZero = arr.Length - 1;
            for (int i = 0; i <= indexForZero; i++)
            {
                if (arr[i] == 0)
                {
                    if (arr[indexForZero] == 0)
                    {
                        while (arr[indexForZero] == 0)
                        {
                            Debug.WriteLine(arr);
                            if (indexForZero == i)
                            {
                                return arr;
                            }
                            indexForZero--;
                        }
                    }
                    int current = arr[i];
                    arr[i] = arr[indexForZero];
                    arr[indexForZero] = current;
                    indexForZero--;
                }
            }
            return arr;
        }

        #endregion

        #region 1..9 Get Uniq Digits

        public int[] GetUniqDigitsArray(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }
            int currentIndex = 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    continue;
                }
                else if (arr[i] != arr[i + 1])
                {
                    arr[currentIndex] = arr[i + 1];
                    currentIndex++;
                }
            }
            for (int i = currentIndex; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }

        #endregion

        #region 1..10 addition, subtraction, multiplication

        // ---------------- Start Addition ----------------

        public string AdditionStringNumbers(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                throw new Exception("Bad deal");
            }
            StringBuilder sb = new StringBuilder();
            int index1 = num1.Length - 1;
            int index2 = num2.Length - 1;
            int currentSum = 0;
            int carry = 0;
            while (index1 >= 0 || index2 >= 0)
            {
                if (carry > 0)
                {
                    currentSum += carry;
                }
                if (index1 >= 0)
                {
                    var temp = (int)char.GetNumericValue(num1[index1]);
                    if (temp == -1)
                    {
                        throw new Exception("Bad deals");
                    }
                    currentSum += temp;
                    index1--;
                }
                if (index2 >= 0)
                {
                    var temp = (int)char.GetNumericValue(num2[index2]);
                    if (temp == -1)
                    {
                        throw new Exception("Bad deals");
                    }
                    currentSum += temp;
                    index2--;
                }
                if (currentSum >= 10)
                {
                    sb.Insert(0, currentSum % 10);
                    carry = currentSum / 10;
                }
                else
                {
                    sb.Insert(0, currentSum);
                    carry = 0;
                }
                currentSum = 0;
            }
            if (carry > 0)
            {
                sb.Insert(0, carry);
            }
            return sb.ToString();
        }

        // ---------------- End Addition ----------------

        // ---------------- Start Subtraction ----------------

        public string SubtractionStringNumbers(string num1, string num2)
        {
            var result = "";
            if (IsFirtsBigger(num2, num1))
            {
                result = "-" + Subtraction(num2, num1);
            }
            else
            {
                result = Subtraction(num1, num2);
            }
            return result;
        }

        public string Subtraction(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            int index1 = num1.Length - 1;
            int index2 = num2.Length - 1;
            int carry = 0;
            int currentSub = 0;
            while (index1 >= 0 || index2 >= 0)
            {
                var c1 = (int)Char.GetNumericValue(num1[index1]);
                var c2 = index2 >= 0 ? (int)Char.GetNumericValue(num2[index2]) : 0;
                index1--;
                index2--;
                if (carry > 0)
                {
                    c1 -= carry;
                    carry = 0;
                }
                if (c2 > c1)
                {
                    currentSub = 10 + c1 - c2;
                    carry++;
                }
                else
                {
                    currentSub = c1 - c2;
                }
                sb.Insert(0, currentSub);
                currentSub = 0;
            }
            if (sb[0] == '0')
            {
                while (sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }
            }
            return sb.ToString();
        }

        public bool IsFirtsBigger(string s, string t)
        {
            if (s.Length > t.Length)
            {
                return true;
            }

            if (s.Length < t.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > t[i])
                {
                    return true;
                }
            }
            return false;
        }

        // ---------------- End Subtraction ----------------

        // ---------------- Start multiplication ----------------

        public string Multiplication(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                throw new Exception("Bed deal");
            }
            StringBuilder sb = new StringBuilder();
            int indexS = s.Length - 1;
            int indexT = t.Length - 1;
            int currentValue = 0;
            int carry = 0;
            List<string> list = new List<string>();

            for (indexS = s.Length - 1; indexS >= 0; indexS--)
            {
                sb.Append(GetZerosString(s.Length - 1 - indexS));
                for (indexT = t.Length - 1; indexT >= 0; indexT--)
                {
                    currentValue = (int)Char.GetNumericValue(s[indexS]) * (int)Char.GetNumericValue(t[indexT]);
                    if (carry > 0)
                    {
                        currentValue += carry;
                    }
                    if (currentValue >= 10)
                    {
                        carry = currentValue / 10;
                        sb.Insert(0, currentValue % 10);
                    }
                    else
                    {
                        sb.Insert(0, currentValue);
                        carry = 0;
                    }
                    currentValue = 0;
                }
                if (carry > 0)
                {
                    sb.Insert(0, carry);
                    carry = 0;
                }
                list.Add(sb.ToString());
                sb.Clear();
            }
            string current = list[0];

            for (int i = 1; i < list.Count(); i++)
            {
                current = AdditionStringNumbers(current, list[i]);
            }
            return current;
        }

        public string GetZerosString(int count)
        {
            StringBuilder sb = new StringBuilder();
            while(count > 0)
            {
                sb.Append('0');
                count--;
            }
            return sb.ToString();
        }

        // ---------------- End multiplication ------------------



        #endregion
    }
}
