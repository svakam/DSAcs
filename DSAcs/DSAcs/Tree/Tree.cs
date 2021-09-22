using System;
using System.Collections.Generic;
using System.Linq;
using DSAcs.LinkedLists;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Tree
{
    public class Tree
    {
        protected TreeNode Root { get; set; }
        protected TraversalType Traversal { get; set; }
        protected OperationType Operation { get; set; }
        protected int Result { get; set; }
        protected StringBuilder Sb { get; set; }

        public Tree(TreeNode root=null)
        {
            Root = root;
        }

        // preorder: root, left, right
        // in order: left, root, right
        // postorder: left, right, root
        public enum TraversalType
        {
            PREORDER,
            INORDER,
            POSTORDER
        }

        public enum OperationType
        {
            PRINT,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE
        }

        public string Traverse(TraversalType traversalType, OperationType operation)
        {
            if (Root == null) return null;

            Traversal = traversalType;
            Operation = operation;

            switch (Operation)
            {
                case OperationType.PRINT:
                    Sb = new StringBuilder();
                    break;
                case OperationType.MULTIPLY:
                    Result = 1;
                    break;
                case OperationType.DIVIDE:
                    Result = 1;
                    break;
                default:
                    Result = 0;
                    break;
            }

            switch (Traversal)
            {
                case TraversalType.PREORDER:
                    break;
                case TraversalType.INORDER:
                    break;
                case TraversalType.POSTORDER:
                    break;
            }

            return Sb.ToString();
        }



    }
}
