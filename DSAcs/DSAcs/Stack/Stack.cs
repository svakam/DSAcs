using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Stack
{
    // stack is just a singly LL sitting on its tail
    // always adding to and removing from head (1 pointer)
    public class Stack
    {
        NodeS Top { get; set; }
        public Stack(NodeS node)
        {
            Top = node;
        }

        public void Push(NodeS node)
        {
            node.Next = Top;
            Top = node;
        }

        public NodeS Pop()
        {
            NodeS temp = Top;
            Top = (NodeS) Top.Next;
            return temp;
        }

        public object Peek()
        {
            return Top.Data;
        }
    }
}
