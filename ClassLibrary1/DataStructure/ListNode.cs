namespace ClassLibrary1.DataStructure
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

        public static ListNode Example1
        {
            get
            {
                ListNode three = new ListNode(3);
                ListNode two = new ListNode(2, three);
                ListNode one = new ListNode(1, two);

                return one;
            }
        }

        public static ListNode Example2
        {
            get
            {
                ListNode three = new ListNode(7);
                ListNode two = new ListNode(5, three);
                ListNode one = new ListNode(4, two);

                return one;
            }
        }
    }
}
