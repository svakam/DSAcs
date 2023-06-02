using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class NodeD : LLNode
    {
        public NodeD Prev { get; set; }

        public NodeD(object data, NodeD prev=null) : base(data)
        {
            Prev = prev;
        }
    }
}
