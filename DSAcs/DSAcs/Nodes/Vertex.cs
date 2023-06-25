using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class Vertex : Node
    {
        // public int Id { get; set; }
        public List<Vertex> Neighbors { get; set; }
        public bool Seen { get; set; }

        public Vertex(object data) : base(data) 
        {
            // Id = id;
            Neighbors = new List<Vertex>();
            Seen = false;
        }

        //public override string ToString()
        //{
        //    return Id.ToString();
        //}
    }
}
