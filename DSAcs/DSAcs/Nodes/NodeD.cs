using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class NodeD<T> : Node<T>
    {
        public NodeD<T> Prev { get; set; }

        public NodeD(T data, NodeD<T> prev=null, NodeD<T> next=null) : base(data)
        {
            Prev = prev;
            Next = next;
        }
    }
}
