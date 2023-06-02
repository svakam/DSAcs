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
        public NodeS Front { get; set; }
        public NodeS Back { get; set; }
        public QueueBase()
        {
            Front = null;
            Back = null;
        }

        public bool IsEmpty()
        {
            return Front == null;
        }
    }
}
