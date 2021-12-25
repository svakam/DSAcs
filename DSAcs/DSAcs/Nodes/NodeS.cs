﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class NodeS : LLNode
    {
        public NodeS Next { get; set; }
        public NodeS(object data, NodeS next=null) : base(data)
        {
            Next = next;
        }
    }
}
