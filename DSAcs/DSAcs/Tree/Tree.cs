﻿using System;
using System.Linq;
using DSAcs.LinkedLists;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.Queue;

namespace DSAcs.Tree
{
    public class Tree
    {
        protected TreeNode Root { get; set; }
        protected TraversalType Traversal { get; set; }
        protected StringBuilder Sb { get; set; }

        public Tree() { }
        public Tree(TreeNode root=null)
        {
            Root = root;
            //if (root == null) Console.WriteLine("input null");
            //if (Root == null) Console.WriteLine("null");
            //Console.WriteLine(Root.GetType());
            //Console.WriteLine($"root: {Root.Data}");
            //Console.WriteLine($"and type: {Root.Data.GetType()}");
        }

        // preorder: root, left, right
        // in order: left, root, right
        // postorder: left, right, root
        public enum TraversalType
        {
            PREORDER,
            INORDER,
            POSTORDER,
            BREADTHFIRST
        }

        public string Traverse(TraversalType traversalType)
        {
            if (Root == null) return null;

            Traversal = traversalType;

            Sb = new StringBuilder();

            // new notation for switch case if a variable's result depends on cases
            switch (Traversal)
            {
                case TraversalType.PREORDER:
                    PreOrder(Root);
                    break;
                case TraversalType.INORDER:
                    InOrder(Root);
                    break;
                case TraversalType.POSTORDER:
                    PostOrder(Root);
                    break;
                case TraversalType.BREADTHFIRST:
                    BreadthFirst(Root);
                    break;
                default:
                    break;
            };
            Console.WriteLine(Sb.ToString());
            return Sb.ToString();
        }

        private void PreOrder(TreeNode node)
        {
            if (node == null) return;

            Sb.Append(node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
        private void InOrder(TreeNode node)
        {
            if (node == null) return;

            InOrder(node.Left);
            Sb.Append(node.Data);
            InOrder(node.Right);
        }
        private void PostOrder(TreeNode node)
        {
            if (node == null) return;

            PostOrder(node.Left);
            PostOrder(node.Right);
            Sb.Append(node.Data);
        }

        // https://stackoverflow.com/questions/17519078/initializing-a-generic-variable-from-a-c-sharp-type-variable
        private void BreadthFirst(TreeNode node)
        {
            if (node == null) return;

            //Queue <type> queue = new Queue<type> ();
            /* 
             tree data type is not known at compile-time
             generic is a compile-time construct, thus cannot use type at runtime; need to construct _instance_ of the generic type at runtime
             https://stackoverflow.com/questions/17519078/initializing-a-generic-variable-from-a-c-sharp-type-variable 
            */
            var type = typeof(QueueG<>).MakeGenericType(node.Data.GetType());
            dynamic context = Activator.CreateInstance(type);
            type.GetMethod("Enqueue").Invoke(context, null);
            
            // enqueue root
            // recursion:
                // print current
                // enqueue left (enqueue will check if null)
        }
    }
}
