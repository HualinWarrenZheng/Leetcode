using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
