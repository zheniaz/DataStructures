using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LEAP
    {
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
    }
}
