using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class NodeD : Node
    {
        public NodeD B { get; set; }

        public NodeD(object data=null, NodeD B=null) : base(data)
        {
            this.B = B;
        }
    }
}
