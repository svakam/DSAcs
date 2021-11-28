using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class TreeNode : Node
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(object data, TreeNode left=null, TreeNode right=null) : base(data)
        {
            Left = left;
            Right = right;
        }
    }
}
