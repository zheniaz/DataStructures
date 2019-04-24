using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LEAP
    {
        #region Find Max Subarray Sum

        public int[] MaxSubarraySum(int[] arr, int x)
        {
            if (arr.Length == 0 || arr.Length < x)
            {
                return Array.Empty<int>();
            }

            MyQueue q = FillQueue(arr, x);//n
            int pSum = 0;
            int cSum = 0;
            int[] result = new int[x];//n
            for (int i = x; i < arr.Length; i++) // n = arr.Length
            {
                pSum = Sum(q); // n = x.Length
                q.Remove();
                q.Add(arr[i]);
                cSum = Sum(q);
                if (cSum > pSum)
                {
                    result = FillArray(q);
                }
            }
            return result;
        }

        public int[] FillArray(MyQueue q)
        {
            int[] arr = new int[q.count];
            Node node = q.first;
            for (int i = 0; i < q.count; i++)
            {
                arr[i] = node.data;
                node = node.next;
            }
            return arr;
        }

        public MyQueue FillQueue(int[] arr, int x)
        {
            MyQueue q = new MyQueue();
            while(q.count != x)
            {
                q.Add(arr[q.count]);
            }
            return q;
        }

        int Sum(MyQueue q)
        {
            int result = 0;
            Node n = q.first;
            while (n != null)
            {
                result += n.data;
                n = n.next;
            }
            return result;
        }

        #endregion

        #region FindMaxProductContinousSubSet

        //I/P - {3,2,-1,4}
        //O/P - {3,2}

        //I/P - {1,2,3,4}
        //O/P - {1,2,3,4}

        //I/P - {-2,4,5,-3}
        //O/P - {-2,4,5,-3}

        //Continous SubSet:

        //{3,2}        =    3 * 2 = 6
        //{3,2,-1}     =    3 * 2 * -1 = -6
        //{3,2,-1,4}   =    3 * 2 * -1 * 4 = -24
        //{2,-1}        =    -2
        //{2,-1,4}       =    -8 

        //Not Continous SubSet:
        //{3,4}

        public int[] FindMaxProductContinousSubSet(int[] input)
        {
            int[] maxProductSubSet = null;
            int multiplyResult = 1;
            List<int> subSet = new List<int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                subSet.Add(input[i]);
                int temp = input[i];
                
                for (int j = i + 1; j < input.Length; j++)
                {
                    subSet.Add(input[j]);
                    temp *= input[j];
                    if (temp > multiplyResult)
                    {
                        multiplyResult = temp;
                        maxProductSubSet = subSet.ToArray();
                    }
                }
                subSet = new List<int>();
            }
            return maxProductSubSet;
        }

        #endregion
    }
}
