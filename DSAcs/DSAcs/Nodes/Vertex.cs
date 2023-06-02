using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class Vertex : Node
    {
        public bool Seen { get; set; }

        public Vertex(object data) : base(data) 
        {
            Seen = false;
        }
    }
}
