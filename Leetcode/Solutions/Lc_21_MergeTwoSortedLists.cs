using Leetcode.Helpers;
using Leetcode.Solutions;

namespace Leetcode.Solutions
{
    public class Lc_21_MergeTwoSortedLists
    {
        // 21. Merge Two Sorted Lists
        // https://leetcode.com/problems/merge-two-sorted-lists/description/
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var root = new ListNode();
            var refIndex = root;
            var value1 = list1;
            var value2 = list2;
            var list1End = value1 is null;
            var list2End = value2 is null;
            while (!list1End && !list2End)
            {
                refIndex.next = new ListNode();
                refIndex = refIndex.next;
                if (value1.val <= value2.val)
                {
                    refIndex.val = value1.val;
                    value1 = value1.next;
                }
                else
                {
                    refIndex.val = value2.val;
                    value2 = value2.next;
                }
                list1End = value1 is null;
                list2End = value2 is null;
            }

            while (value1 is not null)
            {
                refIndex.next = new ListNode();
                refIndex = refIndex.next;
                refIndex.val = value1.val;
                value1 = value1.next;
            }

            while (value2 is not null)
            {
                refIndex.next = new ListNode();
                refIndex = refIndex.next;
                refIndex.val = value2.val;
                value2 = value2.next;
            }

            return root.next;
        }
    }

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

    public static class Lc_21_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 21 Merge Two Sorted Lists");

            var lc21code = new Lc_21_MergeTwoSortedLists();
            var list1 = new ListNode()
            {
                val = 1,
                next = new ListNode()
                {
                    val = 2,
                    next = new ListNode()
                    {
                        val = 4
                    }
                }
            };

            var list2 = new ListNode()
            {
                val = 1,
                next = new ListNode()
                {
                    val = 3,
                    next = new ListNode()
                    {
                        val = 4
                    }
                }
            };

            var head = lc21code.MergeTwoLists(list1, list2);
            Console.WriteLine("Expected Output: [1, 1, 2, 3, 4, 4]");
            var temp = head;
            while (temp.next != null)
            {
                Console.Write(temp.val + " ");
                temp = temp.next;
            }
            Console.Write(temp.val);
            Console.WriteLine("");
        }
    }
}