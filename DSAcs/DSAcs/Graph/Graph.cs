using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DSAcs.Hash;
using DSAcs.LinkedLists;
using DSAcs.Nodes;
using DSAcs.Queue;

/* 
graph general structure, generalized from a tree:
class Node {
    neighbors: List<Node>
    val: int
}
types of graphs: UDG, DG, Tree, Forest, DAG

graph representations: Vertex/Edge list, Adjacency Matrix, Adjacency list
    - V/E list T/S
    easy to represent and visualize - purely a list of edges, where edge = [start, end]
    space O(V + E) (vertex list length + edge list length)
    time neighbor lookup = # E = worst case V^2 (for every vertex, may have to look up all other vertices due to all edges from this vertex going to other vertices)
    (worst case for graphs is when # edges = (V)(V - 1) = V^2 - most nodes connected to each other, dense graph
    edges: [H, W],[W, I], [W, R]

    - adjacency matrix T/S
    space O(V^2) (each side represents 0-indexed vertex, an intersection between ith and jth vertex represents connection bool
    T(neighbor lookup) = O(V) 
    best for dense graphs, where 1's >> 0's
    easier to look up neighbors in 2D array over edge list
    

    - adjacency list T/S - maintains vertex ID mapping from matrix, but replaces matrix with list<vertex id : list<vertex id>> (each vertex's connections)
    optimizes on top of sparse matrix case (removes storing 0's i.e. non-connections)
    space O(V + E)
    T(neighbor lookup) = O(V) (iterate through full list to get vertex + its connections)
    [<0, [1,2]>, <1, [0]>, <2, [1,0]>]
    this mapping is like a compressed version of Node class (key = node.val, vals = Node.neighbors)
    

    T/S
    representation | space   | time (neighbor lookup)
    ---------------|---------|------------------------
        V/E list   | O(V + E)|    O(E) = O(V^2)
    ---------------|---------|------------------------
       adj matrix  | O(V^2)  |    O(V)
    ---------------|---------|------------------------
        adj list   | O(V + E)|    O(V)
                   |         |
*/
namespace DSAcs.Graph
{
    public class Graph : IGraph
    {
        // would implement my own list but trying to run this asap
        public Vertex[] Vertices { get; set; }
        public int NumVertices { get; set; }
        public List<Edge> EdgeList { get; set; }
        public int[][] AdjMatrix { get; set; }
        public Dictionary<object, List<object>> AdjList { get; set; }
        HashSet<object> RegisteredNodeData { get; set; }
        
        private bool IsDuplicate(Vertex v)
        {
            return RegisteredNodeData.Contains(v.Data);
        }

        public Graph(Vertex[] nodes)
        {
            NumVertices = nodes.Length;
            RegisteredNodeData = new();
            foreach (Vertex v in nodes)
            {
                if (IsDuplicate(v))
                {
                    throw new ArgumentException("Duplicate ID found; every node instance must be uniquely identified. Change the ID arg " + v.Data);
                }
                else
                {
                    RegisteredNodeData.Add(v.Data);
                }
            }
            Vertices = nodes;
            EdgeList = new List<Edge>();
            CreateVertexEdgeList(nodes);
            CreateAdjMatrix(nodes);
            CreateAdjList(nodes);
        }

        public static void Connect(Vertex a, Vertex b, bool two_way_connection = false)
        {
            a.Neighbors.Add(b);
            if (two_way_connection) b.Neighbors.Add(a);
        }

        public List<Edge> CreateVertexEdgeList(Vertex[] nodes)
        {
            foreach (Vertex v in nodes)
            {
                foreach (Vertex neighbor in v.Neighbors)
                {
                    EdgeList.Add(new Edge(v.Data, neighbor.Data));
                }
            }
            return EdgeList;
        }

