namespace Leetcode.Solutions
{
    public class Lc_61_RotateList
    {
        // 61. Rotate List
        // https://leetcode.com/problems/rotate-list/description/
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head is null || head.next is null) return head;

            var countSize = 1;
            var temp = head;
            // A.next -> B.next -> C.next -> D.next -> E.next = null
            while (temp.next != null)
            {
                countSize++;
                temp = temp.next;
            }
            temp.next = head; // create cycle
                              // A.next -> B.next -> C.next -> D.next -> E.next = A
            var tail = temp;

            var maxMoves = countSize - (k % countSize);
            // root = A
            // root.next = B

            temp = head;
            maxMoves--;
            while (maxMoves > 0)
            {
                temp = temp.next;
                maxMoves--;
            }
            head = temp.next;
            temp.next = null; // break;
            return head;
        }
    }

    /*
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
    */

    public static class Lc_61_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 61 Rotate List");

            var lc61code = new Lc_61_RotateList();
            var listRotate = new ListNode()
            {
                val = 1,
                next = new ListNode()
                {
                    val = 2,
                    next = new ListNode()
                    {
                        val = 3,
                        next = new ListNode()
                        {
                            val = 4,
                            next = new ListNode()
                            {
                                val = 5
                            }
                        }
                    }
                }
            };
            var listRotate1 = new ListNode()
            {
                val = 1,
                next = new ListNode()
                {
                    val = 2,
                    next = new ListNode()
                    {
                        val = 3
                    }
                }
            };

            var head = lc61code.RotateRight(listRotate, 2);
            Console.WriteLine("Expected Output: [4, 5, 1, 2, 3]");
            var temp = head;
            while (temp.next != null)
            {
                Console.Write(temp.val + " ");
                temp = temp.next;
            }
            Console.WriteLine(temp.val);
            head = lc61code.RotateRight(listRotate1, 4);

            Console.WriteLine("Expected Output: [3, 1, 2]");
            temp = head;
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