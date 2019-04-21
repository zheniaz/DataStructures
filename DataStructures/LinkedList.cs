using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DataStructures
{
    public class LinkedList
    {
        public Node head;
        public Node tail;

        public void Add(int data)
        {
            Node node = new Node(data);
            if (head != null)
            {
                tail.next = node;
            }
            else
            {
                head = node;
            }
            tail = node;
        }

        public void Remove(int data)
        {
            Node current = this.head;
            Node previous = null;
            while (current != null)
            {
                if (current.data == data)
                    break;
                previous = current;
                current = current.next;
            }

            if (previous != null)
            {
                previous.next = current.next;
                if (previous.next == null)
                {
                    tail = head;
                }
            }
            else
            {
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
            }
        }

        #region 2.1 Remove Dups Region

        public void RemoveDups(Node node)
        {
            HashSet<int> hs = new HashSet<int>();
            Node current = node;
            Node previous = null;
            while (current != null)
            {
                if (hs.Contains(current.data))
                {
                    previous.next = current.next;
                }
                else
                {
                    hs.Add(current.data);
                    previous = current;
                }
                current = current.next;
            }
        }

        public Node RemoveDuplicates(Node node)
        {
            if (node == null || node.next == null)
                return node;
            HashSet<int> hs = new HashSet<int>();
            Node current = node;
            Node previous = null;
            while (current != null)
            {
                if (hs.Contains(current.data))
                {
                    previous.next = current.next;
                }
                else
                {
                    hs.Add(current.data);
                    previous = current;
                }
                current = current.next;
            }
            return node;
        }

        #endregion

        #region 2.2 Return Kth to Last

        public int KthItemToLast(Node node, int k)
        {
            Node current = ReverseNode(node);

            while (current != null)
            {
                k--;
                if (k == 0)
                {
                    return current.data;
                }

                current = current.next;
            }
            return -1;
        }

        public Node ReverseNode(Node node)
        {
            Node previous = null;
            Node current = node;
            Node next = current.next;

            while (next != null)
            {
                current.next = previous;
                previous = current;
                current = next;
                next = next.next;
            }
            current.next = previous;
            return current;
        }



        #endregion

        #region 2.3 Delete Middle Node

        public bool DeleteMiddleNode(Node n)
        {
            if (n == null || n.next == null)
            {
                return false;
            }
            Node next = n.next;
            n.data = next.data;
            n.next = next.next;
            return true;
        }

        #endregion

        #region 2.4 Partition

        public Node Partition(Node node, int x)
        {
            Node head = node;
            Node tail = node;

            while (node != null)
            {
                Node next = node.next;
                if (node.data < x)
                {
                    node.next = head;
                    head = node;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }
                node = next;
            }
            tail.next = null;
            return head;
        }

        #endregion

        #region 2.5 Sum Lists

        public Node SumLists(Node n1, Node n2, int carry = 0)
        {
            if (n1 == null && n2 == null && carry == 0) return null;
            Node result = null;
            int value = carry;
            if (n1 != null) value += n1.data;
            if (n2 != null) value += n2.data;
            result = new Node(value % 10);
            if (n1 != null || n2 != null)
                result.next = SumLists(
                    n1 == null ? null : n1.next,
                    n2 == null ? null : n2.next,
                    value >= 10 ? 1 : 0);
            return result;
        }

        #endregion

        #region 2.6 Palindrome

        public bool IsLinkedListPalindrome(Node node)
        {
            if (node == null) return false;
            else if (node.next == null) return true;
            Node reverse = Reverse(node);
            while (node != null)
            {
                if(reverse.data != node.data)
                {
                    return false;
                }
                node = node.next;
            }
            return true;
        }

        public Node Reverse(Node node)
        {
            
            Node previous = null;
            Node current = node;
            Node next = node.next;
            while (next != null)
            {
                current.next = previous;
                previous = current;
                current = next;
                next = next.next;
            }
            current.next = previous;
            return current;
        }

        //New aproach
        public bool IsLLPalindrome(Node node)
        {
            if (node == null) return false;
            else if (node.next == null) return true;
            else if (node.next.next == null) return false;
            Node back = new Node(node.data);

            Node fast = node;
            while (fast != null)
            {
                if (fast.next == null) break;
                Node temp = new Node(node.next.data);
                temp.next = back;
                back = temp;
                node = node.next;
                fast = fast.next.next;
            }
            while (node != null)
            {
                if (node.data != back.data)
                {
                    return false;
                }
                node = node.next;
                back = back.next;
            }
            return true;
        }

        #endregion

        #region 2.8 Loop Devection

        public Node LoopDetection(Node node)
        {
            if (node == null || node.next == null) return null;
            if (node.next == node) return node;
            Node fast = node;
            Node slow = node;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) break;
            }
            if (fast == null || fast.next == null) return null;
            slow = node;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }

        public bool IsLinkedListHasALoop(Node node)
        {
            if (node == null) return false;
            if (node.next == null) return false;

            Node fastPointer = node;
            Node slowPointer = node;

            while (fastPointer != null && fastPointer.next != null)
            {
                if (fastPointer == slowPointer)
                {
                    return true;
                }
                slowPointer = slowPointer.next;
                if (fastPointer.next != null)
                {
                    fastPointer = fastPointer.next.next;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        #endregion
    }
}

