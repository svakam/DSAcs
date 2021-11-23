using System;
using System.Linq;
using DSAcs.LinkedLists;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.Queue;

namespace DSAcs.Tree
{
    public class Tree : TreeBase
    {
        protected TreeNode Root { get; set; }
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
                // enqueue right
                // dequeue curr, move to next in queue
        }

        // traverse tree in postorder; if node is full, increment count and add returned values of left and right subtrees
        public int CountFullNodesDFS(Tree tree)
        {
            return CountFullNodesDFS(tree.Root);
        }
        public int CountFullNodesDFS(TreeNode node)
        {
            if (node == null) return 0;

            int count = 0;
            // recursive case: add current call's count to calls on left and right
            count += CountFullNodesDFS(node.Left) + CountFullNodesDFS(node.Right);
            // base case: if root's left and right aren't null, increment count
            if (node.Left != null && node.Right != null) count++;

            return count;
        }

        // iterative sol'n using a queue: check if a given node has both children; if so, increment count and enqueue its children
        //public int CountFullNodesBFS()
        //{
        //    if (Root == null) return 0;

        //    QueueG<TreeNode> q = new();
        //    q.Enqueue(Root);

        //    int count = 0;
        //    while (!q.IsEmpty())
        //    {
        //        TreeNode temp = q.Dequeue();
        //        if (temp.Left != null && temp.Right != null)
        //        {
        //            count++;
        //        }

        //        if (temp.Left != null) q.Enqueue(temp.Left);
        //        if (temp.Right != null) q.Enqueue(temp.Right);
        //    }

        //    return count;
        //}

        public int GetMaxDepthRecursive(Tree tree)
        {
            return GetMaxDepthRecursive(tree.Root);
        }
        public int GetMaxDepthRecursive(TreeNode node)
        {
            if (node == null) return 0; // when a node is null, returns as -1, but will return as 0 when adding its parent (-1 + 1)

            int lDepth = GetMaxDepthRecursive(node.Left);
            int rDepth = GetMaxDepthRecursive(node.Right);

            if (lDepth > rDepth)
            {
                return lDepth + 1; // counting the current node + the left subtree height
            }
            else
            {
                return rDepth + 1; // counting the current node + the right subtree height
            }
        }

        //public int GetMaxDepthIterative(TreeNode root)
        //{
        //    // base case
        //    if (root == null) return 0;

        //    QueueG<TreeNode> q = new();

        //    // enqueue tree root
        //    q.Enqueue(root);
        //    int height = 0;

        //    // while queue is full, a current level exists to be processed
        //    while (!q.IsEmpty())
        //    {
        //        // increment height for this level
        //        height++;

        //        // get number of nodes in this level
        //        int nodesInCurrLevelProcessed = q.Count();
        //        // process current level's nodes only and add its children to queue
        //        while (nodesInCurrLevelProcessed != 0)
        //        {
        //            TreeNode temp = q.Dequeue(); // dequeue current level's nodes one by one and add children to queue
        //            if (temp.Left != null) q.Enqueue(temp.Left);
        //            if (temp.Right != null) q.Enqueue(temp.Right);
        //            nodesInCurrLevelProcessed--;
        //        }
        //        // at this point, next level is enqueued; increment height at next loop
        //    }
        //    return height;
        //}

        public int MaxValueOfBT(Tree tree)
        {
            return MaxValueOfBT(tree.Root, int.MinValue);
        }
        public int MaxValueOfBT(TreeNode node, int max)
        {
            if (node == null) return max;

            // base
            if ((int)node.Data > max) max = (int)node.Data;

            // recursive

            //int maxFromLeft = MaxValueOfBT(node.Left, max);
            //int maxFromRight = MaxValueOfBT(node.Right, max);
            //return Math.Max(maxFromLeft, maxFromRight);
            return Math.Max(MaxValueOfBT(node.Left, max), MaxValueOfBT(node.Right, max));
        }

