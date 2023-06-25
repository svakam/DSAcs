﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSAcs.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Graph;
using DSAcs.LinkedLists;

namespace DSATest
{
    /*
     * Sample graph:

       node1
       /   ^
      /     \
      v      v
    node2 node3
      ^     /
      |    v
      |---node4
          /
         v
       node5


~~~~~~VERTEX & EDGE LIST~~~~~~
vertices: [1,2,3,4,5]

edges: [[1,2],[1,3],[3,1],[3,4],[4,5],[4,2]]


~~~~~~ADJACENCY MATRIX~~~~~~
Node ID to row index in matrix: {"1":0,"2":1,"3":2,"4":3,"5":4}

Adjacency Matrix:
0,1,1,0,0 
0,0,0,0,0 
1,0,0,1,0 
0,1,0,0,1 
0,0,0,0,0 



~~~~~~ADJACENCY LIST~~~~~~
(1, [2,3])
(2, [])
(3, [1,4])
(4, [5,2])
(5, [])

     */
    [TestClass]
    public class GraphTests
    {
        readonly Vertex node1 = new(1);
        readonly Vertex node2 = new(2);
        readonly Vertex node3 = new(3);
        readonly Vertex node4 = new(4);
        readonly Vertex node5 = new(5);
        Vertex[] Nodes { get; set; }

        public GraphTests()
        {
            Nodes = new Vertex[] { node1, node2, node3, node4, node5 };
        }

        // representations //
        // edge list
        [TestMethod]
        public void TestEdgeList()
        {
            Graph g = new(Nodes);
            var edgeList = g.CreateVertexEdgeList(Nodes);
            foreach (Edge e in edgeList)
            {
                Console.WriteLine(e.Start.ToString(), e.End.ToString());
            }
        }

        // adjacency matrix
        /*
         1:0 [[0,1,1,0,0],
         2:1  [0,0,0,0,0],
         3;2  [1,0,0,1,0],
         4:3  [0,1,0,0,1],
         5:4  [0,0,0,0,0]]
         */
        [TestMethod]
        public void TestAdjacencyMatrix()
        {
            Graph g = new(Nodes);
            g.Connect(node1, node2);
            g.Connect(node1, node3, true);
            g.Connect(node3, node4);
            g.Connect(node4, node5);
            g.Connect(node4, node2);

            int N = Nodes.Length;
            Dictionary<object, int> nodeIdToIndexMapping = new();
            for (int i = 0; i < N; i++)
            {
                nodeIdToIndexMapping.Add(Nodes[i].Data, i);
                Console.WriteLine(nodeIdToIndexMapping[Nodes[i].Data]);
            }

            // pre-populate with 0s
            int[][] m = new int[N][];
            for (int row = 0; row < N; row++)
            {
                m[row] = new int[N];
                Array.Fill(m[row], 0);
            }
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Assert.AreEqual(m[row][col], 0);
                }
            }

            // map each vertex's connections as 1 in matrix
            foreach (Vertex v in Nodes)
            {
                object data = v.Data;
                int rowIdx = nodeIdToIndexMapping[data];
                var row = m[rowIdx];
                foreach (Vertex neighbor in v.Neighbors)
                {
                    int colIdx = nodeIdToIndexMapping[neighbor.Data];
                    row[colIdx] = 1;
                }
            }

            Assert.AreEqual(m[0][1], 1);
            Assert.AreEqual(m[0][2], 1);
            Assert.AreEqual(m[1][1], 0);
            Assert.AreEqual(m[2][0], 1);
            Assert.AreEqual(m[2][3], 1);
            Assert.AreEqual(m[3][1], 1);
            Assert.AreEqual(m[3][4], 1);

            int[][] matrix = g.CreateAdjMatrix(Nodes);
            Assert.AreEqual(matrix[0][1], 1);
            Assert.AreEqual(matrix[0][2], 1);
            Assert.AreEqual(matrix[1][1], 0);
            Assert.AreEqual(matrix[2][0], 1);
            Assert.AreEqual(matrix[2][3], 1);
            Assert.AreEqual(matrix[3][1], 1);
            Assert.AreEqual(matrix[3][4], 1);
        }

        // adjacency list
        /* (1, (2,3)),
         * (2, ()),
         * (3, (1,4)),
         * (4, (5,2)),
         * (5, ())
         */
        [TestMethod]
        public void TestAdjacencyList()
        {
            Graph g = new(Nodes);
            g.Connect(node1, node2);
            g.Connect(node1, node3, true);
            g.Connect(node3, node4);
            g.Connect(node4, node5);
            g.Connect(node4, node2);

            var adjList = g.CreateAdjList(Nodes);
        }

        // traversals //
        [TestMethod]
        public void TestDFSEdgeList()
        {
            
        }

        [TestMethod]
        public void TestBFSEdgeList()
        {
        }

        [TestMethod]
        public void TestDFSAdjacencyMatrix()
        {

        }

        [TestMethod]
        public void TestBFSAdjacencyMatrix()
        {

        }

        [TestMethod]
        public void TestDFSAdjacencyList()
        {

        }

        [TestMethod]
        public void TestBFSAdjacencyList()
        {

        }
    }
}