        public int[][] CreateAdjMatrix(Vertex[] nodes)
        {
            // create 0-indexed mapping for each vertex
            Dictionary<object, int> nodeIdToIndexMapping = new();
            for (int i = 0; i < NumVertices; i++)
            {
                nodeIdToIndexMapping.Add(nodes[i].Data, i);
            }

            // initialize matrix of matching size, fill with 0's
            int[][] m = new int[NumVertices][];
            for (int i = 0; i < NumVertices; i++)
            {
                m[i] = new int[NumVertices];
                Array.Fill(m[i], 0);
            }
            
            // map connections to matrix as 1's
            foreach (Vertex v in nodes)
            {
                int rowIdx = nodeIdToIndexMapping[v.Data];
                var row = m[rowIdx];
                foreach (Vertex neighbor in v.Neighbors)
                {
                    int neighborIdx = nodeIdToIndexMapping[neighbor.Data];
                    row[neighborIdx] = 1;
                }
            }

            AdjMatrix = m;
            return AdjMatrix;
        }

        public Dictionary<object, List<object>> CreateAdjList(Vertex[] nodes)
        {
            Console.WriteLine("CreateAdjList");
            Dictionary<object, List<object>> adjList = new();
            foreach (Vertex v in nodes)
            {
                List<Vertex> neighbors = v.Neighbors;
                List<object> neighborList = new();
                foreach (Vertex neighbor in neighbors)
                {
                    neighborList.Add(neighbor.Data);
                }
                adjList.Add(v.Data, neighborList);
            }

            AdjList = adjList;
            return AdjList;
        }

        public Dictionary<object, List<object>> ConvToAdjList(Vertex[] vertices, List<Edge> edgeList, bool isUndirected)
        {
            Dictionary<object, List<object>> adjList = new();
            foreach (Vertex v in vertices)
            {
                adjList.Add(v.Data, new List<object>());
            }
            foreach (Edge e in edgeList)
            {
                adjList[e.Start].Add(e.End);
                if (isUndirected)
                {
                    adjList[e.End].Add(e.Start);
                }
            }

            return adjList;
        }

        // DFS: most important graph algo!!!
        // runtime: O(V + E) - every node processed once, worst case every node touched, every edge considered
        // space: O(V) - every node may exist on queue, and visited hashset contains all nodes
        // space may go up to O(V + E) if converting from v/e list to adj list
        public string DFS(Dictionary<object, List<object>> adjList)
        {
            StringBuilder sb = new();
            HashSet<object> visited = new();
            void Helper(object node)
            {
                // if node's visited, return, else add to visited
                if (visited.Contains(node))
                {
                    sb.Append("DONE");
                    return;
                }
                sb.Append(node);
                visited.Add(node);

                // dfs on neighbors
                List<object> nodeNeighbors = adjList[node];
                if (nodeNeighbors.Count == 0) sb.Append("DONE");
                foreach (object neighbor in nodeNeighbors)
                {
                    Helper(neighbor);
                }
            }

            // iterate over keys in adj list; ensures all sources are visited
            foreach (var node in adjList.Keys)
            {
                if (!visited.Contains(node))
                {
                    Helper(node);
                }
            }
            return sb.ToString();
        }

        public string BFS(object start, Dictionary<object, List<object>> adjList, int targetLevel)
        {
            if (targetLevel == 0) return start.ToString();
            int currLevel = 0;
            StringBuilder sb = new();
            System.Collections.Queue q = new();
            HashSet<object> visited = new();

            q.Enqueue(start);

            while (q.Count > 0)
            {
                int numNodesCurrLvl = q.Count;
                while (numNodesCurrLvl > 0)
                {
                    object curr = q.Dequeue();
                    visited.Add(curr);
                    sb.Append(curr);

                    List<object> currNodeNeighbors = adjList[curr];
                    foreach (object neighbor in currNodeNeighbors)
                    {
                        if (!visited.Contains(neighbor))
                        {
                            q.Enqueue(neighbor);
                        }
                    }
                    numNodesCurrLvl--;
                }
                currLevel++;
                if (currLevel > targetLevel)
                {
                    return sb.ToString();
                }
            }

            return sb.ToString();
        }
    }
}
