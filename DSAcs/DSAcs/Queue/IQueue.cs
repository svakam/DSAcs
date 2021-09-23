using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    public interface IQueue<T>
    {
        public NodeS Dequeue();
        public void Enqueue(T data);
        public object Peek();
        public bool IsEmpty();
    }
}
