using ClassLibrary1.DataStructure;

namespace Top_100_Liked_Questions
{
    internal class Easy
    {

        public void Run()
        {
            //var nums = new int[] {2, 7, 11, 15 };
            //var target = 9;
            //var result = TwoSum2(nums, target);

            //var s = "([)]";
            //IsValid(s);

            //ListNode three = new() { val = 4 };
            //ListNode two = new() { next = three, val = 2 };
            //ListNode one = new() { next = two, val = 1 };

            //ListNode six = new() { val = 4 };
            //ListNode five = new() { next = six, val = 3 };
            //ListNode four = new() { next = five, val = 1 };

            //MergeTwoLists1(one, four);
            //var node = MergeTwoLists2(one, four);
            //var index = SearchInsert(new int[] { 3, 4, 5, 6 }, 1);

            //var a = ClimbStairs3(6);

            //Iterative iterative = new();
            //iterative.Print(TreeNode.Example1);

            //var result = InorderTraversal1(TreeNode.Example1);
            //PrintList.PrintOut(result);

            //var result2 = InorderTraversal2(TreeNode.Example1);
            //PrintList.PrintOut(result2);

            //var result = IsSymmetric2(TreeNode.Example3);
            //Generate(5);
        }
        //160. Intersection of Two Linked Lists
        // 83 20
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            Dictionary<ListNode, ListNode> dic = new();
            while (headA != null)
            {
                if (headA.next != null)
                {
                    dic.Add(headA, headA.next);
                    headA = headA.next;
                }
                else
                {
                    dic.Add(headA, null);
                    break;
                }
            }

            while (headB != null)
            {
                if (dic.ContainsKey(headB))
                {
                    return headB;
                }
                else
                {
                    if (headB.next != null)
                    {
                        dic.Add(headB, headB.next);
                        headB = headB.next;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return null;
        }
        //141. Linked List Cycle
        //Floyd’s Cycle-Finding Algorithm 71 49
        public bool HasCycle2(ListNode head)
        {
            if (head == null) return false;
            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast.next == null || fast == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }
        //66 7
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            Dictionary<ListNode, ListNode> dic = new();
            while (true)
            {
                if (head.next == null)
                {
                    break;
                }
                dic.Add(head, head.next);
                head = head.next;
                if (dic.ContainsKey(head))
                {
                    return true;
                }
            }
            return false;
        }

        //136. Single Number
        //
        public int SingleNumber2(int[] nums)
        {
            int a = 0;
            foreach (var n in nums)
                a ^= n;
            return a;
        }
        //13 35
        public int SingleNumber(int[] nums)
        {
            List<int> list = new List<int>();
            foreach (var num in nums)
            {
                if (!list.Contains(num))
                {
                    list.Add(num);
                }
                else
                {
                    list.Remove(num);
                }
            }
            return list[0];
        }
        //121. Best Time to Buy and Sell Stock
        //56 100
        public int MaxProfit2(int[] prices)
        {
            var min = int.MaxValue;
            var profit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                if (prices[i] - min > profit)
                {
                    profit = prices[i] - min;
                }
            }
            return profit;
        }
        // Time Limit Exceeded
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
            {
                return 0;
            }
            var profit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                var diff = 0;
                for (int j = i; j < prices.Length; j++)
                {
                    if (prices[j] - prices[i] > diff)
                    {
                        diff = prices[j] - prices[i];
                    }
                }
                if (diff > profit)
                {
                    profit = diff;
                }
            }

