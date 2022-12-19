using System.Collections;
using System.Globalization;

using ClassLibrary1.DataStructure;

namespace Top_100_Liked_Questions
{
    internal class Medium
    {
        public void Run()
        {
            //AddTwoNumbers(ListNode.Example1, ListNode.Example2);
            //LengthOfLongestSubstring("pwwkew");
            //var result = LongestPalindrome("2123321");
            //ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //var result = LetterCombinations("239");
            //RemoveNthFromEnd(ListNode.Example1, 1);
            var list = GenerateParenthesis(3);
        }
        //22. Generate Parentheses
        public List<String> GenerateParenthesis(int n)
        {
            List<String> list = new();
            backtrack(list, "", 0, 0, n);
            return list;
        }

        public void backtrack(List<String> list, String str, int open, int close, int max)
        {

            if (str.Length == max * 2)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                backtrack(list, str + "(", open + 1, close, max);
            if (close < open)
                backtrack(list, str + ")", open, close + 1, max);
        }
        //19. Remove Nth Node From End of List
        //Two Pointers 100 23
        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {

            var fast = head;
            var slow = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
                if (fast == null)
                {
                    return head.next;
                }
            }
            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            slow.next = slow.next.next;

            return head;

        }
        // 90 72
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var count = 0;
            var temp1 = head;
            var temp2 = head;
            while (temp1 != null)
            {
                count++;
                temp1 = temp1.next;
            }
            if (count == n)
            {
                return head.next;
            }
            for (int i = 0; i < count; i++)
            {
                if (i == count - n - 1)
                {
                    temp2.next = temp2.next.next;
                    break;
                }
                temp2 = temp2.next;
            }
            return head;
        }
        //17. Letter Combinations of a Phone Number
        //Dictionary, swap 61 92
        public IList<string> LetterCombinations2(string digits)
        {
            Dictionary<char, string> dic = new() {
                {'0', ""},
                {'1', ""},
                {'2', "abc" },
                {'3', "def" },
                {'4', "ghi" },
                {'5', "jkl" },
                {'6', "mno" },
                {'7', "pqrs" },
                {'8', "tuv" },
                {'9', "wxyz" },
            };
            List<string> result = new();
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }
            result.Add("");
            foreach (var d in digits)
            {
                List<string> temp = new();
                foreach (var item in dic[d])
                {
                    foreach (var r in result)
                    {
                        temp.Add(r + item);
                    }
                }
                result = temp;
            }
            return result;
        }

        //Queue 9 52
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
            {
                return new List<string>();
            }
            string[] array1 = new string[10] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("");
            for (int i = 0; i < digits.Length; i++)
            {
                var value = array1[digits[i] - '0'];
                while (queue.Peek().Length == i)
                {
                    var temp = queue.Dequeue();
                    foreach (var v in value)
                    {
                        queue.Enqueue(temp + v);
                    }

                }
            }

            return queue.ToList();
        }
        //15. 3Sum
        // 70 78
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;
                while (k > j)
                {
                    if (nums[j] + nums[k] > -nums[i])
                    {
                        k--;
                    }
                    else if (nums[j] + nums[k] < -nums[i])
                    {
                        j++;
                    }
                    else
                    {
                        var subList = new List<int> { nums[j], nums[k], nums[i] };
                        list.Add(subList);
                        while (j < k && nums[j] == subList[0])
                        {
                            j++;
                        }
                        while (j < k && nums[k] == subList[1])
                        {
                            k--;
                        }
                    }
                }
                while (i < nums.Length - 2 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }

            return list;
        }

        //11. Container With Most Water
        //97 8
        public int MaxArea2(int[] height)
        {
            int MaxArea = 0, i = 0, j = height.Length - 1;
            while (i < j)
            {
                MaxArea = Math.Max((j - i) * Math.Min(height[j], height[i]), MaxArea);
                if (height[j] < height[i])
                {
                    j--;
                }
                else
                {
                    i++;
                }
                //(i, j) = height[j] < height[i] ? (i, j-1) : (i+1, j);
            }

            return MaxArea;
        }

        //Time Limit Exceeded
        public int MaxArea(int[] height)
        {
            var MaxArea = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    MaxArea = Math.Max((j - i) * Math.Min(height[j], height[i]), MaxArea);
                }
            }

            return MaxArea;
        }

        //5. Longest Palindromic Substring
        //95 50
        public string LongestPalindrome(string s)
        {
            if (s.Length < 2)
            {
                return s;
            }
            var maxLength = 0;
            var start = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                Helper(s, i, i + 1); Helper(s, i, i);
            }

            void Helper(string s, int i, int j)
            {
                while (i >= 0 && j < s.Length && s[i] == s[j])
                {
                    i--;
                    j++;
                }
                if (maxLength < j - i - 1)
                {
                    start = i + 1;
                    maxLength = j - i - 1;
                }
            }
            return s.Substring(start, maxLength);
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
