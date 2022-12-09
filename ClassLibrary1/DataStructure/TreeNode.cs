﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataStructure
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        ///        1
        ///      /   \
        ///     2     3
        ///    / \   / \
        ///   4   5 6   7
        ///      / \
        ///     8   9
        /// </summary>
        public static TreeNode Example1
        {
            get
            {
                var eight = new TreeNode(8);
                var nine = new TreeNode(9);
                var five = new TreeNode(5, eight, nine);
                var four = new TreeNode(4);
                var two = new TreeNode(2, four, five);
                var six = new TreeNode(6);
                var seven = new TreeNode(7);
                var three = new TreeNode(3, six, seven);
                var root = new TreeNode(1, two, three);
                return root;
            }
        }

    }
}