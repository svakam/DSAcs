using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public abstract class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
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
