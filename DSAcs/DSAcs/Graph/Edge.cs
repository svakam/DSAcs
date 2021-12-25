using DSAcs.Nodes;

namespace DSAcs.Graph
{
    public class Edge
    {
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; set; }
    }
}
