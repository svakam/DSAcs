using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs
{
    public class Program
    {
        // test code here or 
        public static void Main(string[] args)
        {
            Tree.Tree tree = new(new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4, null, null),
                    null),
                new TreeNode(3, 
                    new TreeNode(5, null, 
                        new TreeNode(6, null, null)), null)
                ));

            tree.TraverseAndPrint(Tree.Tree.TraversalType.PREORDER);
        }
    }
}
