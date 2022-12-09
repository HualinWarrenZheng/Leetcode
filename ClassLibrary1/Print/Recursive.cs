using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1.Abstract;
using ClassLibrary1.DataStructure;

namespace ClassLibrary1.Print
{
    public class Recursive : Tree
    {
        public override IList<int> InOrder(TreeNode root)
        {
            var list = new List<int>();
            if (root != null)
            {
                list.AddRange(InOrder(root.left));
                list.Add(root.val);
                list.AddRange(InOrder(root.right));
            }
            return list;
        }

        public override IList<int> PostOrder(TreeNode root)
        {
            var list = new List<int>();
            if (root != null)
            {
                list.Add(root.val);
                list.AddRange(InOrder(root.left));
                list.AddRange(InOrder(root.right));
            }
            return list;
        }

        public override IList<int> PreOrder(TreeNode root)
        {
            var list = new List<int>();
            if (root != null)
            {
                list.AddRange(InOrder(root.left));
                list.AddRange(InOrder(root.right));
                list.Add(root.val);
            }
            return list;
        }
    }
}
