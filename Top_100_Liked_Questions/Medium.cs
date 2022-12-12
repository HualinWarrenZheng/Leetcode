using ClassLibrary1.DataStructure;

namespace Top_100_Liked_Questions
{
    internal class Medium
    {
        public void Run()
        {
            //AddTwoNumbers(ListNode.Example1, ListNode.Example2);
            LengthOfLongestSubstring("pwwkew");
        }
        //3. Longest Substring Without Repeating Characters
        //Hash Map, Two Pointers
        //68 46
        public int LengthOfLongestSubstring2(string s)
        {
            Dictionary<char, int> dic = new();
            var max = 0;
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    j = Math.Max(j, dic[s[i]] + 1);
                }
                dic[s[i]] = i;
                max = Math.Max(i - j + 1, max);
            }
            return max;
        }
        //5 27
        public int LengthOfLongestSubstring(string s)
        {
            List<char> charList = new();
            List<int> intList = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (!charList.Contains(s[i]))
                {
                    charList.Add(s[i]);
                }
                else
                {
                    intList.Add(charList.Count);
                    var index = charList.IndexOf(s[i]);
                    charList = charList.TakeLast(charList.Count - index - 1).ToList();
                    charList.Add(s[i]);
                }
            }
            intList.Add(charList.Count);
            return intList.Max();
        }

        //2. Add Two Numbers
        //72 58
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var temp = result;
            //var carryOrSum = 0;
            var carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                var sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                temp.next = new ListNode(sum % 10);
                temp = temp.next;
                carry = sum / 10;
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