        public int MaxValueOfBST(Tree tree)
        {
            return MaxValueOfBST(tree.Root);
        }
        public int MaxValueOfBST(TreeNode node)
        {
            TreeNode rightMost = node;
            while (node.Right != null) rightMost = node.Right;
            return (int)rightMost.Data;
        }
        public int MinValueOfVST(Tree tree)
        {
            return MinValueOfBST(tree.Root);
        }
        public int MinValueOfBST(TreeNode node)
        {
            TreeNode leftMost = node;
            while (node.Left != null) leftMost = leftMost.Left;
            return (int)leftMost.Data;
        }

        public bool ValidateBST(Tree tree)
        {
            return ValidateBST(tree.Root, int.MinValue, int.MaxValue);
        }
        public bool ValidateBST(TreeNode node, int allowedMin, int allowedMax)
        {
            if (node == null) return true; // empty subtree is a true BST; if reach bottom without any falses, whole result returns true

            int value = (int)node.Data;
            // base
            if (value < allowedMin || value > allowedMax) return false;

            // recursive:
            // when moving left, left MUST be smaller than current so constrain max by current - 1
            // when moving right, right MUST be larger than current so constrain min by current + 1
            // if either return false, whole result returns false
            return ValidateBST(node.Left, allowedMin, value - 1) && ValidateBST(node.Right, value + 1, allowedMax);
        }

        public bool IsBSTBalanced(Tree tree)
        {
            return IsBSTBalanced(tree.Root);
        }
        public bool IsBSTBalanced(TreeNode node)
        {
            if (node == null) return true;

            return Math.Abs(GetMaxDepthRecursive(node.Left) - GetMaxDepthRecursive(node.Right)) <= 1;
        }

        public void Insert(int val)
        {
            if (Root == null) Root = new TreeNode(val);
            Insert(Root, val);
        }
        public void Insert(TreeNode node, int val)
        {
            if ((int)node.Data < val)
            {
                if (node.Right != null) Insert(node.Right, val);
                else node.Right = new TreeNode(val);
            }
            else
            {
                if (node.Left != null) Insert(node.Left, val);
                else node.Left = new TreeNode(val);
            }
        }

        public void Remove(int val)
        {
            if (Root == null) throw new InvalidOperationException("Cannot remove from an empty tree.");
            //if (Remove(Root, val)) throw new ArgumentException("Could not find this value in the current tree.");
        }
        //public void Remove(TreeNode node, int val)
        //{
        //    if (node == null) return;
        //    if ((int)node.Data == val)
        //    {
        //        // replace current node with in-order precursor or successor depending on enum input
        //        TreeNode replacementVal;
        //        if (RemovalMethod == RemoveMethod.INORDERPRECURSOR)
        //        {
        //            replacementVal = RemoveAndGetMaxValueOfBST(node.Left);
        //        }
        //        else
        //        {
        //            replacementVal = RemoveAndGetMinValueOfBST(node.Right);
        //        }
        //        node.Data = replacementVal;
        //    }
        //    else if ((int) node.Data > val)
        //    {
        //        Remove(node.Left, val);
        //    }
        //    else
        //    {
        //        Remove(node.Right, val);
        //    }
        //}
        //private TreeNode RemoveAndGetMinValueOfBST(TreeNode node)
        //{
        //    TreeNode leftMost = node;
        //    while (leftMost.Left.Left != null) leftMost = leftMost.Left; // traverse to parent of the min node; condition assumes balanced subtree

        //    TreeNode temp = leftMost.Left;
        //    leftMost.Left = null;
        //    return temp;
        //}
        //private TreeNode RemoveAndGetMaxValueOfBST(TreeNode node)
        //{
        //    TreeNode rightMost = node;
        //    while (rightMost.Right.Right != null) rightMost = rightMost.Right; // traverse to parent of max node; assuming balanced subtree

        //    TreeNode temp = rightMost.Right;
        //    rightMost.Right = null;
        //    return temp;
        //}
    }
}
