using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class TreeNode<T> : Node<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T data, TreeNode<T> left=null, TreeNode<T> right=null) : base(data)
        {
            Left = left;
            Right = right;
        }
    }
}
