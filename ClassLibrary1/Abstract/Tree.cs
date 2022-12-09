using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1.DataStructure;

namespace ClassLibrary1.Abstract
{
    public abstract class Tree
    {
        void Print(IList<int> list)
        {

        }
        public abstract IList<int> InOrder(TreeNode root);
        public abstract IList<int> PreOrder(TreeNode root);
        public abstract IList<int> PostOrder(TreeNode root);

    }
}
