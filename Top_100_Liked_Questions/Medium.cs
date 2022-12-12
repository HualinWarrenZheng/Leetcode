using ClassLibrary1.DataStructure;

namespace Top_100_Liked_Questions
{
    internal class Medium
    {
        public void Run()
        {
            //AddTwoNumbers(ListNode.Example1, ListNode.Example2);
        }
        //2. Add Two Numbers
        //72 58
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carryOrSum = 0;
            var result = new ListNode();
            var temp = result;

            while (l1 != null || l2 != null || carryOrSum > 0)
            {
                carryOrSum += (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                temp.next = new ListNode(carryOrSum % 10);
                temp = temp.next;
                carryOrSum /= 10;
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }
            return result.next;
        }
    }
}
