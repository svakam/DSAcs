using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Stack
{
    public interface IStack
    {
        public void Push(NodeS node);
        public NodeS Pop();
        public NodeS Peek();
    }
}
