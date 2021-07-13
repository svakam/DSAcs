using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public abstract class Node
    {
        public object Data { get; set; }
        // same as:
        // get { return data; }
        // set { data = value; }

        public Node A { get; set; }
        // same as:
        // get { return next; }
        // set { next = value; }
    }
}
