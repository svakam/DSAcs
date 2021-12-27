using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.LinkedLists;
using DSAcs.Nodes;

namespace DSAcs.Graph
{
    public class Graph
    {
        public LinkedListS<Vertex> Vertices { get; set; }
        public LinkedListS<Edge> EdgeList { get; set; }
        public int[][] AdjacencyMatrix { get; set; }
        public LinkedListS<Edge> AdjacencyList { get; set; }
        public StorageUsed StorageUsed { get; set; }

        public Graph()
        {
            if (StorageUsed == StorageUsed.EDGELIST)
            {

            }
            else if (StorageUsed == StorageUsed.ADJACENCYMATRIX)
            {

            }
            else
            {

            }
        }

        public void DFS(object start)
        {
            while (Vertices.Current != null)
            {
                Vertex v = (Vertex) Vertices.Current.Data;
                if (v == start)
                {
                    v.Seen = true;
                }
            }

            throw new ArgumentException("Vertex does not exist in this graph.");
        }
    }

    public enum StorageUsed
    {
        EDGELIST,
        ADJACENCYMATRIX,
        ADJACENCYLIST
    }
}
