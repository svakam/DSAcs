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
        public StorageType StorageUsed { get; set; }
        public bool IsWeighted { get; set; }

        public Graph() { }
        public Graph(LinkedListS<object> vertices, StorageType storageUsed)
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

            if (storageUsed == StorageType.EDGELIST)
            {
                EdgeList = new LinkedListS<Edge>();
            }
            else if (storageUsed == StorageType.ADJACENCYLIST)
            {
                AdjacencyList = new LinkedListS<Edge>();
            }
            else
            {
                AdjacencyMatrix = new int[length, length];
            }
        }

        public void ResetSeenVertices()
        {
            LLNode curr = Vertices.Head;
            while (curr != null)
            {
                Vertex v = (Vertex)curr.Data;
                v.Seen = false;
            }
        }

        public void CleanGraph()
        {
            Vertices = null;
            EdgeList = null;
            AdjacencyList = null;
            AdjacencyMatrix = null;
            IsWeighted = false;
            StorageUsed = StorageType.NONE;
        }

        public void AddVertex(object data)
        {
            if (Vertices == null)
            {
                Vertices = new();
            }
            Vertex v = new(data);
            Vertices.Add(v);
        }

        public void DFS(object start)
        {
            if (StorageUsed == StorageType.EDGELIST)
            {
                Vertex v = SearchVertex(start);
                if (v != null)
                {
                    v.Seen = true;
                    Console.WriteLine(v.Data);
                    DFSHelper(v);
                }
            }
            ResetSeenVertices();
            //throw new ArgumentException("Vertex does not exist in this graph.");
        }
        public void DFSHelper(Vertex v)
        {
            // iterate through edge list to find next connection
            if (StorageUsed == StorageType.EDGELIST)
            {
                Vertex u = GetEdgeEnd(v);
                if (!u.Seen)
                {
                    u.Seen = true;
                    Console.WriteLine(u.Data);
                    DFSHelper(u);
                }
            }
        }

        private bool VertexExists(object a)
        {
            // search for vertex in the lista
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
        private Vertex SearchVertex(object a)
        {
            NodeS curr = (NodeS)Vertices.Head;
            while (curr != null)
            {
                Vertex currVertex = (Vertex)curr.Data;
                if (currVertex.Data == a)
                {
                    return currVertex;
                }
                curr = (NodeS)curr.Next;
            }
            return null;
        }

        public void AddEdge(object a, object b, bool isDirected)
        {
            if (Vertices == null) throw new InvalidOperationException("Cannot add an edge on an empty graph.");

            bool aExists = VertexExists(a);
            bool bExists = VertexExists(b);
            if (aExists && bExists)
            {
                if (StorageUsed == StorageType.EDGELIST)
                {
                    if (EdgeList == null)
                    {
                        EdgeList = new LinkedListS<Edge>();
                    }
                    Edge e = new(a, b);
                    EdgeList.Add(e);

                    // if undirected
                    if (!isDirected)
                    {
                        Edge er = new(b, a);
                        EdgeList.Add(er);
                    }
                }
                // adjacency matrix
                // adjacency list
            }
            else
            {
                throw new ArgumentException($"Cannot add edge. First parameter exists: {aExists}. Second parameter exists: {bExists}.");
            }
        }
        public Vertex GetEdgeEnd(Vertex a)
        {
            NodeS curr = (NodeS)EdgeList.Head;
            while (curr != null)
            {
                Edge e = (Edge)curr.Data;
                if (e.Start == a)
                {
                    return e.End;
                }
                curr = (NodeS)curr.Next;
            }
            return null;
        }
        public object GetEdgeEnd(object a)
        {
            NodeS curr = (NodeS)EdgeList.Head;
            while (curr != null)
            {
                Edge e = (Edge)curr.Data;
                if (e.Start.Data == a)
                {
                    return e.End.Data;
                }
                curr = (NodeS)curr.Next;
            }
            return null;
        }
    }

    public enum StorageType
    {
        EDGELIST,
        ADJACENCYMATRIX,
        ADJACENCYLIST,
        NONE
    }
}
