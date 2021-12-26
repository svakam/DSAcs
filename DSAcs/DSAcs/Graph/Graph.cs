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
        public LinkedListS<Vertex> AdjacencyList { get; set; }
        public StorageUsed StorageUsed { get; set; }

        public void DFS(Vertex v)
        {
            while (Vertices.Current != null)
            {
                if (Vertices.Current.Data == v.Data)
                {
                    v.Seen = true;

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
