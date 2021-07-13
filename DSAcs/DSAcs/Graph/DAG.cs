using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Graph
{
    // graph represented by G = (V, E) where V = {V1, V2, etc.} and E = { {V1, V2, V4}, {V2, V4, V7} , etc. }

    class DAG
    {
        // number of vertices 
        int numVertices;

        // list of vertices
        LinkedList<Node> vertexList;

        // list of edges
        int[,] directedEdgeList; // preferred over LinkedList<Edge> directedEdges; time O(|E|) = O(|V|^2)

        // constructor
        public DAG()
        {
            vertexList = new LinkedList<Node>();
            directedEdgeList = new int[numVertices,numVertices];
        }

        public void CreateGraph()
        {
            // add nodes to vertex list
            // add elements (1 or 0) to adjacency list
            // set numvertices to number of nodes in vertex list
        }

        // check if there isn't a node that's pointing to a node to be removed
        public bool AdjacentNodesExist(Node givenNode)
        {
            // ingest index of node
            int indexOfNode = givenNode.index;

            // use index to access adjacency matrix and check if 1 exists for the row of that index; if so, adjacent node exists
            for (int i = 0; i < directedEdgeList[indexOfNode,]; i++)
            {
                if (directed)
            }
        }

        // remove a node
        public bool RemoveNode(Node givenNode)
        {
            if (AdjacentNodesExist(givenNode))
            {
                return false;
            }

            // access 
        }
    }

    class Node
    {
        public int index; // representation of node in list of vertices
        string data; // node's value
        
        Node(int index, string data)
        {
            this.index = index;
            this.data = data;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            DAG dag = new DAG();
            dag.CreateGraph();
        }
    }
}
