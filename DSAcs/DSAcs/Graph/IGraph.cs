using DSAcs.LinkedLists;
using DSAcs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Graph
{
    public interface IGraph
    {

        public string DFS(Dictionary<object, List<object>> adjList);
        public string BFS(object start, Dictionary<object, List<object>> adjList, int targetLevel);
        

    }
}
