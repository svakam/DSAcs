using DSAcs.LinkedLists;
using DSAcs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Graph
{
    public interface IGraph
    {

        // connect two nodes and declare if 2-way connection
        public void Connect(Vertex a, Vertex b, bool two_way_connection = false);

    }
}
