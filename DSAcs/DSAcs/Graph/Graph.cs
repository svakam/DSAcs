using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.LinkedLists;
using DSAcs.Nodes;
using DSAcs.Queue;

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
        public StringBuilder Sb { get; set; }

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
                curr = curr.Next;
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
        public void CleanEdgeList()
        {
            EdgeList = null;
        }
        public void CleanSb()
        {
            Sb = null;
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

        public string DFS(object start)
        {
            Sb = new StringBuilder();
            if (StorageUsed == StorageType.EDGELIST)
            {
                // get starting vertex (if not null) and recurse
                Vertex v = SearchVertex(start);
                if (v != null)
                {
                    v.Seen = true;
                    Sb.Append(v.Data).Append(' ');
                    return DFSHelper(v);
                }
                ResetSeenVertices();
                return "";
            }
            else
            {
                return "";
            }
            //throw new ArgumentException("Vertex does not exist in this graph.");
        }
        public string DFSHelper(Vertex v)
        {
            // iterate through edge list to find every possible connection from input vertex
            // print every unseen node and recurse on it
            if (StorageUsed == StorageType.EDGELIST)
            {
                LLNode curr = EdgeList.Head;
                while (curr != null)
                {
                    Edge e = (Edge)curr.Data;
                    if (e.Start == v)
                    {
                        Vertex u = e.End;
                        if (!u.Seen)
                        {
                            u.Seen = true;
                            Sb.Append(u.Data).Append(' ').ToString();
                            DFSHelper(u);
                        }
                        curr = curr.Next;
                    }
                    else
                    {
                        curr = curr.Next;
                    }
                }
                return Sb.ToString();
            }
            else
            {
                return "";
            }
        }

        public string BFS(object start)
        {
            Sb = new StringBuilder();
            // while queue is not empty,
            // with given input, mark as seen and enqueue all unseen vertices by scanning edge list
            // dequeue, mark as seen and queue its unseen
            Vertex v = SearchVertex(start);

            // set up queue with input
            Queue<Vertex> q = new();
            q.Enqueue(v);
            int currConnectionsToProcess = 1;

            while (!q.IsEmpty())
            {
                while (currConnectionsToProcess != 0)
                {
                    Vertex dqFront = (Vertex)q.Dequeue().Data;
                    currConnectionsToProcess--;
                    if (!dqFront.Seen)
                    {
                        dqFront.Seen = true;
                        Sb.Append(dqFront.Data).Append(' ');

                        // get all edges, increment curr connections by 1, and enqueue next connections
                        LinkedListS<Vertex> connectedVertices = GetAllConnectionsEdgeList(dqFront);
                        LLNode curr = connectedVertices.Head;
                        while (curr != null)
                        {
                            q.Enqueue((Vertex)curr.Data);
                            currConnectionsToProcess++;
                            curr = curr.Next;
                        }
                    }
                }
            }
            return Sb.ToString();
        }

        private Vertex GetVertex(object a)
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
                    return currVertex;
                }
                curr = (NodeS) curr.Next;
            }
            return null;
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

            Vertex vA = GetVertex(a);
            Vertex vB = GetVertex(b);
            if (vA != null && vB != null)
            {
                if (StorageUsed == StorageType.EDGELIST)
                {
                    if (EdgeList == null)
                    {
                        EdgeList = new LinkedListS<Edge>();
                    }
                    Edge e = new(vA, vB);
                    EdgeList.Add(e);

                    // if undirected
                    if (!isDirected)
                    {
                        Edge er = new(vB, vA);
                        EdgeList.Add(er);
                    }
                }
                // adjacency matrix
                // adjacency list
            }
            else
            {
                throw new ArgumentException($"Cannot add edge - either one or both parameters do not exist as vertices in this graph. First parameter was {vA}; second parameter was {vB}.");
            }
        }
        public Vertex GetEdgeEnd(Vertex v)
        {
            NodeS curr = (NodeS)EdgeList.Head;
            while (curr != null)
            {
                Edge e = (Edge)curr.Data;
                if (e.Start == v)
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
        public LinkedListS<Vertex> GetAllConnectionsEdgeList(Vertex v)
        {
            LinkedListS<Vertex> connections = new();
            NodeS curr = (NodeS)EdgeList.Head;
            while (curr != null)
            {
                Edge e = (Edge)curr.Data;
                if (e.Start == v)
                {
                    connections.Add(e.End);
                }
                curr = (NodeS)curr.Next;
            }
            return connections;
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
