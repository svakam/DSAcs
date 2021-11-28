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
        public Node Next { get; set; }

        public Node(object data)
        {
            Data = data;
        }

        // Data {get; set;} same as:
        // get { return data; }
        // set { data = value; }

        // A {get; set;} same as:
        // get { return next; }
        // set { next = value; }
    }
}
