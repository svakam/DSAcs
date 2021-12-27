using DSAcs.Nodes;

namespace DSAcs.Graph
{
    public class Edge
    {
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; set; }

        public Edge(object start, object end)
        {
            Start = new Vertex(start);
            End = new Vertex(end);
        }

        public Edge(object start, object end, int weight)
        {
            Start = new Vertex(start);
            End = new Vertex(end);
            Weight = weight;
        }
    }
}
