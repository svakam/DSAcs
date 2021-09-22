using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class TreeNode
    {
        public object Data{ get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(object data=null, TreeNode left=null, TreeNode right=null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}
