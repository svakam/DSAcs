using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    // queue is open at both ends (2 pointers), with direction front to back
    public class Queue<T> : QueueBase, IQueue<T>
    {
        public Queue() { }
        public Queue(T data)
        {
            NodeS node = new(data);
            Front = node;
            Back = node;
        }

        public void Enqueue(T data)
        {
            NodeS node = new(data);
            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = (NodeS) Back.Next;
            }

        }

        public void Enqueue(NodeS node)
        {
            if (node == null) return;

            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = (NodeS) Back.Next;
            }
        }
        public NodeS Dequeue()
        {
            if (Front == null) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            NodeS temp = (NodeS)Front;
            Front = (NodeS) Front.Next;
            temp.Next = null;
            if (Front == null) Back = null;
            return temp;
        }

        public T Peek()
        {
            if (Front != null)
            {
                return (T) Front.Data;
            }
            throw new ArgumentNullException("Queue is empty.");
        }
    }
}
