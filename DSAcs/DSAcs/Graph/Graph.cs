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
        public int[,] AdjacencyMatrix { get; set; }
        public LinkedListS<Edge> AdjacencyList { get; set; }
        public StorageUsed StorageUsed { get; set; }

        public Graph() { }
        public Graph(LinkedListS<object> vertices, StorageUsed storageUsed)
        {
            // set up vertices: for each vertex, set up ll with vertex
            if (Vertices != null)
            {
                CleanGraph();
            }

            Vertices = new LinkedListS<Vertex>();
            NodeS curr = (NodeS) vertices.Head;
            int length = 1;
            while (curr != null)
            {
                AddVertex(curr.Data);
                curr = (NodeS) curr.Next;
                length++;
            }

            if (storageUsed == StorageUsed.EDGELIST)
            {
                EdgeList = new LinkedListS<Edge>();
            }
            else if (StorageUsed == StorageUsed.ADJACENCYLIST)
            {
                AdjacencyList = new LinkedListS<Edge>();
            }
            else
            {
                AdjacencyMatrix = new int[length, length];
            }
        }

        public void CleanGraph()
        {
            Vertices = null;
            EdgeList = null;
            AdjacencyList = null;
            AdjacencyMatrix = null;
            StorageUsed = StorageUsed.NONE;
        }

        public void AddVertex(object start)
        {
            if (Vertices == null)
            {
                Vertices = new();
            }
            Vertex v = new(start);
            Vertices.Add(v);
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

        private bool SearchForVertex(object a)
        {
            // search for vertex in the list
            // if exists, mark as seen and return true
            // else return false

            NodeS curr = (NodeS) Vertices.Head;
            while (curr != null)
            {
                Vertex currVertex = (Vertex) curr.Data;
                if (currVertex.Data == a)
                {
                    return true;
                }
                curr = (NodeS) curr.Next;
            }
            return false;
        }

        public void AddEdge(object a, object b)
        {
            if (Vertices == null) throw new InvalidOperationException("Cannot add an edge on an empty graph.");

            bool aExists = SearchForVertex(a);
            bool bExists = SearchForVertex(b);
            if (aExists && bExists)
            {
                if (StorageUsed == StorageUsed.EDGELIST)
                {
                    Edge e = new(a, b);
                    EdgeList.Add(e);
                }
                // adjacency matrix
                // adjacency list
            }
            else
            {
                throw new ArgumentException($"Cannot add edge. First parameter exists: {aExists}. Second parameter exists: {bExists}.");
            }
        }
    }

    public enum StorageUsed
    {
        EDGELIST,
        ADJACENCYMATRIX,
        ADJACENCYLIST,
        NONE
    }
}
