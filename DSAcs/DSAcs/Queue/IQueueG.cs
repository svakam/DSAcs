using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    public interface IQueueG<T>
    {
        public NodeS Dequeue();
        public void Enqueue(T data);
        public T Peek();
        public bool IsEmpty();
    }
}
