using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1.DataStructure;
using ClassLibrary1.Print;

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

        }
        //104. Maximum Depth of Binary Tree
        public int MaxDepth_BFS(TreeNode root)
        {
        }
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
