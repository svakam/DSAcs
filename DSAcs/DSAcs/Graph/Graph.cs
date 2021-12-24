using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.LinkedLists;

namespace DSAcs.Graph
{
    public class Graph
    {
        public LinkedListS<Vertex> Vertices { get; set; }
        public LinkedListS<Edge> EdgeList { get; set; }
        public int[][] AdjacencyMatrix { get; set; }
        public LinkedListS<Vertex> AdjacencyList { get; set; }
    }
}
