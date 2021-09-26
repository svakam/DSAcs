using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    public abstract class QueueBase
    {
        public Node Front { get; set; }
        public Node Back { get; set; }
        public QueueBase()
        {
            Front = null;
            Back = null;
        }

        public NodeS Dequeue()
        {
            if (Front == null) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            NodeS temp = (NodeS)Front;
            Front = Front.Next;
            if (Front == null) Back = null;
            return temp;
        }

        public bool IsEmpty()
        {
            return Front == null;
        }
    }
}
