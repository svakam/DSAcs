using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Tree
{
    public class TreeBase
    {
        protected static TraversalType Traversal { get; set; }
        protected static RemoveMethod RemovalMethod { get; set; }
    }

    public enum TraversalType
    {
        PREORDER,
        INORDER,
        POSTORDER,
        BREADTHFIRST
    }

    public enum RemoveMethod
    {
        INORDERPRECURSOR,
        INORDERSUCCESSOR
    }
}
