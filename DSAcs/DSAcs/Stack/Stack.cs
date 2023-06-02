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
        public NodeS Top { get; set; }
        public Stack() 
        {
            Top = null;
        }
        public Stack(T data)
        {
            NodeS node = new(data);
            Top = node;
        }

        public void Push(T data)
        {
            NodeS node = new(data);
            if (IsEmpty()) Top = node;
            else
            {
                node.Next = Top;
                Top = node;
            }
        }

        public void Push(NodeS node)
        {
            if (IsEmpty()) Top = node;
            else
            {
                node.Next = Top;
                Top = node;
            }
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
