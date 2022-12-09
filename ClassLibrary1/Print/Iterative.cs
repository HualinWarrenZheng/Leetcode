using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1.Abstract;
using ClassLibrary1.DataStructure;

namespace ClassLibrary1.Print
{
    public class Iterative : Tree
    {
        public void Print(TreeNode root)
        {
            var inoder = InOrder(root);
            var preorder = PreOrder(root);
            var postorder = PostOrder(root);
            Console.Write("  InOrder:");
            PrintList.PrintOut(inoder);
            Console.Write(" PreOrder:");
            PrintList.PrintOut(preorder);
            Console.Write("PostOrder:");
            PrintList.PrintOut(postorder);
        }
        public override IList<int> InOrder(TreeNode root)
        {
            List<int> list = new();
            Stack<TreeNode> stack = new();
            TreeNode temp = root;
            while (temp != null || stack.Count > 0)
            {
                if (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.left;
                }
                else
                {
                    temp = stack.Pop();
                    list.Add(temp.val);
                    temp = temp.right;
                }
            }
            return list;
        }

        public override IList<int> PostOrder(TreeNode root)
        {
            List<int> list = new();
            Stack<TreeNode> stack1 = new(), stack2 = new();
            TreeNode temp = root;
            stack1.Push(temp);
            while (stack1.Count > 0)
            {
                temp = stack1.Pop();
                stack2.Push(temp);
                if (temp.left != null)
                {
                    stack1.Push(temp.left);
                }
                if (temp.right != null)
                {
                    stack1.Push(temp.right);
                }
            }
            while (stack2.Count > 0)
            {
                list.Add(stack2.Pop().val);
            }
            return list;
        }

        public override IList<int> PreOrder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> list = new List<int>();
            TreeNode temp = root;

            while (stack.Count > 0 || temp != null)
            {
                while (temp != null)
                {
                    list.Add(temp.val);
                    stack.Push(temp);
                    temp = temp.left;
                }
                temp = stack.Pop();
                temp = temp.right;
            }

            return list;
        }
    }
}
