﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    public class Queue : QueueBase, IQueue
    {
        public Queue(object data)
        {
            Node node = new NodeS(data);
            Front = node;
            Back = node;
        }

        public void Enqueue(object data)
        {
            Node node = new NodeS(data);
            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = Back.Next;
            }

        }

        public void Enqueue(NodeS node)
        {
            if (node == null) return;

            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = Back.Next;
            }
        }

        public object Peek()
        {
            if (Front != null)
            {
                return Front.Data;
            }
            throw new ArgumentNullException("Queue is empty.");
        }
    }
}
