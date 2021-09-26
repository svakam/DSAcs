using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    // queue is open at both ends (2 pointers), with direction front to back
    public class QueueG<T> : QueueBase, IQueueG<T>
    {
        public QueueG() { }
        public QueueG(T data)
        {
            Node node = new NodeS(data);
            Front = node;
            Back = node;
        }

        public void Enqueue(T data)
        {
            Node node = new NodeS(data);
            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = Back.Next;
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
                Back = Back.Next;
            }
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
