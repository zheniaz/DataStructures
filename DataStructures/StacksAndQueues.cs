using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MyStack
    {
        public Node top;
        public Node stackMin;
        public int count = 0;
        public List<MyStack> listOfStackPlates = new List<MyStack>();
        public readonly int stackSize = 2;

        #region Base functionality 

        public void Push(int data)
        {
            Node node = new Node(data);
            if (top == null)
            {
                top = node;
                AddNodeToTheTop(ref stackMin, top.data);
            }
            else
            {
                node.next = top;
                top = node;
                if (top.data < stackMin.data)
                {
                    AddNodeToTheTop(ref stackMin, top.data);
                }
            }
            count++;
        }

        public int? Pop()
        {
            int data;
            if (top != null)
            {
                data = top.data;
                top = top.next;
                RemoveTopNode(stackMin);
                count--;
            }
            else
                return null;
            return data;
        }

        public Node Peek()
        {
            if(this.top != null)
            {
                return this.top;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        #endregion

        #region 3.3 Stack of Plates

        public void AddToStackList(int data)
        {
            Node node = new Node(data);
            MyStack myStack = new MyStack();
            if (listOfStackPlates.Count == 0)
            {
                listOfStackPlates.Add(myStack);
            }
            var currentStack = listOfStackPlates[listOfStackPlates.Count - 1];

            if (currentStack.count < this.stackSize)
            {
                AddNodeToTheTop(ref currentStack.top, data);
                currentStack.count++;
            }

        }

        #endregion


        public void AddNodeToTheTop(ref Node node, int data)
        {
            Node item = new Node(data);
            item.next = node;
            node = item;
        }

        public void RemoveTopNode(Node myStack)
        {
            if (myStack != null)
            {
                myStack = myStack.next;
            }
        }
    }


    public class MyQueue
    {
        public Node first;
        public Node last;
        public int count = 0;
        public int maxSum = 0;

        public void Add(int data)
        {
            Node node = new Node(data);
            if (this.last != null)
            {
                last.next = node;
            }
            last = node;
            if (first == null)
            {
                first = last;
            }
            count++;
        }

        public int Remove()
        {
            int removed = 0;
            if (first != null)
            {
                removed = first.data;
                first = first.next;
            }
            count--;
            if (first == null)
            {
                last = null;
            }
            return removed;
        }

        #region 3..1 LEAP Max Subarray Sum task (Pasha Miller task from LEAP)

        public int[] MaxSubarraySum(int[] arr, int k)
        {
            MyQueue queue = new MyQueue();
            MyQueue maxQ = new MyQueue();
            for (int i = 0; i < arr.Length; i++)
            {
                if (queue.count < k)
                {
                    queue.Add(arr[i]);
                }
                else if (queue.count == k)
                {
                    queue.Add(arr[i]);
                    queue.Remove();
                    queue.maxSum = SumOfAllNodeItems(queue);
                    if (maxQ.maxSum < queue.maxSum)
                    {
                        maxQ = CloneQueue(queue);
                        maxQ.maxSum = queue.maxSum;
                    }
                }
            }
            return FromQueueToArray(maxQ);
        }

        #endregion

        #region Working Region

        private int[] FromQueueToArray(MyQueue q)
        {
            Node current = q.first;
            List<int> result = new List<int>();
            while (current != null)
            {
                result.Add(current.data);
                current = current.next;
            }
            return result.ToArray();
        }
    

        private int SumOfAllNodeItems(MyQueue q)
        {
            Node current = q.first;
            int sum = 0;
            while (current != null)
            {
                sum += current.data;
                current = current.next;
            }
            return sum;
        }

        private MyQueue CloneQueue(MyQueue myQ)
        {
            Node current = myQ.first;
            MyQueue result = new MyQueue();
            while (current != null)
            {
                result.Add(current.data);
                current = current.next;
            }
            return result;
        }

        #endregion
    }
}
