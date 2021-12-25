using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Node: Data
// Vertex: Data, Seen
// LLNode: Data, Head, Curr
// TreeNode: Data, Left, Right
// NodeS: Data, Next
// NodeD: Data, Next, Prev

/*       
 *                           Node
 *                       /     |      \
 *            Vertex    LLNode   TreeNode
 *                         /       \
 *                  NodeS    NodeD
 */

namespace DSAcs.Nodes
{
    public abstract class Node
    {
        public object Data { get; set; }

        public Node(object data)
        {
            Data = data;
        }
    }
}
