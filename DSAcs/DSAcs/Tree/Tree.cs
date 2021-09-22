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
        protected TraversalType TypeOfTraversal { get; set; }
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
        public void TraverseAndPrint(TraversalType traversalType)
        {
            if (Root == null) return;
            TypeOfTraversal = traversalType;

            Sb = new StringBuilder();
            Sb = Sb.Append(Print(Root));

            Console.WriteLine(Sb.ToString());
        }

        // Create()

        private StringBuilder Print(TreeNode node)
        {
            if (node == null)
            {
                return Sb;
            }

            Sb.Append($"{node.Data} ");

            switch (TypeOfTraversal)
            {
                case TraversalType.PREORDER:
                    return Sb.Append(Print(node)).Append(Print(node.Left)).Append(Print(node.Right));
                case TraversalType.INORDER:
                    return Sb.Append(Print(node.Left)).Append(Print(node)).Append(Print(node.Right));
                case TraversalType.POSTORDER:
                    return Sb.Append(Print(node.Left)).Append(Print(node.Right)).Append(Print(node));
                default:
                    return Sb;
            }
        }
    }
}
