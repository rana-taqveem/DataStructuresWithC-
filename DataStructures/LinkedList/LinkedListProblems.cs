using System;
namespace DataStructures.LinkedList
{
    public class ListNode
    {
      public int val;
      public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkedListProblems
    {
        public LinkedListProblems()
        {
        }

        public static int GetSumAndCarryAndMoveNext(ref ListNode l1, ref ListNode l2, ref int carry)
        {
            int sum = 0;
            
            if (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + carry;
                l1 = l1.next;
                l2 = l2.next;
            }
            else if (l2 != null)
            {
                sum = l2.val + carry;
                l2 = l2.next;
            }
            else
            {
                sum = l1.val + carry;
                l1 = l1.next;
            }


            carry = sum >= 10 ? 1 : 0;
            sum = sum % 10;
            return sum;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carry = 0;
            var sum = GetSumAndCarryAndMoveNext(ref l1, ref l2, ref carry);

            ListNode head = new ListNode(sum);
            ListNode previous = head;

            while (l1 != null || l2 != null)
            {
                sum = GetSumAndCarryAndMoveNext(ref l1, ref l2, ref carry);
                ListNode node = new ListNode(sum);
                previous.next = node;
                previous = node;
            }

            if (carry > 0)
                previous.next = new ListNode(carry);

            return head;
        }
    }
}