            return profit;
        }
        //118. Pascal's Triangle
        // 57 100
        public IList<IList<int>> Generate3(int numRows)
        {
            var rows = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                rows[i] = new int[i + 1];
                rows[i][0] = rows[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    rows[i][j] = rows[i - 1][j] + rows[i - 1][j - 1];
                }
            }
            return rows;
        }
        //5 68
        public IList<IList<int>> Generate2(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            List<int> list1 = new() { 1 };
            list.Add(list1);
            for (int i = 1; i < numRows; i++)
            {
                List<int> newList = new();
                newList.Add(1);
                for (int j = 1; j < list1.Count(); j++)
                {
                    newList.Add(list1[j] + list1[j - 1]);
                }
                newList.Add(1);

                list.Add(newList);
                list1 = newList;
            }
            return list;
        }
        //33 38
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            List<int> list1 = new() { 1 };
            list.Add(list1);
            for (int i = 1; i < numRows; i++)
            {
                var newList = Helper(list1);
                list.Add(newList);
                list1 = newList;
            }
            return list;
        }
        List<int> Helper(List<int> pre)
        {
            List<int> cur = new();
            var length = pre.Count();
            cur.Add(1);
            for (int i = 1; i < length; i++)
            {
                cur.Add(pre[i] + pre[i - 1]);
            }
            cur.Add(1);
            return cur;
        }

        //108. Convert Sorted Array to Binary Search Tree
        // 8 36
        public TreeNode SortedArrayToBST2(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
            TreeNode Helper(int[] nums, int left, int right)
            {
                if (left > right)
                {
                    return null;
                }
                var mid = (left + right) / 2;
                var node = new TreeNode(nums[mid])
                {
                    left = Helper(nums, left, mid - 1),
                    right = Helper(nums, mid + 1, right)
                };
                return node;
            }
        }


        // 99 7
        public TreeNode SortedArrayToBST1(int[] nums)
        {
            var length = nums.Length;
            var mid = nums.Length / 2;

            if (length == 0)
            {
                return null;
            }
            if (length == 1)
            {
                return new TreeNode(nums[0]);
            }

            return new TreeNode(nums[mid], SortedArrayToBST1(nums.Take(mid).ToArray()), SortedArrayToBST1(nums.TakeLast(length - mid - 1).ToArray()));
        }
        //104. Maximum Depth of Binary Tree
        //Use Queue 73 26
        public int MaxDepth_BFS_Iterative2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var queue = new Queue<TreeNode>();
            TreeNode temp;
            var level = 0;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                level++;
                var count = queue.Count();
                while (count-- > 0)
                {
                    temp = queue.Dequeue();
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                    }
                }

            }

            return level;
        }
        //56 26
        public int MaxDepth_BFS_Iterative1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var list = new List<TreeNode>();
            var level = 0;
            list.Add(root);

            while (list.Count > 0)
            {
                level++;
                var newList = new List<TreeNode>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].left != null)
                    {
                        newList.Add(list[i].left);
                    }
                    if (list[i].right != null)
                    {
                        newList.Add(list[i].right);
                    }
                }
                list = newList;
            }

            return level;
        }
        // 65 60
        public int MaxDepth_DFS_Recursive(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = MaxDepth_DFS_Recursive(root.left);
            int right = MaxDepth_DFS_Recursive(root.right);
            return Math.Max(left, right) + 1;
        }

        //101. Symmetric Tree
        //45 56
        public bool IsSymmetric2(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }
                if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }
                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);

            }
            return true;
        }
        //recurrsive
        public bool IsSymmetric1(TreeNode root)
        {
            return root == null || IsSymmetricHelper(root.left, root.right);
        }

        public bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            #region Opotion 1
            //if (left == null && right == null)
            //{
            //    return true;
            //}

            //if (left == null || left == null)
            //{
            //    return false;
            //}
            #endregion
            #region option 2
            if (left == null || left == null)
            {
                return left == right;
            }
            #endregion

            if (left.val != right.val)
            {
                return false;
            }
            return IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
        }

        //94. Binary Tree Inorder Traversal (Left -> Root -> Right)
        //Iterative 91 8
        public IList<int> InorderTraversal2(TreeNode root)
        {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                list.Add(root.val);
                root = root.right;
            }
            return list;
        }

        //Recursive 
        public IList<int> InorderTraversal1(TreeNode root)
        {
            var list = new List<int>();
            helper(root, list);
            return list;
        }
        void helper(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                helper(root.left, list);
                list.Add(root.val);
                helper(root.right, list);
            }
        }
        //70. Climbing Stairs
        //Array 65 38
        public int ClimbStairs3(int n)
        {
            if (n <= 2)
                return n;

            int[] nums = new int[n + 1];

            nums[1] = 1;
            nums[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                nums[i] = nums[i - 1] + nums[i - 2];
            }

            return nums[n];
        }

        //Iterative 25 38
        public int ClimbStairs2(int n)
        {
            if (n <= 2)
                return n;
            int n1 = 1, n2 = 2;
            int result = 0;

            for (int i = 3; i <= n; i++)
            {
                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }

            return result;
        }

        //Recursive Time out
        public int ClimbStairs1(int n)
        {
            if (n <= 2)
                return n;
            return ClimbStairs1(n - 1) + ClimbStairs1(n - 2);
        }

        //35. Search Insert Position
        //53 48
        public int SearchInsert(int[] nums, int target)
        {
            var min = 0;
            var max = nums.Length - 1;
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (nums[mid] == target)
                    return mid;

                if (nums[mid] > target)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

            }
            return min;
        }

        // 21. Merge Two Sorted Lists

        // Recursive 19 34
        public ListNode MergeTwoLists2(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists2(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists2(list2.next, list1);
                return list2;
            }

        }

        // Iterative 86 9
        public ListNode MergeTwoLists1(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            ListNode head = new(), move = head;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    move.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    move.next = list2;
                    list2 = list2.next;
                }
                move = move.next;
            }

            if (list1 != null)
            {
                move.next = list1;
            }

            if (list2 != null)
            {
                move.next = list2;
            }

            return head.next;
        }

        //20. Valid Parentheses
        public bool IsValid(string s)
        {
            if (s.Length % 2 != 0) return false;

            Stack<char> stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(')');
                }
                else if (c == '[')
                {
                    stack.Push(']');
                }
                else if (c == '{')
                {
                    stack.Push('}');
                }
                else if (stack.Count == 0 || stack.Pop() != c)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }

        //1. Two Sum
        // 81 42
        public int[] TwoSum2(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var left = nums[i];
                var right = target - nums[i];
                if (dic.ContainsKey(right))
                {
                    return new int[] { dic[right], i };
                }
                else
                {
                    dic[left] = i;
                }
            }

            return Array.Empty<int>();
        }
        // 40 95
        public int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[2];
        }
    }
}
