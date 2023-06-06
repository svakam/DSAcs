using DSAcs.Nodes;

namespace DSAcs.Graph
{
    // ideally a tuple
    public class Edge
    {
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex start, Vertex end)
        {
            Start = start;
            End = end;
        }

        public Edge(Vertex start, Vertex end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }
    }
}
