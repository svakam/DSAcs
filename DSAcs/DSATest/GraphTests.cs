using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Graph;
using DSAcs.LinkedLists;

namespace DSATest
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TestInstantiation()
        {
            Graph g = new();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void TestVertexList()
        {
            Graph g = new();
            g.Vertices = new();
            Assert.IsNotNull(g.Vertices);
            g.Vertices.Add(new Vertex("Seattle"));
            g.Vertices.Add(new Vertex("Antarctica"));
            while (g.Vertices.Current != null)
            {
                Assert.AreEqual("DSAcs.Nodes.Vertex", g.Vertices.Current.Data.GetType().ToString());
                g.Vertices.Current = g.Vertices.Current.Next;
            }
        }

        [TestMethod]
        public void TestEdgeList()
        {
            Graph g = new();
            g.Vertices = new();
            Assert.IsNotNull(g.Vertices);
            g.Vertices.Add(new Vertex("Seattle"));
            g.Vertices.Add(new Vertex("Antarctica"));
            g.Vertices.Add(new Vertex("Hilversum"));
            g.Vertices.Add(new Vertex("Melbourne"));
            g.Vertices.Add(new Vertex("Damascus"));
            g.Vertices.Add(new Vertex("Egypt"));
            g.Vertices.Add(new Vertex("Rio de Janiero"));

            g.AddEdge("Seattle", "Hilversum", true);
            g.AddEdge("Hilversum", "Melbourne", true);
            g.AddEdge("Melbourne", "Damascus", true);
            g.AddEdge("Damascus", "Egypt", true);
            g.AddEdge("Egypt", "Antarctica", true);
            g.AddEdge("Antarctica", "Rio de Janiero", true);
            g.AddEdge("Rio de Janiero", "Seattle", true);
            Assert.AreEqual("Melbourne", g.GetEdgeEnd("Hilversum"));
            Assert.AreEqual("Hilversum", g.GetEdgeEnd("Seattle"));
            Assert.AreEqual("Egypt", g.GetEdgeEnd("Damascus"));
            Assert.AreEqual("Antarctica", g.GetEdgeEnd("Egypt"));
            Assert.AreEqual("Seattle", g.GetEdgeEnd("Rio de Janiero"));
        }

        [TestMethod]
        public void TestDFSEdgeList()
        {
            Graph g = new();
            g.Vertices = new();
            Assert.IsNotNull(g.Vertices);
            g.Vertices.Add(new Vertex("Seattle"));
            g.Vertices.Add(new Vertex("Antarctica"));
            g.Vertices.Add(new Vertex("Hilversum"));
            g.Vertices.Add(new Vertex("Melbourne"));
            g.Vertices.Add(new Vertex("Damascus"));
            g.Vertices.Add(new Vertex("Egypt"));
            g.Vertices.Add(new Vertex("Rio de Janiero"));
            g.AddEdge("Seattle", "Hilversum", true);
            g.AddEdge("Hilversum", "Melbourne", true);
            g.AddEdge("Melbourne", "Damascus", true);
            g.AddEdge("Damascus", "Egypt", true);
            g.AddEdge("Egypt", "Antarctica", true);
            g.AddEdge("Antarctica", "Rio de Janiero", true);
            g.AddEdge("Rio de Janiero", "Seattle", true);
            string output = g.DFS("Seattle");
            Assert.AreEqual("Seattle Hilversum Melbourne Damascus Egypt Antarctica Rio de Janiero ", output);
        }
    }
}
