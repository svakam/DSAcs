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
    public class Stack<T> : IStack<T>
    {
        NodeS Top { get; set; }
        public Stack(NodeS node)
        {
            Top = node;
        }

        public void Push(T data)
        {
            NodeS node = new(data);
            node.Next = Top;
            Top = node;
        }

        public void Push(NodeS node)
        {
            node.Next = Top;
            Top = node;
        }

        public NodeS Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Cannot pop from stack; stack is empty.");

            NodeS temp = Top;
            Top = (NodeS) Top.Next;
            temp.Next = null;
            return temp;
        }

        public T Peek()
        {
            return (T) Top.Data;
        }
        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}
