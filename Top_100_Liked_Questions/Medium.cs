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
            ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
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
