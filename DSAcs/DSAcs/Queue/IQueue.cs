using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    public interface IQueue
    {
        public NodeS Pop();
        public void Push(NodeS node);
        public NodeS Peek();

    }
}
