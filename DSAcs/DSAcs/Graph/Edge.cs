using DSAcs.Nodes;

namespace DSAcs.Graph
{
    // ideally a tuple
    public class Edge
    {
        public object Start { get; set; }
        public object End { get; set; }
        public int Weight { get; set; }

        public Edge(object start, object end)
        {
            Start = start;
            End = end;
        }

        public Edge(object start, object end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }
    }
}
