using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class NodeS<T> : Node<T>
    {
        public NodeS(T data, NodeS<T> next=null) : base(data) 
        {
            Next = next;
        }
    }
}
