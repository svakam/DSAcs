using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class TreeNode : Node
    {
        private TreeNode left;
        public TreeNode Left {
            get
            {
                return left;
            }
            set
            {
                Next = value;
                left = (TreeNode)Next;
            }
        }
        public TreeNode Right { get; set; }

        public TreeNode(object data=null, TreeNode left=null, TreeNode right=null) : base(data)
        {
            Left = left;
            Right = right;
        }
    }
}
