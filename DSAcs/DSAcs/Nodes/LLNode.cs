using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class LLNode : Node
    {
        public LLNode Head { get; set; }
        public LLNode Current { get; set; }
        public LLNode(object data) : base(data) 
        {
            Head = null;
            Current = null;
        }
    }
}
